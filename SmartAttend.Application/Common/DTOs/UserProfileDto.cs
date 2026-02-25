using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.DTOs
{
    public class UserProfileDto
    {
        
            public int AccountId { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? EmailAddress { get; set; }
            public int UserRoleId { get; set; }
            public int? CustomerId { get; set; }
            public string? AzureObjectId { get; set; }
        
    }
}
