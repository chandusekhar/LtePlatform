﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Lte.Parameters.Entities;

namespace Lte.Parameters.Abstract
{
    public interface ICollege4GTestRepository : IRepository<College4GTestResults>
    {
        College4GTestResults GetByCollegeIdAndTime(int collegeId, DateTime time);
    }
}
