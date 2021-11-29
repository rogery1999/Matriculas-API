using Entities.Context;

var builder = WebApplication.CreateBuilder(args);

// Register the context to the IoC
builder.Services.AddSqlServer<ExamenContext>(
  builder.Configuration.GetConnectionString("sqlConnection"),
  options => options.MigrationsAssembly("Matriculas-API"));


// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
    o => o.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
