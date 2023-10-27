using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AbautID { get; set; }
        public string AbautDetails1 { get; set; }
        public string AbautDetails2 { get; set; }
        public string AbautImage1 { get; set; }
        public string AbautImage2 { get; set; }
        public string AbautMapLocation { get; set; }
        public bool AbautStatus { get; set; }
    }
}
