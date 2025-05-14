using CampusCardWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCardWebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/UserTrans")]
    [ApiController]
    public class UserTransController : ControllerBase
    {
        public static ApplicationDbContext context;
        public readonly IConfiguration _configuration;
        public static List<tbl_Attendance> lst_trans = new List<tbl_Attendance>();

        public UserTransController(IConfiguration configuration , ApplicationDbContext _context)
        {
            context = _context;
            _configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<tbl_Attendance> Get()
        {
            return lst_trans = tbl_Attendance.ConvertDataTable<tbl_Attendance>(tbl_Attendance.GetAllTimes(_configuration)); 
            
            //SqlConnection con = new SqlConnection(_configuration.GetConnectionString("FasConString").ToString());
            //SqlDataAdapter sda = new SqlDataAdapter("Select * from tbl_Attendance", con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //return Enumerable
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }

    
}
