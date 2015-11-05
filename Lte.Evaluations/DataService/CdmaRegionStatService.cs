﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lte.Domain.Regular;
using Lte.Evaluations.ViewModels;
using Lte.Parameters.Abstract;
using Lte.Parameters.Entities;

namespace Lte.Evaluations.DataService
{
    public class CdmaRegionStatService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly ICdmaRegionStatRepository _statRepository;

        public CdmaRegionStatService(IRegionRepository regionRepository, ICdmaRegionStatRepository statRepository)
        {
            _regionRepository = regionRepository;
            _statRepository = statRepository;
        }

        public CdmaRegionDateView QueryLastDateStat(DateTime initialDate, string city)
        {
            DateTime beginDate = initialDate.AddDays(-100);
            DateTime endDate = initialDate.AddDays(1);
            var query =
                _statRepository.GetAll()
                    .Where(x => x.StatDate >= beginDate && x.StatDate < endDate).ToList();
            var regions
                = _regionRepository.GetAllList().Where(x => x.City == city)
                .Select(x => x.Region).Distinct().OrderBy(x => x);
            var result = (from q in query
                join r in regions
                    on q.Region equals r
                select q).ToList();
            if (result.Count == 0) return null;
            var maxDate = result.Max(x => x.StatDate);
            var stats = result.Where(x => x.StatDate == maxDate).ToList();
            var cityStat = stats.ArraySum();
            cityStat.Region = city;
            stats.Add(cityStat);
            return new CdmaRegionDateView
            {
                StatDate = maxDate.ToShortDateString(),
                StatViews = stats.Select(x => new CdmaRegionStatView(x))
            };
        }

        public CdmaRegionStatTrend QueryStatTrend(DateTime begin, DateTime end, string city)
        {
            var query = _statRepository.GetAll().Where(x => x.StatDate >= begin && x.StatDate < end.AddDays(1));
            var regions
                = _regionRepository.GetAllList().Where(x => x.City == city)
                .Select(x => x.Region).Distinct().OrderBy(x => x);
            var result = (from q in query
                          join r in regions
                              on q.Region equals r
                          select q).ToList();
            if (result.Count == 0) return null;
            var dates = result.Select(x => x.StatDate).Distinct().OrderBy(x => x);
            var regionList = result.Select(x => x.Region).Distinct().ToList();
            var viewList = GenerateViewList(result, dates, regionList);
            regionList.Add(city);
            return new CdmaRegionStatTrend
            {
                StatDates = dates.Select(x => x.ToShortDateString()),
                RegionList = regionList,
                ViewList = viewList
            };
        }

        public CdmaRegionStatDetails QueryStatDetails(DateTime begin, DateTime end, string city)
        {
            return new CdmaRegionStatDetails(QueryStatTrend(begin, end, city));
        }

        public static List<IEnumerable<CdmaRegionStatView>> GenerateViewList(List<CdmaRegionStat> statList,
            IEnumerable<DateTime> dates, List<string> regionList)
        {
            var viewList = (from t in regionList
                let regionStats = statList.Where(x => x.Region == t)
                select (from d in dates
                    join stat in regionStats on d equals stat.StatDate into temp
                    from tt in temp.DefaultIfEmpty()
                    select tt ?? new CdmaRegionStat
                    {
                        Region = t, StatDate = d
                    }).ToList()
                into stats
                select stats.Select(x => new CdmaRegionStatView(x))).ToList();
            var cityStat = viewList.Select(x => x.ArraySum()).ToList();
            viewList.Add(cityStat);
            return viewList;
        }
    }
}
