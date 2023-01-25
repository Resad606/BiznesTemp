using System.ComponentModel.DataAnnotations;

namespace Business.Areas.manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength:50)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 50,MinimumLength =8)]
        [DataType(DataType.Password)]   

        public string Password { get; set; }

    }
}
