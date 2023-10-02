using System.ComponentModel.DataAnnotations;

namespace webapi.health_clinic.manha.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email de Usuario")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha de Usuario obrigatório")]
        public string Senha { get; set; }
    }
}
