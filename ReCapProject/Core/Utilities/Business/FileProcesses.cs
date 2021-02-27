using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class FileProcesses : IFileProcesses
    {
        IHostingEnvironment _environment;

        public FileProcesses(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task <IResult> UploadFileWithGuidNameAndSaveDate(string filePath, IFormFile fileToUpload, DateTime saveDate)
        {
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileToUpload.FileName);
            string fileExtension = fileInfo.Extension;

            filePath = _environment.ContentRootPath + filePath;

            String fileName = string.Format("{0}_{1:yyMMddHHmmss}{2}", Guid.NewGuid().ToString("N"), saveDate, fileExtension);

            string currentPath = Path.Combine(filePath, fileName);

            if (!Directory.Exists(filePath))
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch (Exception ex)
                {
                    return new ErrorResult(ex.Message);
                }
            }
            using (FileStream fileStream = System.IO.File.Create(currentPath))
            {
                try
                {
                    await fileToUpload.CopyToAsync(fileStream);
                }
                catch (Exception ex)
                {
                    return new ErrorResult(ex.Message);
                }
                fileStream.Flush();
            }
            return new SuccessResult(currentPath);
        }
    }
}
