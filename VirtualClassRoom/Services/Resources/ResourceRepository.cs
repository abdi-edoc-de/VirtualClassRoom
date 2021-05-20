using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.DbContexts;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ResourceRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
        public void AddResources(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }
            _appDbContext.Resources.Add(resource);
            _appDbContext.SaveChanges();
        }

        public void DeleteResource(Guid resourceId)
        {
            if( resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            Resource resource = _appDbContext.Resources.FirstOrDefault(r => r.ResourceId == resourceId) ??
                throw new ArgumentNullException(nameof(resource));
            _appDbContext.Resources.Remove(resource);
        }

        public Resource GetResource(Guid resourceId)
        {
            if(resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));

            }
            Resource resource = _appDbContext.Resources.FirstOrDefault(r => r.ResourceId == resourceId) ??
                throw new ArgumentNullException(nameof(resource));
            return resource;
        }

        public IEnumerable<Resource> GetResources(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));

            }
            IEnumerable<Resource> resources = _appDbContext.Resources.Where(r => r.CourseId == courseId).ToList() ??
                throw new ArgumentNullException(nameof(resources));
            return resources;
        }

        public bool ResourceExist(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            return _appDbContext.Resources.Any(s => s.ResourceId == resourceId);
        }
    }
}
