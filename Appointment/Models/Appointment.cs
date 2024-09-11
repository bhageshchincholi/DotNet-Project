using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointment.Models
{
    [Table("Appointment")]
    public class Appointments
    {
        [Column(name:"Id",TypeName ="int")]
        [Key]
        public int Id { get; set; }
        [Column(name:"first_name",TypeName ="varchar")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }
        [Column(name: "last_name", TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Column(name:"dateOfBiirth",TypeName ="date")]
        public DateTime DateOfBirth { get; set; }

        [Column(name: "appointmentDate", TypeName = "date")]
        public DateTime AppointmentDate { get; set; }
    }
}
