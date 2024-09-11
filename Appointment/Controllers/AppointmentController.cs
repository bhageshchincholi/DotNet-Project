using Appointment.Interfaces;
using Appointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Appointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointment appointment ;

        public AppointmentController(IAppointment appointment)
        {
            this.appointment = appointment;
        }


        // GET: api/<AppointmentController>
        [HttpGet]
        public IEnumerable<Appointments> Get()
        {
           return appointment.GetAppointment();
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointments GetById(int id)
        {
            return appointment.GetAppointments(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointments appointments)
        {
            appointment.BookAppointment(appointments);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Appointments appointments)
        {
            appointment.UpdateAppointment(id, appointments);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            appointment.DeleteAppointment(id);
        }
    }
}
