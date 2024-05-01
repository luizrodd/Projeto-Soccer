namespace APIzinha.Entitites
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public bool isAdmin { get; set; }
    }
}
