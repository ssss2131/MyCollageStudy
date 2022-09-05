using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;

namespace WTM.VoteSystem.ViewModel.HomeVMs
{
    public class LoginVM : BaseVM
    {
        [Display(Name = "您的账号")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ITCode { get; set; }

        [Display(Name = "您的密码")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Password { get; set; }

        [Display(Name = "_Admin.Tenant")]
        public string Tenant { get; set; }

        [Display(Name = "记住我")]
        public bool RememberLogin { get; set; }

        private string _redirect;
        public string Redirect
        {
            get
            {
                var rv = _redirect;
                if (string.IsNullOrEmpty(rv) == false)
                {
                    if (rv.StartsWith("/#") == false)
                    {
                        rv = "/#" + rv;
                    }
                    if(rv.Split("#/").Length > 2)
                    {
                        int index = rv.LastIndexOf("#/");
                        rv = rv.Substring(0, index);
                    }
                }
                return rv;
            }
            set { _redirect = value; }
        }

        [Display(Name = "Login.InputValidation")]
        public string VerifyCode { get; set; }

    }

}
