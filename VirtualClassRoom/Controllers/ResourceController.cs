using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;
using VirtualClassRoom.Models.Resources;
using VirtualClassRoom.Services;

namespace VirtualClassRoom.Controllers
{
    [Authorize]
    [Route("api/Courses/{courseId}/Resources")]
    [Consumes("application/octet-stream", "multipart/form-data")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly string pathForFiles = Path.Join("Static" ,"Resources");
        private readonly IResourceRepository _ResourceRepository;
        private readonly IMapper _mapper;

        public ResourceController(IResourceRepository resourceRepository , IMapper mapper)
        {
            _ResourceRepository = resourceRepository;
            _mapper = mapper;

        }


        [HttpGet]
    //[Route("api/Courses/{courseId}/Resources")]
        public ActionResult<IEnumerable<ResourceDto>> GetResourcesForCourse(Guid courseId)
        {
            IEnumerable<Resource> resources = _ResourceRepository.GetResources(courseId);
            if (resources == null)
            {
                return NotFound();
            }
            IEnumerable<ResourceDto> resourceToReturn = _mapper.Map<IEnumerable<ResourceDto>>(resources);
            return Ok(resourceToReturn);
        }

        [HttpPost]
        public ActionResult<ResourceDto> PostResource(Guid courseId, IFormFile file)
        {
            
            Resource resource = new Resource
            {
                FileName = file.FileName,
                FilePath = Path.Combine(pathForFiles, Path.GetRandomFileName()),
                CourseId = courseId,
            };

            _ResourceRepository.AddResources(resource);

            using (var stream = System.IO.File.Create(resource.FilePath))
            {
                file.CopyTo(stream);
            }
            ResourceDto resourceToReturn = _mapper.Map<ResourceDto>(resource);

            return CreatedAtRoute("GetResource",
                new { courseId = courseId, ResourceId = resourceToReturn.ResourceId }
                ,resourceToReturn);
        }

        [HttpGet("{ResourceID}",Name = "GetResource")]
        public ActionResult<ResourceDto> GetResource(Guid ResourceID)
        {
            // TODO: Add authorization for student access
            Resource resource = _ResourceRepository.GetResource(ResourceID);

            if (resource == null)
            {
                return NotFound();
            }
            ResourceDto resourceToReturn = _mapper.Map<ResourceDto>(resource);
            return Ok(resourceToReturn);
        }

        [HttpDelete("{ResourceID}")]
        public ActionResult DeleteResource(Guid ResourceID)
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
