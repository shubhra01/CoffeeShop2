using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Info
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Đường Dẫn")]
        public string ImagePath { get; set; }


    }
}
