

using Core.Entities;
using Entities.Concreate;

namespace Entitites.Concrete.ViewModels
{
    public class CategoryDetailViewModel:IViewModel
    {
        //public List<Product>? Products { get; set; }

        public string ProductName { get; set; }
        public string PhotoUrl { get; set; }


    }
}
