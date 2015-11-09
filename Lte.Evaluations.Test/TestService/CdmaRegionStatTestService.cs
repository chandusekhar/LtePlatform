﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lte.Evaluations.DataService;
using Lte.Evaluations.Test.MockItems;
using Lte.Evaluations.ViewModels;
using Lte.Parameters.Abstract;
using Lte.Parameters.Entities;
using Moq;

namespace Lte.Evaluations.Test.TestService
{
    public class CdmaRegionStatTestService
    {
        private readonly Mock<IRegionRepository> _regionRepository;
        private readonly Mock<ICdmaRegionStatRepository> _statRepository;

        public CdmaRegionStatTestService(Mock<IRegionRepository> regionRepository,
            Mock<ICdmaRegionStatRepository> statRepository)
        {
            _regionRepository = regionRepository;
            _statRepository = statRepository;
        }

        public void ImportElangRecord(string region, string recordDate, double erlang)
        {
            _statRepository.MockCdmaRegionStats(new List<CdmaRegionStat>
            {
                new CdmaRegionStat
                {
                    Region = region,
                    StatDate = DateTime.Parse(recordDate),
                    ErlangIncludingSwitch = erlang
                }
            });
        }

        public void ImportElangRecords(string region, string[] recordDates, double[] erlangs)
        {
            var statList = new List<CdmaRegionStat>();
            for (int i = 0; i < recordDates.Length; i++)
            {
                statList.Add(new CdmaRegionStat
                {
                    Region = region,
                    StatDate = DateTime.Parse(recordDates[i]),
                    ErlangIncludingSwitch = erlangs[i]
                });
            }
            _statRepository.MockCdmaRegionStats(statList);
        }

        public void ImportElangRecords(string[] regions, string recordDate, double[] erlangs)
        {
            var statList = new List<CdmaRegionStat>();
            for (int i = 0; i < regions.Length; i++)
            {
                statList.Add(new CdmaRegionStat
                {
                    Region = regions[i],
                    StatDate = DateTime.Parse(recordDate),
                    ErlangIncludingSwitch = erlangs[i]
                });
            }
            _statRepository.MockCdmaRegionStats(statList);
        }

        public void ImportElangRecords(string[] regions, string[] recordDates, double[] erlangs)
        {
            var statList = new List<CdmaRegionStat>();
            for (int i = 0; i < regions.Length; i++)
            {
                statList.Add(new CdmaRegionStat
                {
                    Region = regions[i],
                    StatDate = DateTime.Parse(recordDates[i]),
                    ErlangIncludingSwitch = erlangs[i]
                });
            }
            _statRepository.MockCdmaRegionStats(statList);
        }

        public void ImportDrop2Gs(string[] regions, string recordDate, int[] drop2GNums, int[] drop2GDems)
        {
            var statList = new List<CdmaRegionStat>();
            for (int i = 0; i < regions.Length; i++)
            {
                statList.Add(new CdmaRegionStat
                {
                    Region = regions[i],
                    StatDate = DateTime.Parse(recordDate),
                    Drop2GNum = drop2GNums[i],
                    Drop2GDem = drop2GDems[i]
                });
            }
            _statRepository.MockCdmaRegionStats(statList);
        }

        public CdmaRegionDateView QueryLastDateStat(string initialDate, string city)
        {
            var service = new CdmaRegionStatService(_regionRepository.Object, _statRepository.Object);
            return service.QueryLastDateStat(DateTime.Parse(initialDate), city);
        }

        public CdmaRegionStatTrend QueryDateTrend(string beginDate, string endDate, string city)
        {
            var service = new CdmaRegionStatService(_regionRepository.Object, _statRepository.Object);
            return service.QueryStatTrend(DateTime.Parse(beginDate), DateTime.Parse(endDate), city);
        }
    }
}