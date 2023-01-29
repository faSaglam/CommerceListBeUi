using Core.Entities;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate.ViewModels
{
    public class CreateRoleViewModel:IViewModel
    {
       
            public string Name { get; set; } = default!;
        
    }
}
