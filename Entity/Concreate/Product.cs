using Core.Entities;

namespace Entitites.Concrete
{
    public class Product:IEntity
    {
        public Product() { 
        CommerceLists = new HashSet<ProductCommerceList>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public string Description { get; set; }
        public int CategoryID { get; set; }
        public string PhotoUrl { get; set; }
        public Category Category { get; set; }  //one-to-many
        public ICollection<ProductCommerceList>? CommerceLists { get; set; }
    }
}
