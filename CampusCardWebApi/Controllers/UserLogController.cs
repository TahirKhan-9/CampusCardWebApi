using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusCardWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        int pageSize = 1000;
        public UserLogController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<V_UserLog_WebAPI> Get(int month = 01, int Year = 2023, int Date = 1 )
        {
            IEnumerable<V_UserLog_WebAPI> cache = V_UserLog_WebAPI.ConvertDataTable<V_UserLog_WebAPI>(V_UserLog_WebAPI.GetAllTimes(_configuration));
            IEnumerable<V_UserLog_WebAPI> cache2= cache.Where(x => x.Date.Month == month).Where(x => x.Date.Year == Year).ToList();

            var totalcount = cache2.Count();
            var totalpages = (int)(totalcount / pageSize);
            var productPerPage = cache2
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            return productPerPage;

        }
        //public IEnumerable<V_UserLog_WebAPI> Get(int page = 1, int pageSize = 10)
        //{
        //    IEnumerable <V_UserLog_WebAPI> cache = V_UserLog_WebAPI.ConvertDataTable<V_UserLog_WebAPI>(V_UserLog_WebAPI.GetAllTimes(_configuration));
        //    var totalcount = cache.Count();
        //    var totalpages = (int)(totalcount / pageSize);
        //    var productPerPage = cache
        //        .Skip((page - 1) * pageSize)
        //        .Take(pageSize).ToList();

        //    return productPerPage;

        //}
    }
}
