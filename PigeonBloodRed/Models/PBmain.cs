using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PigeonBloodRed.Models
{
    public class PBmain
    {
        [Key]
        public int EdID { get; set; }

        public string Chapters { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Profile { get; set; }

     

    }
}