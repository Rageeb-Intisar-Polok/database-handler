using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseHandler.Models.Generated
{
    public class Connection
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ConnectionId { get; set; }
        public string LastMessageId { get; set; }
        public string ConnectedUsers_json { get; set; }
    }
}
