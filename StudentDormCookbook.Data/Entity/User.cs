﻿namespace StudentDormCooknook.Data.Entity
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Salt { get; set; }
		public string PasswordHash { get; set; }
		public string ProfileImgUrl { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
