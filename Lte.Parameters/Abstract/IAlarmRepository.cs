﻿using System;
using System.Collections.Generic;
using Abp.Domain.Repositories;
using Lte.Parameters.Entities;

namespace Lte.Parameters.Abstract
{
    public interface IAlarmRepository : IRepository<AlarmStat>
    {
        List<AlarmStat> GetAllList(DateTime begin, DateTime end);
    }
}
