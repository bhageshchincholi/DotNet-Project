using Appointment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Interfaces
{
    public interface IAppointment
    {
        IEnumerable<Appointments> GetAppointment();

        Appointments GetAppointments(int id);

        void BookAppointment(Appointments appointments);

        void DeleteAppointment(int id);

        void UpdateAppointment(int id,Appointments appointments);
    }
}
