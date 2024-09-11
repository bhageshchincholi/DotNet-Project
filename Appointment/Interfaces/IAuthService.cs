using Appointment.Models;
using Appointment.RequestModels;

namespace Appointment.Interfaces
{
    public interface IAuthService
    {
        User addUser(User user);

        string Login(LoginRequest loginRequest);
    }
}
