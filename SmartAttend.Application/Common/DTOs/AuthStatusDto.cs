using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Application.Common.DTOs
{
    public class AuthStatusDto
    {
        public bool IsAuthenticated { get; set; }
        public bool IsMfaSatisfied { get; set; }
        public DateTime? TokenExpiresAt { get; set; }
        public int? ExpiresInSeconds { get; set; }
        public string Message { get; set; }
    }
}
