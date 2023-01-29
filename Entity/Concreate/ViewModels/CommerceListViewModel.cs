using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CommerceListViewModel:IViewModel
    {
        public int CommerceListID { get; set; }
        public string? CommerceListName { get; set; }

        public bool IsOnMarket { get; set; }

    }
}
