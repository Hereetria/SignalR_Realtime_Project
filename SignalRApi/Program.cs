using SignalRApi.DAL;
using SignalRApi.DAL.Abstract;
using SignalRApi.DAL.Concrete;
using SignalRApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddScoped<ICategoryDal,CategoryRepository>();
builder.Services.AddScoped <IProductDal,ProductRepository>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("SignalRCors", opts =>
    {
        opts.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("SignalRCors");

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
