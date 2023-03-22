using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<WebApplication1.Models.BlogDatabaseSettings>(
    builder.Configuration.GetSection("BlogDatabase"));

builder.Services.AddSingleton<BlogService>();
builder.Services.AddSingleton<UserService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corPolicityBuilder=> corPolicityBuilder.AllowAnyHeader().AllowAnyOrigin().WithOrigins("https://localhost:4200"));


app.MapControllers();

app.Run();
