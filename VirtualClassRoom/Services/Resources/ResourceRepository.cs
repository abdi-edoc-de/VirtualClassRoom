using Microsoft.EntityFrameworkCore;
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
        public async Task<Resource> AddResources(Resource resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }
            _appDbContext.Resources.Add(resource);
            await _appDbContext.SaveChangesAsync();
            return resource;
        }

        public async Task<Resource> DeleteResource(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            Resource resource = await _appDbContext.Resources.FirstOrDefaultAsync(r => r.ResourceId == resourceId) ??
                throw new ArgumentNullException(nameof(resource));
            _appDbContext.Resources.Remove(resource);
            await _appDbContext.SaveChangesAsync();
            return resource; 
        }

        public async Task<Resource> GetResource(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));

            }
            Resource resource = await _appDbContext.Resources.FindAsync(resourceId) ??
                throw new ArgumentNullException(nameof(resource));
            return resource;
        }

        public async Task<IEnumerable<Resource>> GetResources(Guid courseId)
        {
            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));

            }
            IEnumerable<Resource> resources = await _appDbContext.Resources.Where(r => r.CourseId == courseId).ToListAsync() ??
                throw new ArgumentNullException(nameof(resources));
            return resources;
        }

        public async Task<bool> ResourceExist(Guid resourceId)
        {
            if (resourceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(resourceId));
            }
            return await _appDbContext.Resources.AnyAsync(s => s.ResourceId == resourceId);
        }
    }
}
