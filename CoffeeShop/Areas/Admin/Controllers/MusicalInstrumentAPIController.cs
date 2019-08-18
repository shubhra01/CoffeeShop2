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
    public class MusicalInstrumentAPIController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public MusicalInstrumentAPIController(CoffeeContext context) => _context = context;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MusicalInstrument>>> Get()
        {
            var getListWelCome = await _context.MusicalInstruments.ToListAsync();
            return getListWelCome;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MusicalInstrument>> Create([FromBody] MusicalInstrument musical)
        {
            try
            {
                //welcome.Id = getList().Any() ? getList().Max(p => p.Id) + 1 : 1;
                _context.MusicalInstruments.Add(musical);
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
        public async Task<IActionResult> Put(int id, [FromBody] MusicalInstrument item)
        {


            try
            {
                var musical = getList().FirstOrDefault(p => p.Id == id);
                if (musical == null)
                {
                    return BadRequest();
                }
                //welcome.Id = item.Id;
                musical.Name = item.Name;
                musical.ImagePath = item.ImagePath;
                musical.Content = item.Content;
                musical.Price = item.Price;

                _context.Update(musical);
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
                var musical = getList().FirstOrDefault(p => p.Id == id);
                if (musical == null)
                {
                    return BadRequest();
                }

                _context.Remove(musical);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<MusicalInstrument> GetById(int id)
        {
            var musical = getList().FirstOrDefault(p => p.Id == id);

            if (musical == null)
            {
                return NotFound();
            }

            return musical;
        }
        private IList<MusicalInstrument> getList()
        {
            return _context.MusicalInstruments.ToList();
        }

    }
}