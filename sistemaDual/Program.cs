using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Implementation;
using sistemaDual.Interfaces;
using sistemaDual.Utilidades.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProgramaDualContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Repository
builder.Services.AddTransient(typeof(IGenericRespository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICatalagoProyectoRepository, CatalagoProyectoRepository>();
builder.Services.AddScoped<ICorreoService, CorreoService>();
builder.Services.AddScoped<IUtilidadesService, UtilidadesService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IAlumnoService, AlumnoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IUniversidadService, UniversidadService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ProgramaDualContext>();
        DbInitializer.Initialize(context);
    } 
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Hubo un error al sembrar la base de datos");
    }
}


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
