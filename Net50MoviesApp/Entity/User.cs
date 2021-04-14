namespace Net50MoviesApp.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserImg { get; set; }
        public Person Person { get; set; }
        //public int StaffId { get; set; }
    }
}
