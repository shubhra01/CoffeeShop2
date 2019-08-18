using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public interface IImageServices
    {
        string CreateImage(IFormFile file, IHostingEnvironment _env);
       

        string EditImage(IFormFile file, string imageUrl, IHostingEnvironment env);

   
        bool DeleteImage(string ImageUrl, IHostingEnvironment _env);
      
    }
}
