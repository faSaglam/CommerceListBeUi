using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class MarketListDetailViewModel:IViewModel
    {
        public int CommerceListId { get; set; }
        public string? PhotoUrl { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }
        public bool IsBought { get; set; }   
    }
}
