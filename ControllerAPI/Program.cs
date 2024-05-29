using System.Text.Encodings.Web;
using System.Text.Json;
using Application.Services;
using Controller.Middleware;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Domain.Interfaces.ApplicationInterfaces;
using Domain.Interfaces.InfrastructureInterfaces;
using Domain.Resource;
using Infrastructure.Repo;
using Microsoft.AspNetCore.Mvc;
using Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Sử dụng Memory Cache
builder.Services.AddMemoryCache();

// Thêm Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// DI
builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));
builder.Services.AddScoped<ICampusService, CampusService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Đăng ký dịch vụ CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

// Inject Middleware
builder.Services.AddTransient<ExceptionHandlerMiddleware>();

// Sửa lại validate các trường không được null mặc định của controller
builder.Services.AddControllers().ConfigureApiBehaviorOptions(option =>
{
    option.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values.SelectMany(x => x.Errors);
        var newException = new BaseException
        {
            ErrorCode = 400,
            UserMessage = CommonResource.UserError,
            DevMessage = CommonResource.UserError,
            TraceId = "",
            MoreInfo = "https://www.facebook.com/",
            Errors = errors
        };
        var json = JsonSerializer.Serialize(newException, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        });
        return new BadRequestObjectResult(json);
    };
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

// Thêm dịch vụ xử lý middleware
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Thêm CORS
app.UseCors(MyAllowSpecificOrigins);


app.Run();