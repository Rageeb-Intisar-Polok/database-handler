using DatabaseHandler.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDBHandler.Models.Dept_Level_Term
{
    public class Level_Term
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelTerm_id { get; set; }
        public int Level { get; set; }
        public string Term { get; set; }
    }
}
