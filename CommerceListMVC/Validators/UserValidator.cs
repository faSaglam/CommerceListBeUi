


using Entitites.Concrete.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CommerceListMVC.Validators
{
    public class UserValidator :AbstractValidator<UserRegisterViewModel>
    {
    
        public UserValidator() {
            RuleFor(u => u.FirstName).NotNull().WithMessage("İsim boş olamaz").NotEmpty().MaximumLength(30)
                .WithMessage("30 Karakterden fazla olamaz"); 
            RuleFor(u => u.LastName).NotNull().WithMessage("Soyad boş olamaz").NotEmpty().MaximumLength(30)
                .WithMessage("30 Karakterden fazla olamaz");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Bir mail adresi giriniz");
            //RuleFor(u => u.Password).NotEmpty()
            //    .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
            //    .Matches(@"[A-Z]+").WithMessage("En az bir adet büyük karakter içermilidir.")
            //    .Matches(@"[a-z]+").WithMessage("En az bir adet küçük  karakter içermilidir.")
            //     .Matches(@"[0-9]+").WithMessage("En az bir ader rakat içermelidir");
            //RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş olamaz").Must(IsPasswordValid)
            //    .WithMessage("Parolanız en az bir büyük ve küçüf harf ve bir ader rakam içermelidir");

            RuleFor(u => u.ConfirmPassword).Equal(x => x.Password).WithMessage("Şifreler uyuşmuyor");
        
       
        }
        //private bool IsPasswordValid(string arg)
        //{
        //    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
        //    return regex.IsMatch(arg);
        //}
    }
}
