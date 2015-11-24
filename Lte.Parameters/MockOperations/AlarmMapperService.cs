﻿using AutoMapper;
using Lte.Domain.Common;
using Lte.Domain.Regular;
using Lte.Parameters.Entities;

namespace Lte.Parameters.MockOperations
{
    public static class AlarmMapperService
    {
        public static void MapAlarms()
        {
            Mapper.CreateMap<AlarmStatCsv, AlarmStat>()
                .ForMember(d => d.AlarmLevel, opt => opt.MapFrom(s => s.AlarmLevelDescription.GetAlarmLevel()))
                .ForMember(d => d.AlarmCategory, opt => opt.MapFrom(s => s.AlarmCategoryDescription.GetCategory()))
                .ForMember(d => d.AlarmType, opt => opt.MapFrom(s => s.AlarmCodeDescription.GetAlarmType()))
                .ForMember(d => d.SectorId, opt => opt.MapFrom(s => s.ObjectId > 255 ? (byte) 255 : (byte) s.ObjectId));

            Mapper.CreateMap<AlarmStatHuawei, AlarmStat>()
                .ForMember(d => d.AlarmLevel, opt => opt.MapFrom(s => s.AlarmLevelDescription.GetAlarmLevel()))
                .ForMember(d => d.AlarmCategory, opt => opt.MapFrom(s => AlarmCategory.Huawei))
                .ForMember(d => d.AlarmType, opt => opt.MapFrom(s => s.AlarmCodeDescription.GetAlarmHuawei()))
                .ForMember(d => d.ENodebId, opt => opt.MapFrom(s => s.ENodebIdString.ConvertToInt(0)));
        }
    }
}