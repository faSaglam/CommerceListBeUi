using Core.Entities;

namespace Entitites.Concrete
{
    public class CommerceList:IEntity
    {
        public CommerceList()
        {
           
            Products = new HashSet<ProductCommerceList>();  
        }
        public int CommerceListID { get; set; }
        
        public string? Id { get; set; } 

        public string? CommerceListName { get;set; }

        public bool IsOnMarket { get; set; }
        public User Users { get; set; }
        public ICollection<ProductCommerceList>? Products { get;set; }
    
    }
}
