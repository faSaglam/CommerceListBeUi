using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Entitites.Concrete
{
    public class User: IdentityUser, IEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
 

        public ICollection<CommerceList>? CommerceLists { get; set; }
    }

}
