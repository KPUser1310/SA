using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.DTOs
{
    public class PartDtos
    {
        public string PartNumber { get; set; }
        public string GroupID { get; set; }
        public int? Cavity { get; set; }
        public decimal? CycleTime { get; set; }
        public string Description { get; set; }
        public decimal? PartPrice { get; set; }
        public decimal? ScrapPrice { get; set; }
      
    }

}
