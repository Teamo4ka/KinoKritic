namespace KinoKritic.BLL.Dtos
{
    public class Profile
    {
        public string UserId { get; set; }
        public string Username { get; set; }

        public string DisplayName { get; set; }

        public string Bio { get; set; }

        public string Image { get; set; }
        

        public PhotoDto Photo { get; set; }
    }
}