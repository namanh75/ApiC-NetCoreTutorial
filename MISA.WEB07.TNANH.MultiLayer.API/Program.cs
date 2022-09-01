using MISA.WEB07.TNANH.MultiLayer.BL;
using MISA.WEB07.TNANH.MultiLayer.DL;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped<IOfficerBL, OfficerBL>();
builder.Services.AddScoped<IOfficerDL, OfficerDL>();
builder.Services.AddScoped<IGroupBL, GroupBL>();
builder.Services.AddScoped<IGroupDL, GroupDL>();
//connect db tu file appsettings
DatabaseContext.ConnectionString = builder.Configuration.GetConnectionString("mySqlConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
