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
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly string pathForFiles = Path.Join("Static", "Resources");
        private readonly IResourceRepository _ResourceRepository;
        private readonly IMapper _mapper;

        public ResourceController(IResourceRepository resourceRepository, IMapper mapper)
        {
            _ResourceRepository = resourceRepository;
            _mapper = mapper;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDto>>> GetResourcesForCourse(Guid courseId)
        {
            IEnumerable<Resource> resources = await _ResourceRepository.GetResources(courseId);
            if (resources == null)
            {
                return NotFound();
            }
            //IEnumerable<ResourceDto> resourceToReturn = _mapper.Map<IEnumerable<ResourceDto>>(resources);
            return Ok(resources);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<ResourceDto>> PostResource(Guid courseId, IFormFile file)
        {
            if (file == null)
            {
                return BadRequest("Make sure you have the file named file in form");
            }
            Resource resource = new Resource
            {
                FileName = file.FileName,
                FilePath = Path.Combine(pathForFiles, Path.GetRandomFileName()),
                CourseId = courseId,
            };

            await _ResourceRepository.AddResources(resource);

            using (var stream = System.IO.File.Create(resource.FilePath))
            {
                file.CopyTo(stream);
            }
            ResourceDto resourceToReturn = _mapper.Map<ResourceDto>(resource);

            return CreatedAtRoute("GetResource",
                new { courseId = courseId, ResourceId = resourceToReturn.ResourceId }
                , resourceToReturn);
        }

        [HttpGet("{ResourceID}", Name = "GetResource")]
        public async Task<ActionResult<ResourceDto>> GetResource(Guid ResourceID)
        {
            // TODO: Add authorization for student access
            Resource resource = await _ResourceRepository.GetResource(ResourceID);

            if (resource == null)
            {
                return NotFound();
            }
            // TODO: Change this to DTO style
            return Ok(resource);
        }

        [HttpDelete("{ResourceID}")]
        public async Task<ActionResult> DeleteResource(Guid ResourceID)
        {
            Resource resource = await _ResourceRepository.GetResource(ResourceID);

            if (resource == null)
            {
                return NotFound();
            }
            System.IO.File.Delete(resource.FilePath);
            var _ = _ResourceRepository.DeleteResource(ResourceID);
            return Accepted();
        }

        [HttpGet("{ResourceID}/Download")]
        public async Task<ActionResult> DownloadResource(Guid ResourceID)
        {
            Resource resource = await _ResourceRepository.GetResource(ResourceID);
            if (resource == null)
            {
                return NotFound();
            }
            var content = new FileStream(resource.FilePath, FileMode.Open, FileAccess.Read);
            var response = File(content, "application/octet-stream", resource.FileName);
            return response;
        }

    }
}
