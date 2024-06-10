using System.Collections.Generic;

namespace Usey.Models
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public List<Product> ExpiringProducts { get; set; }
    }
}
