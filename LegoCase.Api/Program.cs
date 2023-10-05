using LegoCase.Core.Equipment;
using LegoCase.Core.Users;
using LegoCase.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<LegoCaseContext>();
builder.Services.AddTransient<IEquipmentService, EquipmentService>();
builder.Services.AddTransient<IUserService, WorkerUserMockService>();

var app = builder.Build();

app.MapControllers();

app.Run();
