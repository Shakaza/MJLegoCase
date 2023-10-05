using System.ComponentModel.DataAnnotations;

namespace LegoCase.Database.Users;

public class User : BaseEntity
{
    [Key]
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
