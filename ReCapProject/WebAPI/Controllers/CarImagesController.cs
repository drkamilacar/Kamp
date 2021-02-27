using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getallcarimages")]
        public IActionResult GetAllCarImages()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagebyid")]
        public IActionResult GetImageById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesofcar")]
        public IActionResult GetImagesOfCar(int id)
        {
            var result = _carImageService.GetCarImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileToUpload fileToUpload, int carId)
        {
            var result = _carImageService.Add(carId, DateTime.Now, fileToUpload.file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] FileToUpload fileToUpload, [FromForm] CarImage carImage)
        {
            try
            {
                if (fileToUpload.file.Length > 0)
                {
                    string formerFileName = carImage.ImagePath;
                    string uploadingFileName = fileToUpload.file.FileName;
                    string imagePath = _webHostEnvironment.WebRootPath + "\\uploads\\carimages\\";

                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(uploadingFileName);
                    string fileExtension = fileInfo.Extension;

                    DateTime currentDate = DateTime.Now;
                    String carImageFileName = Guid.NewGuid().ToString("N") + "_" +
                        String.Format("Number {0, 0:D2}", currentDate.Year) +
                        String.Format("Number {0, 0:D2}", currentDate.Month) +
                        String.Format("Number {0, 0:D2}", currentDate.Day) +
                        String.Format("Number {0, 0:D2}", currentDate.Hour) +
                        String.Format("Number {0, 0:D2}", currentDate.Minute) +
                        String.Format("Number {0, 0:D2}", currentDate.Second) + fileExtension;

                    using (FileStream fileStream = System.IO.File.Create(imagePath + carImageFileName))
                    {
                        await fileToUpload.file.CopyToAsync(fileStream);

                        imagePath += carImageFileName;

                        fileStream.Flush();
                    }

                    carImage.ImagePath = imagePath;
                    carImage.Date = currentDate;

                    var result = _carImageService.Update(carImage, formerFileName);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                else
                {
                    return BadRequest("Cannot uploaded");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
