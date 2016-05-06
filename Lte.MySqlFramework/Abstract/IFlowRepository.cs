﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Lte.MySqlFramework.Entities;

namespace Lte.MySqlFramework.Abstract
{
    public interface IFlowHuaweiRepository : IRepository<FlowHuawei>
    {
        List<FlowHuawei> GetAllList(DateTime begin, DateTime end);

        List<FlowHuawei> GetAllList(DateTime begin, DateTime end, int eNodebId);

        List<FlowHuawei> GetAllList(DateTime begin, DateTime end, int eNodebId, byte sectorId);

        int SaveChanges();
    }
}