using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Services
{
    public interface IEmailService
    {
        Task SendEmail(Message message);
    }
}