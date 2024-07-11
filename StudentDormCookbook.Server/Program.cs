using Microsoft.EntityFrameworkCore;
using StudentDormCookbook.Business.Interface;
using StudentDormCookbook.Business.Service;
using StudentDormCookbook.Data.Generic;
using StudentDormCooknook.Data;
using StudentDormCooknook.Data.Entity;

var builder = WebApplication.CreateBuilder(args);

#region Cors

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		builder =>
		{
			builder.WithOrigins("https://localhost:5173")
				   .AllowAnyHeader()
				   .AllowAnyMethod();
		});
});

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database

builder.Services.AddDbContext<StudentCookbookDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region DependencyInjectionRepository

builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<ConvertUnit>, Repository<ConvertUnit>>();
builder.Services.AddScoped<IRepository<Ingredient>, Repository<Ingredient>>();
builder.Services.AddScoped<IRepository<Recipe>, Repository<Recipe>>();
builder.Services.AddScoped<IRepository<RecipeIngredient>, Repository<RecipeIngredient>>();
builder.Services.AddScoped<IRepository<Unit>, Repository<Unit>>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();

#endregion

#region DependencyInjectionServices

builder.Services.AddScoped<IIngredientService, IngredientService>();

#endregion

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
