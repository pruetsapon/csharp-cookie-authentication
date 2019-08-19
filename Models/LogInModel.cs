using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Identity.Models
{
    public class LogInModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}