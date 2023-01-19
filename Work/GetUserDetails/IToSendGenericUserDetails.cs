namespace DatabaseHandler.Work.GetToSendGenericUserDetails
{
   //  public interface IToSendGenericUserDetails<T> where T : class
    public interface IToSendGenericUserDetails
    {
        public int IndividualId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
   //     public T _specificTypeUser { get; set; }
        public string UserType { get; set; }
        public string[] details { get; set; }  
    }
}
