var builder = WebApplication.CreateBuilder(args);

// configuring services
builder.Services.ConfigureMyServices();

var app = builder.Build();

app.UseHttpsRedirection();

// mapping endpoints
app.MapEndpoints();

app.Run();