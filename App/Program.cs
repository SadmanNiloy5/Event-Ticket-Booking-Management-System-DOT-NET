using BLL.Services;
using DAL.EF;
using DAL.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<EventTicketBookingDbContext>();

     builder.Services.AddScoped<EventRepo>();
    builder.Services.AddScoped<BookingRepo>();
   builder.Services.AddScoped<UserRepo>();

  builder.Services.AddScoped<EventService>();
  builder.Services.AddScoped<BookingService>();
 builder.Services.AddScoped<UserService>();

builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();