using Kutuphane.Application.Interfaces.Books;
using Kutuphane.Application.Interfaces.Authors;
using Kutuphane.Application.Services.Books;
using Kutuphane.Application.Services.Authors;
using Scalar.AspNetCore;
using Kutuphane.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Kutuphane.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library")));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        db.Database.Migrate();
    }
}

app.UseHttpsRedirection();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Kutuphane API v1");
    });
    app.MapScalarApiReference();
}

app.Run();