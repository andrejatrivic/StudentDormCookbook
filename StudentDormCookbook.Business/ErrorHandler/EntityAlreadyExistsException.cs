namespace StudentDormCookbook.Business.ErrorHandler
{
	public class EntityAlreadyExistsException : Exception
	{
		public EntityAlreadyExistsException(string message) : base(message) 
		{ 
		}
	}
}
