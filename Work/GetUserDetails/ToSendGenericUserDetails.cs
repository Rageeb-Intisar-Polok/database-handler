using AdminDBHandler.Models.User;
using DatabaseHandler.Models_and_repositories.User.User_Types;
using DatabaseHandler.Models_and_repositories.User.User_Types.User_Type_Generic_Repository;

namespace DatabaseHandler.Work.GetToSendGenericUserDetails
{
  //  public class ToSendGenericUserDetails<T> : IToSendGenericUserDetails<T> where T : class
    public class ToSendGenericUserDetails : IToSendGenericUserDetails
    {
        public int IndividualId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    //    public T _specificTypeUser { get; set; }
        public string UserType { get; set; } = "Unknown";
        public string[] details { get; set; }
        
    }
}
