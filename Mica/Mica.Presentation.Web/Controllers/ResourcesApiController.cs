using Mica.Presentation.Web.Controllers.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mica.Presentation.Web.Controllers
{
    [Route("api/Resources")]
    public class ResourcesApiController : ApiController
    {
        private IHostingEnvironment _environment;

        public ResourcesApiController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
       
        [HttpPost]
        public async Task<OkObjectResult> Upload(ICollection<IFormFile> files)
        {
            var serverFileNames = new List<string>();
            var resourcesPath = Path.Combine(_environment.WebRootPath, "resources");
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var serverName = string.Format("{0}-{2}.{1}", 
                        Path.GetFileNameWithoutExtension(file.FileName),
                        Path.GetExtension(file.FileName),
                        DateTime.Now.ToUniversalTime().Ticks);

                    using (var fileStream = new FileStream(Path.Combine(resourcesPath, serverName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        serverFileNames.Add(serverName);
                    }
                }
            }

            return Ok(serverFileNames.ToArray());
        }
    }
}
