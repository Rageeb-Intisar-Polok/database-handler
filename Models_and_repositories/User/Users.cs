using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDBHandler.Models.User
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndividualID { get; set; }
        public string UserType { get; set; } = "Unknown";
        public string ID { get; set; } = "Unknown";
        public string Name { get; set; } = "Unknown";
        public string Email { get; set; } = "Unknown";
        public string Phone { get; set; } = "Unknown";
        public string ConnectionListAndLastMessage_json { get; set; } = "Unknown";
    }
}
