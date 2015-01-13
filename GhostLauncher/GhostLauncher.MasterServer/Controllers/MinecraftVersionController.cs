using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GhostLauncher.Entities;
using GhostLauncher.Entities.Enums;
using GhostLauncher.Entities.JsonResponse;
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

        public ResponseList<MinecraftVersion> GetAll(InstanceTypes type = InstanceTypes.Client & InstanceTypes.Server)
        {
            var result = _unitOfWork.Repository<MinecraftVersion>().Queryable().Where(x => x.InstanceType == type).ToList();
            return new ResponseList<MinecraftVersion>(result);
        }

        public ResponseItem<MinecraftVersion> Get(int id)
        {
            var result = _unitOfWork.Repository<MinecraftVersion>().Queryable().First(q => q.Id == id);
            return new ResponseItem<MinecraftVersion>(result);
        }
    }
}