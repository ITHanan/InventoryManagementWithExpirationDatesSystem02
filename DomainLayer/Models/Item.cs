using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Category { get; set; }

        public decimal? UnitPrice { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; } //= new List<Stock>();
    }

}
