using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace portal.Models
{
    [NotMapped]
    public partial class Search
    {
        public int SearchTerm { get; set; }
        public List<Application> ApplicationSearch { get; set; }
        public List<IdentityUser> UserSearch { get; set; }
        public List<Asset> AssetSearch { get; set; }
    }
}
