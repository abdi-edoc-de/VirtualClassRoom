using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IResourceRepository
    {
        public Task<bool> ResourceExist(Guid resourceId);

        public Task<Resource> AddResources(Resource resource);
        public Task<Resource> DeleteResource(Guid resourceId);
        public Task<Resource> GetResource(Guid resourceId);
        public Task<IEnumerable<Resource>> GetResources(Guid courseId);

    }
}
