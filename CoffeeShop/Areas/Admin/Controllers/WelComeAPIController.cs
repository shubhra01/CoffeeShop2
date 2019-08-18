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
    public class WelComeAPIController : ControllerBase
    {
        private readonly CoffeeContext _context;
        public WelComeAPIController(CoffeeContext context) => _context = context;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Welcome>>> Get()
        {
            var getListWelCome = await _context.Welcomes.ToListAsync();
            return getListWelCome;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Welcome>> Create([FromBody] Welcome welcome)
        {
            try
            {
                //welcome.Id = getList().Any() ? getList().Max(p => p.Id) + 1 : 1;
                _context.Welcomes.Add(welcome);
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
        public async Task<IActionResult> Put(int id, [FromBody] Welcome item)
        {


            try
            {
                var welcome = getList().FirstOrDefault(p => p.Id == id);
                if (welcome == null)
                {
                    return BadRequest();
                }
                //welcome.Id = item.Id;
                welcome.Name = item.Name;
                welcome.ImagePath = item.ImagePath;
                welcome.Status = item.Status;

                _context.Update(welcome);
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
                var welcome = getList().FirstOrDefault(p => p.Id == id);
                if (welcome == null)
                {
                    return BadRequest();
                }

                _context.Remove(welcome);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Welcome> GetById(int id)
        {
            var welcome = getList().FirstOrDefault(p => p.Id == id);

            if (welcome == null)
            {
                return NotFound();
            }

            return welcome;
        }
        private IList<Welcome> getList()
        {
            return _context.Welcomes.ToList();
        }

    }
}