using SmartAttend.Application.Production.DTOs;
using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.DTOs
{
    public class PartResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int PartId { get; set; }
    public List<SmartAttend.Domain.Entities.AssignedPart> LstAssignedPart { get; set; }
        public AssignedPart assignedPart { get; set; }
        public List<Part> lstPart { get; set; }
        public List<AssignedPartsModel> LstAssignedPartModel { get; set; }
        public List<AssignedPartsDtos> ListAssignedPartModel { get; set; }      
            
         public List<PartModel> LstPartModel { get; set; }
    }

    public class AssignedPartsModel
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public long DeviceID { get; set; }
        public int Cavity { get; set; }
        public string CycleTime { get; set; }
        public int RequiredQuantity { get; set; }
        public int CompletedQuantity { get; set; }
        public string StartDateTime { get; set; }
        public string EndDateTime { get; set; }
        public string RunningDuration { get; set; }
        public string ETA { get; set; }
        public int Scrap { get; set; }
        public string AssignedPartDate { get; set; }
        public string CalculatedCycleTime { get; set; }
        public Int32? Efficiency { get; set; }
        public Int32? QtyPercentage { get; set; }
        public bool Status { get; set; }
        public string GroupID { get; set; }
        public Int32 GrossQty { get; set; }
        public int? DowntimeDurationID { get; set; }
        public string DowntimeDuration { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string PartNumber { get; set; }
        public string DeviceName { get; set; }
    }

    public class PartModel
    {
        public int PartId { get; set; }
        public string GroupID { get; set; }
        public string PartNumber { get; set; }
        public int Cavity { get; set; }
        public int? CustomerID { get; set; }
        public string CycleTime { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? PartPrice { get; set; }
        public string ScrapCount { get; set; }
        public DateTime? StartDateTime { get; set; }
        public long DeviceID { get; set; }
        public int ScrapPartID { get; set; }
    }
}
