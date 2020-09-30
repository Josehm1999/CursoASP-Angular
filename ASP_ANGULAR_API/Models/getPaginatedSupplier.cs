using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ANGULAR_API.Models
{
    public class getPaginatedSupplier
    {
        public int Page { get; set; }
        public int Rows { get; set; }
        public string searchTerm{ get; set; }
    }
}
