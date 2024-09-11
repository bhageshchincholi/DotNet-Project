using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    [Table(name:"users")]

    public class User
    {
        [Column(name:"id",TypeName ="int")]
        [Key]
        public int Id { get; set; }

        [Column(name:"name",TypeName ="varchar")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(name:"email",TypeName ="varchar")]
        [StringLength(100)]
        public string Email { get; set; }

        

        [Column(name: "password", TypeName = "varchar")]
        [StringLength(100)]
        public string Password { get; set; }
    }
}
