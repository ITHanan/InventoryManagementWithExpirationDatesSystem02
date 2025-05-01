using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ACommen.DTOs
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public required string ItemName { get; set; }
        public string Category { get; set; }
        public required decimal UnitPrice { get; set; }
    }
}
