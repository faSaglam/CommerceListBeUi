using Core.Entities;

namespace Entitites.Concrete.ViewModels
{
    public class UserRegisterViewModel : IViewModel
    {
        //public string UserName { get; set; }    
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string ConfirmPassword { get; set; }

    }
}
