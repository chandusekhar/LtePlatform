﻿using AutoMapper;
using Lte.Parameters.MockOperations;

namespace Lte.Evaluations.MapperSerive
{
    public class EvalutaionMapperProfile : Profile
    {
        protected override void Configure()
        {
            CoreMapperService.MapCdmaCell();
            CoreMapperService.MapCell();
            CoreMapperService.MapIndoorDistribution();
            AlarmMapperService.MapAlarms();
            StatMapperService.MapCdmaRegionStat();
            StatMapperService.MapPreciseCoverage();
            StatMapperService.MapTopConnection3G();
            StatMapperService.MapTopDrop2G();
            
            InfrastructureMapperService.MapENodeb();
            InfrastructureMapperService.MapCdmaCell();
            InfrastructureMapperService.MapCell();
            CollegeMapperService.MapCollege3GTest();
            CollegeMapperService.MapCollege4GTest();
            CollegeMapperService.MapCollegeKpi();
            KpiMapperService.MapCdmaRegionStat();
            KpiMapperService.MapCellPrecise();
            KpiMapperService.MapDistrictPrecise();
            KpiMapperService.MapTownPrecise();
        }
    }
}