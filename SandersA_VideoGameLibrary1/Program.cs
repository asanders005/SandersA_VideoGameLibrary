using Microsoft.EntityFrameworkCore;
using SandersA_VideoGameLibrary.Data.DAL;
using SandersA_VideoGameLibrary1.Data.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<VideoGameDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideoGameDBContext") ?? throw new InvalidOperationException("Connection string 'VideoGameDBContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IVideoGameDal, VideoGameDBDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<VideoGameDBContext>();
    context.Database.EnsureCreated();
    DBInitializer.Init(context);
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
