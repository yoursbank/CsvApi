using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using GenericApi.Domain;
using static System.Environment;


namespace GenericApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class csvController : ControllerBase
{
    [HttpGet("read")]
    public ActionResult<Cards> GetAll()
    {
        try
        {
            // file path
            string path = GetFolderPath(SpecialFolder.Personal);
            Console.WriteLine(path);
            string file = $"{path}/Developer/C#/CsvApi/all.csv";

            if (!System.IO.File.Exists(file))
            {
                return NotFound("Csv file was not found");
            }
            
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Ignore header validation
                HeaderValidated = null,
            };
            using (var reader = new StreamReader(file))
                using (var csv = new CsvReader(reader, configuration))
                {
                    List<Cards> records = csv.GetRecords<Cards>().ToList().FindAll(c => c.cartaoVirtual == "0" & c.statusCartao == "Bloqueado Senha Incorreta");
                    
                    var response = new
                    {
                        Count = records.Count,
                        Data = records
                    };
                    
                    return Ok(response);
                }
        }
        catch (Exception ex)
        {
            return BadRequest($"Error reading CSS file: {ex.Message}");
        }
    }
}