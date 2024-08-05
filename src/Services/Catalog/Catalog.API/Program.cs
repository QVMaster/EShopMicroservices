var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    //opt.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.CreateOrUpdate; // for development phase
    //opt.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.None; // for production phase
});


var app = builder.Build();

// Configure the HTTP request pipline

app.MapCarter();

app.Run();
