using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualClassRoom.Entities;

namespace VirtualClassRoom.Services
{
    public interface IResourceRepository
    {
        public bool ResourceExist(Guid resourceId);

        public void AddResources(Resource resource);
        public void DeleteResource(Guid resourceId);
        public Resource GetResource(Guid resourceId);
        public IEnumerable<Resource> GetResources(Guid courseId);

    }
}
