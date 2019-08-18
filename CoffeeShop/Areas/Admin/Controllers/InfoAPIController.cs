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
    public class InfoAPIController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public InfoAPIController(CoffeeContext context) => _context = context;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Info>>> Get()
        {
            var getListDrink = await _context.Infos.ToListAsync();
            return getListDrink;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Info>> Create([FromBody] Info info)
        {
            try
            {
                //welcome.Id = getList().Any() ? getList().Max(p => p.Id) + 1 : 1;
                _context.Infos.Add(info);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] Info  item)
        {


            try
            {
                var info = getList().FirstOrDefault(p => p.Id == id);
                if (info == null)
                {
                    return BadRequest();
                }
                //welcome.Id = item.Id;
                info.ImagePath = item.ImagePath;

                _context.Update(info);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var info = getList().FirstOrDefault(p => p.Id == id);
                if (info == null)
                {
                    return BadRequest();
                }

                _context.Remove(info);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Info> GetById(int id)
        {
            var info = getList().FirstOrDefault(p => p.Id == id);

            if (info == null)
            {
                return NotFound();
            }

            return info;
        }
        private IList<Info> getList()
        {
            return _context.Infos.ToList();
        }
    }
}