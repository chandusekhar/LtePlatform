﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lte.Domain.Common;
using Lte.Evaluations.DataService;

namespace LtePlatform.Controllers
{
    public class KpiController : Controller
    {
        private readonly TownQueryService _townService;
        private readonly KpiImportService _importService;

        public KpiController(TownQueryService townService, KpiImportService importService)
        {
            _townService = townService;
            _importService = importService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Precise4G()
        {
            return View();
        }

        public ActionResult TopDrop2G()
        {
            return View();
        }

        public ActionResult TopDrop2GDaily()
        {
            return View();
        }

        public ActionResult TopConnection3G()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ViewResult KpiImport()
        {
            var message = "";
            var httpPostedFileBase = Request.Files["dailyKpi"];
            if (httpPostedFileBase == null || httpPostedFileBase.FileName == "")
            {
                ViewBag.ErrorMessage = "上传文件为空！请先上传文件。";
            }
            else
            {
                var city = httpPostedFileBase.FileName.GetSplittedFields('.')[0];
                var legalCities = _townService.GetCities();
                if (legalCities.Count > 0 && legalCities.FirstOrDefault(x => x == city) == null)
                {
                    city = legalCities[0];
                    ViewBag.WarningMessage = "上传文件名对应的城市找不到。使用'" + city + "'代替";
                }
                var regions = _townService.GetRegions(city);
                var path = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "\\uploads\\Kpi"),
                    httpPostedFileBase.FileName);
                httpPostedFileBase.SaveAs(path);
                message = _importService.Import(path, regions);
            }
            ViewBag.Message = message;
            return View("Import");
        }
    }
}