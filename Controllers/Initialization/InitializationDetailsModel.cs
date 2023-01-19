namespace DatabaseHandler.Controllers.Initialization
{
    public class InitializationDetailsModel
    {
        public HashSet<string> departments { get; set; }
        public int level_count { get; set; }
        public SortedSet<string> terms { get; set; }
        public SortedSet<string> roles { get; set; }
    }
}
