namespace DatabaseHandler.VisibleModels_to_addNewUser.Users
{
    public class Visible_student
    {
        public string ID { get; set; } = "Unknown";
        public string Name { get; set; } = "Unknown";
        public string Email { get; set; } = "Unknown";
        public string Phone { get; set; } = "Unknown";



        public string Dept { get; set; }
        public int level { get; set; }
        public string term { get; set; }
    }
}
