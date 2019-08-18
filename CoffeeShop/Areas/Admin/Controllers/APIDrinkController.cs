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
    public class APIDrinkController : ControllerBase
    {
        private readonly CoffeeContext _context;

        public APIDrinkController(CoffeeContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<Drink>> GetDrinks()
        {
           var result= await _context.Drinks.ToListAsync();
            return result;
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
        public async Task<ActionResult<Drink>> Edit([FromRoute] int id ,[FromBody] Drink model)
        {
            try
            {
                var drink= getById(id);
                if (drink == null)
                {
                    return BadRequest();
                }
                //welcome.Id = item.Id;
                drink.Name = model.Name;
                drink.ImagePath = model.ImagePath;
                drink.Content = model.Content;
                drink.Price = model.Price;

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
        public async Task<ActionResult<Drink>> Delete([FromRoute] int id, [FromBody] Drink model)
        {
            try
            {
                var drink = getById(id);
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
        private Drink getById(int id)
        {
            var result = _context.Drinks.ToList().FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}