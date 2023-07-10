using System.ComponentModel.DataAnnotations;

namespace Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
