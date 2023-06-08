namespace Abstraction.Service.Shared
{
	public static class Provider
	{
		public static string DateTimeFormatter(int minute, int hour, int day, int month, int year)
		{
			return day.ToString() + "/" + month.ToString() + "/" + year.ToString() + " " + hour.ToString() + ":" + minute.ToString();
		}
	}
}
