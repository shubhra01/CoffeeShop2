﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class AdminController : Controller
    {
        

        [Route("admin")]
        public IActionResult Index()
        {
            
            return View();
        }


        
      
   
    }
}