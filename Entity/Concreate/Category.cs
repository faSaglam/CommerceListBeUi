using Core.Entities;

namespace Entitites.Concrete
{
    public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; } //one-to-many
      
    }
}
