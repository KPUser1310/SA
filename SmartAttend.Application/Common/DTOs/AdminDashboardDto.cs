using System.Collections.Generic;

namespace SmartAttend.Application.Common.DTOs
{
    public class AdminDashboardDto
    {
        public IReadOnlyList<CustomerDto> Customers { get; set; }
            = new List<CustomerDto>();
    }
}
