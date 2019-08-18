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
    public class DrinkAPIController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public DrinkAPIController(CoffeeContext context) => _context = context;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Drink>>> Get()
        {
            var getListDrink = await _context.Drinks.ToListAsync();
            return getListDrink;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Drink>> Create([FromBody] Drink drink)
        {
            try
            {
                //welcome.Id = getList().Any() ? getList().Max(p => p.Id) + 1 : 1;
                _context.Drinks.Add(drink);
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
        public async Task<IActionResult> Put(int id, [FromBody] Drink item)
        {


            try
            {
                var drink = getList().FirstOrDefault(p => p.Id == id);
                if (drink == null)
                {
                    return BadRequest();
                }
                //welcome.Id = item.Id;
                drink.Name = item.Name;
                drink.ImagePath = item.ImagePath;
                drink.Content = item.Content;
                drink.Price = item.Price;

                _context.Update(drink);
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
                var drink = getList().FirstOrDefault(p => p.Id == id);
                if (drink == null)
                {
                    return BadRequest();
                }

                _context.Remove(drink);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<Drink> GetById(int id)
        {
            var drink = getList().FirstOrDefault(p => p.Id == id);

            if (drink == null)
            {
                return NotFound();
            }

            return drink;
        }
        private IList<Drink> getList()
        {
            return _context.Drinks.ToList();
        }
    }
}