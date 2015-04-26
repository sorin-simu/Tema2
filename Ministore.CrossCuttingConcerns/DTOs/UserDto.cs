namespace Ministore.CrossCuttingConcerns.DTOs
{
    public class UserDto
    {
        public System.Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
    }
}
