//   message is set non-CRUDable.


using AdminDBHandler.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.Generated
{
    public class Message
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MessageId { get; set; }
        public string status { get; set; }
        public string connectionId { get; set; }
        public Connection connection { get; set; }
        public int SenderId { get; set; }
        public Users Sender { get; set; }
        public DateTime DateTime { get; set; }
        public string Message_json { get; set; }
    }
}
