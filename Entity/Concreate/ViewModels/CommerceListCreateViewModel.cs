using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CommerceListCreateViewModel:IViewModel
    {
        public string? Id { get; set; }

        public string? CommerceListName { get; set; }
    }
}
