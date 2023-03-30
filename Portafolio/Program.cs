using Portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// SERVICIOS TRANSITORIOS - SERVICIOS QUE VIVEN MENOS TIEMPO POR QUE SE INYECTAN EN CADA CLASE 
// SERVICIOS SCOPE - DELIMITADOS POR UNA PETICION HTTP {DENTRO DE LA MISMA PETICION HTTP SE NOS BRINDA LA MISMA INSTANCIA DEL SERVICIO , EN DISTINTAS PETICIONES HTTP SE NOS BRINDA NOS BRINDAS DISTINTAS INSTANCIAS DEL SERVICIO  }
// SERVICIOS SINGLETON , VIVEN PARA SIEMPRE
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();

//builder.Services.AddTransient<RepositorioProyectos>();


builder.Services.AddTransient<ServicioTransitorio>();
builder.Services.AddScoped<ServicioDelimitado>();
builder.Services.AddSingleton<ServicioUnico>();

builder.Services.AddTransient<IServicioEmail,ServicioEmailSendGrid>();

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


//hay varios tipos de ruteo , ruteo por atributo y ruteo convencional
//este caso es un ruteo convencional
//El id es un elemento o`pcional por que tiene ?
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
