namespace StudentDormCookbook.Business.ErrorHandler
{
	public class EntityIsNull : Exception
	{
		public EntityIsNull(string message) : base(message) 
		{
		}
	}
}
