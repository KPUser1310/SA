using SmartAttend.Application.Production.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Parts.DTOs
{
    public class AssignedPartsResponseModel
    { 
        public bool IsSuccess { get; set; }
        public string Message { get; set; } 
        public List<AssignedPartsDtos> AssignedPartDetails { get; set; }
        public List<UpdateAssignedPartDtos> UpdateAssignedPartDetails { get; set; }
    }
}
