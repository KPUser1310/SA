using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.DTOs
{
    public class PartDtos
    {
        [Required(ErrorMessage = "Part Number is required.")]
        public string PartNumber { get; set; }

        [Required(ErrorMessage = "Group ID is required.")]
        public string GroupID { get; set; }

        [Required(ErrorMessage = "Cavity is required.")]
        public int? Cavity { get; set; }

        [Required(ErrorMessage = "Cycle Time is required.")]
        public decimal? CycleTime { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Part Price is required.")]
        public decimal? PartPrice { get; set; }

        public decimal? ScrapPrice { get; set; }

    }

}
