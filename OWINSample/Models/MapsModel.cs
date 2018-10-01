using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OWINSample.Models
{
    public class MapsModel
    {
        [Display(Name = "MapsKey")]
        public string MapsKey { get; set; }
    }
}