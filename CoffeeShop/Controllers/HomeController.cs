using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Areas.Admin.Data;
using Model;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoffeeContext _context;
        public HomeController(CoffeeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
                  
       
            return View();

        }

        [HttpGet]
        public IActionResult GetWelCome()
        {
            return View(_context.Welcomes.ToList());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //private async Task<IEnumerable<Welcome>> GetWelCome()
        //{

        //    var getWelCome = await _context.Welcomes.ToListAsync();
        //    return getWelCome;

        //}
        private async Task<string> getListWelCome()
        {
            var getListWelCome =  await _context.Welcomes.ToListAsync();

            var result = "<section class='home-slider owl-carousel'>";
            foreach (var item in getListWelCome)
            {
                result += "<div class='slider-item' style='background-image: url(" + item.ImagePath + ");'>";
                result += "<div class='overlay'></div>";
                result += "<div class='container'>";
                result += "<div class='row slider-text justify-content-center align-items-center' data-scrollax-parent='true'>";
                result += "<div class='col-md-8 col-sm-12 text-center ftco-animate'>";
                result += "<span class='subheading'>Chào Mừng</span>";
                result += "<h1 class='mb-4'>" + item.Name + "</h1>";
                result += "<p class='mb-4 mb-md-5'>" + item.Status + "</p>";
                result += "<p><a href='/Home/Index' class='btn btn-primary p-3 px-xl-4 py-xl-3'>Order Now</a> <a href='#' class='btn btn-white btn-outline-white p-3 px-xl-4 py-xl-3'>View Menu</a></p>";
                result += "</div></div></div></div>";
            }
            result += "</section>";
            return result;
        }

        private async Task<string> getSellers()
        {
            var getListWelCome = await _context.MusicalInstruments.ToListAsync();
            var result = "<section class='ftco-section'>";
            result += "<div class='container'>";
            result += "<div class='row justify-content-center mb-5 pb-3'>";
            result += "<div class='col-md-7 heading-section ftco-animate text-center'";  
            result += "<span class='subheading'>Discover</span>";
            result += "<h2 class='mb -4'>Best Coffee Sellers</h2>";
            result += "<p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts.</p>";
            result += "</div></div>";
            result += "<div class='row'>";
            foreach (var item in getListWelCome)
            {

                result += "<div class='col-md-3'>";
                result += "<div class='menu-entry'>";
                result += "<a href='#' class='img' style='background-image: url("+item.ImagePath+");'></a>";
                result += "<div class='text text-center pt-4'>";
                result += "<h3><a href='#'>"+item.Name+"</a></h3>";
                result += "<p>" + item.Content + "A small river named Duden flows by their place and supplies</p>";
                result += "<p class='price'><span> $" + item.Price + " </span></p>";
                result += "<p><a href='#' class='btn btn-primary btn-outline-primary'>Add to Cart</a></p>";
                result += "</div></div></div>";


            }
            result += "</div></div></section>";
            return result;
        }

    }
}
