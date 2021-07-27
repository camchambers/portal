using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public partial class Application
    {
        [Key]
        public int Aid { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int? Weight { get; set; }
        public bool? Disabled { get; set; }
    }
}
