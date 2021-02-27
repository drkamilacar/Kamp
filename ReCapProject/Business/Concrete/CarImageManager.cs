using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileProcesses _fileProcesses;


        public CarImageManager(ICarImageDal carImageDal, IFileProcesses fileProcesses)
        {
            _carImageDal = carImageDal;
            _fileProcesses = fileProcesses;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(int carId, DateTime saveDate, IFormFile fileToUpload)
        {
            var result = BusinessRules.Run(
                CheckIfImageLimitOfTheCarIsExceeded(carId)
                );

            if (result != null)
            {
                return result;
            }

            var fileUploadResult = _fileProcesses.UploadFileWithGuidNameAndSaveDate("\\uploads\\cars\\", fileToUpload, saveDate);
            if (fileUploadResult.Result.Success)
            {
                CarImage newCarImage = new CarImage { CarId = carId, Date = saveDate, ImagePath = fileUploadResult.Result.Message };
                _carImageDal.Add(newCarImage);
                return new SuccessResult(Messages.CarImageAdded);
            }
            return new ErrorResult(Messages.FileCannotUploaded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            var result = BusinessRules.Run(
                DeleteCarImageFile(carImage.ImagePath)
                );

            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new Result(true, Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarDoesntHasAnyImage(id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, string imagePathToDelete)
        {
            var result = BusinessRules.Run(
                DeleteCarImageFile(imagePathToDelete)
                );

            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(carImage);
            return new Result(true, Messages.CarImageUpdated);
        }


        private IResult CheckIfImageLimitOfTheCarIsExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceededOfTheCar);
            }

            return new SuccessResult();
        }

        private IResult DeleteCarImageFile(string imagePathToDelete)
        {
            try
            {
                File.Delete(imagePathToDelete);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarDoesntHasAnyImage(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\noimageavailable.jpg");
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Count == 0)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return result;
        }

    }
}
