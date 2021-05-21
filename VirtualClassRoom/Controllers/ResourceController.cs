using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [Route("api/Courses/{CourseID}/Resources")]
    [Consumes("application/octet-stream", "multipart/form-data")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly string pathForFiles = Path.Join("Static" ,"Resources");
        private readonly IResourceRepository _ResourceRepository;

        public ResourceController(IResourceRepository resourceRepository)
        {
            _ResourceRepository = resourceRepository;

        }


        [HttpGet]
        public IActionResult GetResourcesForCourse(Guid CourseID)
        {
            IEnumerable<Resource> resources = _ResourceRepository.GetResources(CourseID);
            return Ok(resources);
        }

        [HttpPost]
        public IActionResult PostResource(Guid CourseID, IFormFile file)
        {
            
            Resource resource = new Resource
            {
                FileName = file.FileName,
                FilePath = Path.Combine(pathForFiles, Path.GetRandomFileName()),
                CourseId = CourseID,
            };

            _ResourceRepository.AddResources(resource);

            using (var stream = System.IO.File.Create(resource.FilePath))
            {
                file.CopyTo(stream);
            }
            return Ok();
        }

        [HttpGet("{ResourceID}",Name = "GetResource")]
        public IActionResult GetResource(Guid ResourceID)
        {
            // TODO: Add authorization for student access
            Resource resource = _ResourceRepository.GetResource(ResourceID);

            if (resource == null)
            {
                return NotFound();
            }
            return Ok(resource);
        }

        [HttpDelete("{ResourceID}")]
        public IActionResult DeleteResource(Guid ResourceID)
        { 
            Resource resource = _ResourceRepository.GetResource(ResourceID);

            if (resource == null)
            {
                return NotFound();
            }
            System.IO.File.Delete(resource.FilePath);
            _ResourceRepository.DeleteResource(ResourceID);
            return Accepted();
        }

        [HttpGet("{ResourceID}/Download")]
        public ActionResult DownloadResource(Guid ResourceID)
        {
            Resource resource = _ResourceRepository.GetResource(ResourceID);
            if (resource == null)
            {
                return NotFound();
            }
            var content = new FileStream(resource.FilePath, FileMode.Open, FileAccess.Read);
            var response =  File(content, "application/octet-stream", resource.FileName);
            return response;
        }

    }
}
