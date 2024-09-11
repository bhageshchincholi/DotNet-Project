using Appointment.Interfaces;
using Appointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Services
{
    public class AppointmentService : IAppointment
    {
        private readonly AppointmentDbContext appointmentDbContext;

        public AppointmentService(AppointmentDbContext appointmentDbContext)
        {
            this.appointmentDbContext = appointmentDbContext;
        }
        void IAppointment.BookAppointment(Appointments appointments)
        {
            var bookApp = appointmentDbContext.Add(appointments);
            appointmentDbContext.SaveChanges();
            Console.WriteLine("Appointment Booked Successfully !!");
        }

        void IAppointment.DeleteAppointment(int id)
        {
            Appointments appointDelted = appointmentDbContext.appointments.Find(id);
            appointmentDbContext.Remove(appointDelted);
            Console.WriteLine("Appointment Delted Successfully !!");
        }

        IEnumerable<Appointments> IAppointment.GetAppointment()
        {
            return appointmentDbContext.appointments.ToList();
        }

        Appointments IAppointment.GetAppointments(int id)
        {
            return appointmentDbContext.appointments.Find(id);
        }

        void IAppointment.UpdateAppointment(int id, Appointments app)
        {
            Appointments appointmentToBeUpdated = appointmentDbContext.appointments.Find(id);
            appointmentToBeUpdated.FirstName = app.FirstName;
            appointmentToBeUpdated.LastName = app.LastName;
            appointmentToBeUpdated.AppointmentDate = app.AppointmentDate;
            appointmentToBeUpdated.DateOfBirth = app.DateOfBirth;
            appointmentDbContext.SaveChanges();
        }
    }
}
