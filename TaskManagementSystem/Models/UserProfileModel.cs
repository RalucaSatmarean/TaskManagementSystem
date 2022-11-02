namespace TaskManagementSystem.Models
{
    public class UserProfileModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
    }
}
