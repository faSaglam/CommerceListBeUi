using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CategoryListDetailedViewModel:IViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } 
        
    }
}
