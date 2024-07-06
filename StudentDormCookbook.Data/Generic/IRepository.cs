﻿namespace StudentDormCookbook.Data.Generic
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();

		void Add(T entity);

		void Update(T entity);

		void Delete(T entity);

		Task SaveAsync();
	}
}
