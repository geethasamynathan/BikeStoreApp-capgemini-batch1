using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp_BackEnd.DTO
{
    public class UserLoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
