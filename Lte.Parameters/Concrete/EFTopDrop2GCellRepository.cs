﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lte.Parameters.Abstract;
using Lte.Parameters.Entities;

namespace Lte.Parameters.Concrete
{
    public class EFTopDrop2GCellRepository : LightWeightRepositroyBase<TopDrop2GCell>, ITopDrop2GCellRepository
    {
        protected override DbSet<TopDrop2GCell> Entities => context.TopDrop2GStats;

        public int Import(IEnumerable<TopDrop2GCellExcel> stats)
        {
            var count = 0;
            foreach (var stat in from stat in stats
                let time = stat.StatDate.AddHours(stat.StatHour)
                let info =
                    FirstOrDefault(x => x.BtsId == stat.BtsId && x.SectorId == stat.SectorId && x.StatTime == time)
                where info == null
                select stat)
            {
                Insert(TopDrop2GCell.ConstructStat(stat));
                count++;
            }
            return count;
        }
    }
}