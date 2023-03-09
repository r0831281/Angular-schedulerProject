using StaffSchedulerApi.Models;

namespace StaffSchedulerApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
