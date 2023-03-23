using Product.API.Filters;
using Product.Application.Ioc;

var builder = WebApplication.CreateBuilder(args);
 

builder.Services.AddControllers(options => options.Filters.Add(new ExceptionFilter())); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddResourcesList(builder.Configuration);

var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
