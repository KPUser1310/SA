using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAttend.Domain.Interface
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; }

    }
}
