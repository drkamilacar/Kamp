using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public interface IFileProcesses
    {
        Task <IResult> UploadFileWithGuidNameAndSaveDate(string filePath, IFormFile fileToUpload, DateTime saveDate);
    }
}
