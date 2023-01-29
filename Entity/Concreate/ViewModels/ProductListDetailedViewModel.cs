using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class ProductListDetailedViewModel:IViewModel
    {
        public int ProductId { get; set; }  
        public string ProductName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
