using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace GucluConsultancy.Utility.Interfaces
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string subject, string htmlMessage, IFormFileCollection formFileCollection);
	}
}