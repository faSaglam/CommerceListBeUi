using Core.Entities;

namespace Entitites.Concrete
{
    public class ProductCommerceList:IEntity
    {
        public int ProductID { get; set; }
        public int CommerceListID { get; set; }

        public string Description { get; set; }

        public bool IsBought { get; set; }  
        public Product? Product { get; set; }
        public CommerceList? CommerceList { get; set; }
          

    }
}
