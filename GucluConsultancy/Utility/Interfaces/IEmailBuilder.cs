namespace GucluConsultancy.Utility.Interfaces
{
	public interface IEmailBuilder
	{
		string GetHtmlString(string emailSubject, object viewModel);
	}
}