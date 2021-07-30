using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class Asset
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Type")]
        public string AssetType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        [DisplayName("Memory (GB)")]
        public int? Memory { get; set; }
        [DisplayName("Storage (GB)")]
        public int? Storage { get; set; }
        public string Comment { get; set; }
        [DisplayName("Owner")]
        public string UserID { get; set; }

        public Asset()
        {
        }
    }
}
