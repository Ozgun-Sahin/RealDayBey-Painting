using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using EntitiyLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using System.Net;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<User, Role>().AddRoles<Role>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityErrorDescriber>();
builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config => { var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); config.Filters.Add(new AuthorizeFilter(policy)); });

builder.Services.AddMvc();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/AdminLogin/Index/"; });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(100);
    options.AccessDeniedPath = "/ErrorPage/Index";
    options.LoginPath = "/Customer/Login/Index/";
});


var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");




using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

    var roles = new[] { "Admin", "Customer" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new Role() { Name = role });
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    string userName = "Admin";
    string email = "admin@admin.com";
    string password = "Admin1234*";
    string name = "Admin";
    string surname = "Admin";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new User();

        
        user.UserName = userName;
        user.Email = email;
        user.Name = name;
        user.Surname = surname;
        user.SecurityStamp = Guid.NewGuid().ToString();

        //user.EmailConfirmed = true;
        

        
        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }


}





app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
});




app.Run();
