namespace Task9.Entities
{
    public class User
    {

        public int IdUser { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}
