﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int id);
        IResult Add(int id, DateTime saveDate, IFormFile file);
        IResult Update(CarImage carImage, string imagePathToDelete);
        IResult Delete(CarImage carImage);
    }
}
