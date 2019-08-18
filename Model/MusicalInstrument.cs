using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class MusicalInstrument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên Nhạc Cụ")]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Giới thiệu")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Required]
        public string ImagePath { get; set; }
    }
}
