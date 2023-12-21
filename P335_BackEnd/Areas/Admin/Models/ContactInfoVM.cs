namespace P335_BackEnd.Areas.Admin.Models
{
    public class ContactInfoVM
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }
    }
}
