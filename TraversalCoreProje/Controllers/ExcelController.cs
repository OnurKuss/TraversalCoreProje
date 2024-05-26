﻿using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()),
                "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 2].Value = "Kontenjan";

            workSheet.Cells[2, 1].Value = "Gürcistan Batum Turu";
            workSheet.Cells[2, 2].Value = "Kadir Yıldız";
            workSheet.Cells[2, 2].Value = "50";

            workSheet.Cells[3, 1].Value = "Sırbistan-Makedonya Turu";
            workSheet.Cells[3, 2].Value = "Zeynep Öztürk";
            workSheet.Cells[3, 2].Value = "30";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "dosya2.xlsx");
        }
        public List<DestinationModel> DestinationList()
        {
            using (var c = new Context())
            {
                var destinationModels = new List<DestinationModel>();
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City = x.City,
                    DayNight = x.DayNigth,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
                return destinationModels;
            }
        }

       

        public IActionResult DestinationExcelReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.AddWorksheet("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount,1).Value= item.City;
                    workSheet.Cell(rowCount,2).Value= item.DayNight;
                    workSheet.Cell(rowCount,3).Value= item.Price;
                    workSheet.Cell(rowCount,4).Value= item.Capacity;
                    rowCount++;
                }

                using (var stream  = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet",
                        "YeniListe.xlsx");
                }
            }
        }
    }
}
