using WebAPIAutores;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration); 

startup.ConfigureServices(builder.Services);

// * Relocated to Startup.cs ConfigureServices
// builder.Services.AddControllers();
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

startup.Configure(app, app.Environment);

// * Relocated to Startup.cs Configure
// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// // Middlewares
// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

app.Run();
