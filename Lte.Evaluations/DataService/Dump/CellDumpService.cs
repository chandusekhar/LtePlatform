﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lte.Evaluations.MapperSerive;
using Lte.Parameters.Abstract;
using Lte.Parameters.Entities;

namespace Lte.Evaluations.DataService.Dump
{
    public class CellDumpService
    {
        private readonly IBtsRepository _btsRepository;
        private readonly ICellRepository _cellRepository;

        public CellDumpService(IBtsRepository btsRepository, ICellRepository cellRepository)
        {
            _btsRepository = btsRepository;
            _cellRepository = cellRepository;
        }

        public void DumpNewCellExcels(IEnumerable<CellExcel> infos)
        {
            var cellList = Mapper.Map<IEnumerable<CellExcel>, List<Cell>>(infos);
            cellList.ForEach(cell => _cellRepository.InsertAsync(cell));
        }

        public void UpdateENodebBtsIds(IEnumerable<CellExcel> infos)
        {
            var idPairs =
                Mapper.Map<IEnumerable<CellExcel>, IEnumerable<ENodebBtsIdPair>>(infos)
                    .Where(x => x.BtsId != -1)
                    .Distinct()
                    .ToList();
            idPairs.ForEach(x =>
            {
                var bts = _btsRepository.GetByBtsId(x.BtsId);
                bts.ENodebId = x.ENodebId;
                _btsRepository.UpdateAsync(bts);
            });
        }
    }
}