namespace BookStore.DTOS;

public class RegistrationDto
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [Compare("ConfirmPassword")]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}
