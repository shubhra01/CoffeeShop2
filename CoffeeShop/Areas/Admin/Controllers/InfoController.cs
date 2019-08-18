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
    [Route("Admin/[controller]")]
    [ApiController]
    public class InfoController : Controller
    {
        private readonly CoffeeContext _context;

        public InfoController(CoffeeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var getListInfo= await _context.Infos.ToListAsync();
            return View(getListInfo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] Info info)
        {
            try
            {
                
                _context.Infos.Add(info);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        public IActionResult Edit(int id)
        {
            return View(GetById(id));
        }
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Edit(Info item)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            _context.Update(item);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Index", Areas{ "Admin"})
                 
        //        }
        //        var info = getList().Select(x=>x.Id==info.)
        //        if (info == null)
        //        {
        //            return BadRequest();
        //        }
        //        //welcome.Id = item.Id;
        //        info.ImagePath = it.ImagePath;

            


        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //    return Ok();

        //}


    
        public Info GetById(int id)
        {
            var info = getList().FirstOrDefault(p => p.Id == id);

            if (info == null)
            {
                return null;
            }

            return info;
        }

        private IList<Info> getList()
        {
            return _context.Infos.ToList();
        }
    }
}