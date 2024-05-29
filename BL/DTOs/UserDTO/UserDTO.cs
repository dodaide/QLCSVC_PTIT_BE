namespace Application.DTOs.UserDTO;

public class UserDTO
{
    public int UserID { get; set; } 
    public int UserType { get; set; } 
    public string Fullname { get; set; }
    public string LoginName { get; set; }
    public string Password { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedTime { get; set; }
}