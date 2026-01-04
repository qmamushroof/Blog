using Blog.Data;
using Blog.Repositories;
using Blog.Repositories.Interfaces;
using Blog.Services;
using Blog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IShareTrackRepository, ShareTrackRepository>();
builder.Services.AddScoped<ISubscriberRepository, SubscriberRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IShareService, ShareService>();
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();
builder.Services.AddScoped<ITagService, TagService>();

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();