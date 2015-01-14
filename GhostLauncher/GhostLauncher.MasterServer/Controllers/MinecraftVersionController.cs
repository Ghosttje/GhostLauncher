using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GhostLauncher.Entities;
using GhostLauncher.Entities.Enums;
using GhostLauncher.MasterServer.Database;
using Repository.Pattern.Ef6;

namespace GhostLauncher.MasterServer.Controllers
{
    public class MinecraftVersionController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;
        public MinecraftVersionController()
        {
            _unitOfWork = new MasterUnitOfWork(new MasterContext());
        }

        /// <summary>
        /// Get all the different minecraft versions
        /// </summary>
        /// <param name="type">The type of instance (Server, Client, ...)</param>
        /// <returns>Minecraft versions data</returns>
        public IEnumerable<MinecraftVersion> GetAll(InstanceTypes type = InstanceTypes.Client & InstanceTypes.Server)
        {
            return _unitOfWork.Repository<MinecraftVersion>().Queryable().Where(x => x.InstanceType == type).ToList();
        }

        /// <summary>
        /// Get one minecraft version
        /// </summary>
        /// <param name="id">The id of the version that you want</param>
        /// <returns>Minecraft version data</returns>
        public MinecraftVersion Get(int id)
        {
            return _unitOfWork.Repository<MinecraftVersion>().Queryable().First(q => q.Id == id);
        }
    }
}