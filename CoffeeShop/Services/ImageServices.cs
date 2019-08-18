﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace CoffeeShop.Services
{
    public class ImageServices : IImageServices
    {
        public static Random random = new Random(55);
        public ImageServices() { }
        public string CreateImage(IFormFile file, IHostingEnvironment _env)
        {
            string fileDefault = AppConstant.ImagePath;
            string relativePath = "";
            if (file != null)
            {

                int randomId = ImageServices.random.Next(56, 1000);
                var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
                relativePath = Path.Combine(fileDefault, fileName);
                var absolutePath = Path.Combine(_env.WebRootPath, relativePath);

                using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return relativePath;
            }
            return null;
        }
      

        public string EditImage(IFormFile file, string imageUrl, IHostingEnvironment env)
        {
            string fileDefault = AppConstant.ImagePath;
            if (file != null)
            {
                string relativePath = "";
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    var oldPath = Path.Combine(env.WebRootPath, imageUrl);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                int randomId = ImageServices.random.Next(56, 1000);
                var fileName = $"{randomId}{Path.GetFileName(file.FileName)}";
                relativePath = Path.Combine(fileDefault, fileName);
                var absolutePath = Path.Combine(env.WebRootPath, relativePath);

                using (FileStream stream = new FileStream(absolutePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return relativePath;

            }
            return null;
        }

  

        //Delete a single image
        public bool DeleteImage(string ImageUrl, IHostingEnvironment _env)
        {
            if (string.IsNullOrEmpty(ImageUrl))
            {
                ImageUrl = "";
            }
            var oldPath = Path.Combine(_env.WebRootPath, ImageUrl);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
                return true;
            }
            return false;
        }

        //Delete multiple images


    }
}
