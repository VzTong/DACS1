using Microsoft.EntityFrameworkCore;
using MoviePJ.Entities;
using AspNetCoreHero.ToastNotification;
using MoviePJ.WebConfig.Consts;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorOptions(options =>
{
	options.ViewLocationFormats.Add("/{0}.cshtml");
});


// Kết nối DB
builder.Services.AddDbContext<MoviePJ_DBContext>(option =>
{
	// Tiện khi sửa db => Chỉ cần mở file appsetting.json lên sửa trong phần Database
	option.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

// Cấu hình thông báo
builder.Services.AddNotyf(config =>
{
	config.DurationInSeconds = 10;
	config.IsDismissable = true;
	config.Position = NotyfPosition.BottomRight;
});

// Cấu hình đăng nhập
builder.Services.AddAuthentication(AppConst.COOKIES_AUTH)
	.AddCookie(options =>
	{
		options.LoginPath = AppConst.ADMIN_LOGIN_PATH;
		options.ExpireTimeSpan = TimeSpan.FromHours(AppConst.LOGIN_TIMEOUT);
		options.Cookie.HttpOnly = true;
	});

// Cấu hình thư mục view cho ViewComponent
builder.Services.Configure<RazorViewEngineOptions>(config =>
{
	//path: /Components/{component-name}/Default.cshtml
	config.ViewLocationFormats.Add("/{0}.cshtml");
	config.AreaViewLocationFormats.Add("Areas/Admin/{0}.cshtml");
});

// Cấu hình session
builder.Services.AddSession(sessionConf =>
{
	// Dữ liệu session tồn tại trong 2 ngày
	sessionConf.IdleTimeout = TimeSpan.FromDays(2);
	sessionConf.IOTimeout = TimeSpan.FromDays(2);
});

//builder.WebHost.ConfigureKestrel(options =>
//{
//	options.Limits.MaxRequestBodySize = long.MaxValue;
//});

builder.Services.Configure<KestrelServerOptions>(options =>
{
	options.Limits.MaxRequestBodySize = int.MaxValue;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/error/500");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// Điều hướng khi gặp lỗi
app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseSession();           // Lệnh này mới sd được mvc session
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();    // Đăng nhập

app.UseAuthorization();

app.MapControllerRoute(
					name: "login",
					pattern: "/login",
					defaults: new
					{
						controller = "Account",
						action = "Login"
					});

app.MapAreaControllerRoute(
				   areaName: "Admin",
				   name: "adminLogin",
				   pattern: "/Admin/Login",
				   defaults: new
				   {
					   controller = "Account",
					   action = "Login",
					   area = "Admin"
				   }
	);
// Đường dẫn cho trang lỗiz
app.MapControllerRoute(
					name: "error",
					pattern: "/error/{statusCode}",
					defaults: new
					{
						controller = "Home",
						action = "Error"
					});

// Đường dẫn cho trang Admin
app.MapAreaControllerRoute(
				areaName: "Admin",
				name: "Admin",
				pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
				);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
