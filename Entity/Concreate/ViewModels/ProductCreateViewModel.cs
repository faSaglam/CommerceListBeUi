using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class ProductCreateViewModel:IViewModel
    {
        public string ProductName { get; set; }
        public  int Category { get; set; }
        public string PhotoUrl { get; set; }
    }

}
