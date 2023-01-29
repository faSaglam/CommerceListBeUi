using Core.Entities;

namespace Entitites.Concrete.ViewModels
{
    public class ProductListViewModel : IViewModel
    { 
        public string ProductName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
