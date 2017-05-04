using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAPI.Models
{
    public class Member
    {
		[Key]
	    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
	    public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int level { get; set; }
        public string deviceToken { get; set; }
        public string code { get; set; }
    //    public Phone phone { get; set; }
    }
}
