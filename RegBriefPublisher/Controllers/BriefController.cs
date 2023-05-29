using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using RegBriefPublisher.Database;
using RegBriefPublisher.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace RegBriefPublisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BriefController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BriefController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("PopulateData")]
        public IActionResult PopulateData(IFormFile file, DateTime pubDate)
        {
            try
            {
                Brief brief = new Brief();
                BriefCountryMap briefCountryMap = new BriefCountryMap();
                List<Brief> briefList = new List<Brief>();
                string _month = "";
                int _year = 0;

                if (file == null || file.Length == 0)
                    return BadRequest("No file uploaded.");

                using var stream = new MemoryStream();
                file.CopyTo(stream);

                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets[0]; // Assuming the data is in the first sheet


                var rows = worksheet.Cells
                                    .Where(cell => cell.Start.Row > 1) // Skip header row
                                    .Select(cell => cell.Start.Row)
                                    .Distinct();


                foreach (var row in rows)
                {
                    var rowData = new List<string>();
                    var lastColumn = worksheet.Dimension.End.Column;

                    for (int column = 1; column <= lastColumn; column++)
                    {
                        var cell = worksheet.Cells[row, column];
                        var cellValue = cell.Value?.ToString() ?? string.Empty;
                        rowData.Add(cellValue);
                    }

                    if (!string.IsNullOrEmpty(rowData[0]) || rowData[0] == "WTA")
                    {
                        brief = new Brief();
                    }

                    if (!string.IsNullOrEmpty(rowData[1]) && !string.IsNullOrEmpty(rowData[2]))
                    {
                        _month = rowData[1];
                        _year = int.Parse(rowData[2]);
                    }

                    WTABrief wTABrief = new WTABrief();
                    wTABrief.Title = rowData[4];
                    wTABrief.ShortStory = rowData[5];
                    wTABrief.LongStory = rowData[6];
                                    
                    if (!string.IsNullOrEmpty(rowData[3]))
                    {
                        briefCountryMap = new BriefCountryMap();
                        briefCountryMap.CountryName = rowData[3];
                        briefCountryMap.wTABriefs.Add(wTABrief);
                        brief.briefCountryMaps.Add(briefCountryMap);
                    }
                    else
                    {
                        briefCountryMap.wTABriefs.Add(wTABrief);
                    }

                    if (!string.IsNullOrEmpty(rowData[0]) || rowData[0] == "WTA")
                    {
                        brief.Year = _year;
                        brief.Month = _month;
                        brief.PubDate = pubDate;
                        briefList.Add(brief);
                    }
                }
                
                _context.Briefs.AddRange(briefList);
                _context.SaveChanges();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                var json = JsonSerializer.Serialize(brief, options);

                return Ok(json);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
