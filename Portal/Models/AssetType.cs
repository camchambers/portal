using System;
using System.ComponentModel.DataAnnotations;

namespace portal.Models
{
    public class AssetType
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public AssetType()
        {
        }
    }
}
