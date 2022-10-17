using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeDTO.Account
{
    public class AccountDTO
    {
        [Required(ErrorMessage = "firstName is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "lastName is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "userName is required")]
        public string? UserName { get; set; }
        public int AccountId { get; set; }
    }
}
