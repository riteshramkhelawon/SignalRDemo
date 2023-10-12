using SignalRDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Allow for adding session state
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession();

// Add signalR to project
builder.Services.AddSignalR();


var app = builder.Build();

// Enable Sessions
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Specify hub that clients can connect to
app.UseEndpoints(endpoints =>
{
    //endpoints.MapHub<ChatHub>("/chat");
    endpoints.MapHub<ConnectionHub>("/connection");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
