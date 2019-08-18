using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Welcome
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cảm nhận")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Đường dẫn")]
        public string ImagePath { get; set; }

        [Required]
        [Display(Name ="Đề tài")]
        public string Name { get; set; }
    }
}
