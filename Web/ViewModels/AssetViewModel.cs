using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Domains;
using System.ComponentModel.DataAnnotations;
namespace Web.ViewModels
{
    public class AssetViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [MaxLength(200)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Initial Count")]
        public int InitCount { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        public AssetViewModel(Asset asset)
        {
            Id = asset.Id;
            Name = asset.Name;
            Description = asset.Description;
            InitCount = asset.InitCount;

        }

        public AssetViewModel()
        {

        }
    }
}