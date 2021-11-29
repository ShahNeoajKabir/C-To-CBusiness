using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Enum
{
    public class Enum
    {
        public enum AvailableStatus
        {
            Active = 1,
            Inactive = 2,
            Delete = 3,
        }

        public enum ProductCondition
        {
            Used=1,
            New=2
        }
    }
}
