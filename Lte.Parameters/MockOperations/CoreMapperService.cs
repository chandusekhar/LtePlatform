﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lte.Domain.Common.Wireless;
using Lte.Parameters.Entities;

namespace Lte.Parameters.MockOperations
{
    public static class CoreMapperService
    {
        public static void MapCdmaCell()
        {
            Mapper.CreateMap<CdmaCellExcel, CdmaCell>()
                .ForMember(d => d.Frequency, opt => opt.Ignore())
                .ForMember(d => d.IsOutdoor, opt => opt.MapFrom(s => s.IsIndoor.Trim() == "否"));
        }

        public static void MapCell()
        {
            Mapper.CreateMap<CellExcel, Cell>()
                .ForMember(d => d.AntennaPorts, opt => opt.MapFrom(s => s.TransmitReceive.GetAntennaPortsConfig()))
                .ForMember(d => d.IsOutdoor, opt => opt.MapFrom(s => s.IsIndoor.Trim() == "否"));
        }

        public static void MapIndoorDistribution()
        {
            Mapper.CreateMap<IndoorDistributionExcel, IndoorDistribution>();
        }
    }
}