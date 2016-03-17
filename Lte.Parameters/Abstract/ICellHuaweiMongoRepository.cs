﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Lte.Parameters.Entities.Basic;
using MongoDB.Bson;

namespace Lte.Parameters.Abstract
{
    public interface ICellHuaweiMongoRepository : IRepository<CellHuaweiMongo, ObjectId>
    {
        List<CellHuaweiMongo> GetAllList(int eNodebId);

        List<CellHuaweiMongo> GetRecentList(int eNodebId);

        CellHuaweiMongo GetRecent(int eNodebId, byte sectorId);
    }
}