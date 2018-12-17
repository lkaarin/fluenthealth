using FluentHealth.Core.Data;
using FluentHealth.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FluentHealth.Web.Controllers
{
    public class StorageController : Controller
    {
        private readonly IFilesRepository _filesRepository;
        private readonly IFilesStorage _filesStorage;

        public StorageController(IFilesRepository filesRepository, IFilesStorage filesStorage)
        {
            _filesRepository = filesRepository;
            _filesStorage = filesStorage;
        }

        [HttpGet]

        public IActionResult Index() => View();

        [HttpPost]

        public IActionResult Upload()
        {
            if(Request.Form.Files.Count > 0)
            {
                if (string.IsNullOrEmpty(Request.Headers["X-File-Name"]))
                {
                    UploadWholeFile(Request.Form.Files);
                }
            }

            return Json("OK");
        }

        private void UploadWholeFile(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                using(var ms = new MemoryStream())
                {
                    file.CopyTo(ms);

                    _filesStorage.TryUploadFile(ms.ToArray(), file.FileName,  out object id);
                }
            }
        }
    }
}