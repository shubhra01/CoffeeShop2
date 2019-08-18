using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Areas.Admin.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace CoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public APIController(CoffeeContext context) => _context = context;
    

        [HttpGet]
        [Route("GetWelCome")]

        //public async Task<IEnumerable<Welcome>> GetWelCome()
        //{
        //    var getListWelCome =await _context.Welcomes.ToListAsync();
        //    List<Welcome> welcomes = new List<Welcome>();
        //    foreach(var item in getListWelCome)
        //    {
        //        welcomes.Add(new Welcome { Id = item.Id, ImagePath = item.ImagePath, Name = item.Name, Status = item.Status });
        //    }
        //    return welcomes;
        //}
        public async Task<ActionResult<IEnumerable<Welcome>>> GetWelCome() => await _context.Welcomes.ToListAsync();

        //public async Task<IActionResult> GetWelCome()
        //{

        //    return jsp
        //}
    }
}