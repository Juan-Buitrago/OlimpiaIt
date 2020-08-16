using OlimpiaBusiness.Implementation.Exercise1;
using OlimpiaBusiness.Interfaces.Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestOlimpia.Controllers
{
    [RoutePrefix("Digit")]
    public class DigitController : ApiController
    {

        #region Dependency Injection
        private readonly IDigit _IDigitService;
        private readonly IFile _IFileService;
        #endregion

        public DigitController(IDigit IDigitService, IFile IFileService)
        {
            _IDigitService = IDigitService;
            _IFileService = IFileService;
        }

        #region Méthods
        [HttpPost]
        [Route("GetTextFromPath")]
        public IHttpActionResult GetTextFromPath([FromBody] string path)
        {
            return Json(_IFileService.GetFileContentByPath(path));
        }
        #endregion
    }
}
