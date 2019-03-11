using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please input a product name")]
        public string Title { get; set; }
    }
}