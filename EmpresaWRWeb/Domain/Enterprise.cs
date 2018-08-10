using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaWRWeb.Domain
{
    public class Enterprise
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string City { get; set; }
        
        public string Address { get; set; }
        
        public int? StaffNumber { get; set; }
        
        public decimal? AnualProfit { get; set; }
    }
}
