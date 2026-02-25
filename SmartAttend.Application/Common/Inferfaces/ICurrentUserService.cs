using SmartAttend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.Inferfaces
{
    public interface ICurrentUserService
    {
        int AccountId { get; }
        int UserRoleId { get; }
        int? CustomerId { get; }
        string AzureObjectId { get; }
        bool IsAuthenticated { get; }
        string CorrelationId { get; }
    }

}
