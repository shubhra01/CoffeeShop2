using CoffeeShop.Areas.Admin.Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    public class Serives
    {
        private readonly CoffeeContext _context;
        
        public Serives(CoffeeContext context)
        {
            _context = context;
        }
        public IList<Welcome> GetWelCome()
        {

            var getWelCome = _context.Welcomes.ToList();
            return getWelCome;

        }

        public IList<MusicalInstrument> GetSellers()
        {
            return _context.MusicalInstruments.ToList();
        }
        public  IList<Info> GetInfo()
        {
            return  _context.Infos.ToList();
        }
        public IList<Drink> GetDrink()
        {
            return _context.Drinks.ToList();
        }
    }
}
