using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// For Entity Framework
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;


builder.Services.AddIdentityServer()
.AddConfigurationStore(options =>
{
    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
})
.AddOperationalStore(options =>
{
    options.ConfigureDbContext = b => b.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
    options.EnableTokenCleanup = true;
});


var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    InitializeDatabase(app);
//}

//CONFIG DATABASE
//static void InitializeDatabase(IApplicationBuilder app)
//{
//    using (var serviceScope =
//            app.ApplicationServices
//                .GetService<IServiceScopeFactory>().CreateScope())
//    {
//        serviceScope
//            .ServiceProvider
//                .GetRequiredService<PersistedGrantDbContext>()
//                .Database.Migrate();

//        var context =
//            serviceScope.ServiceProvider
//                .GetRequiredService<ConfigurationDbContext>();

//        context.Database.Migrate();
//        if (!context.Clients.Any())
//        {
//            foreach (var client in Config.Clients)
//            {
//                context.Clients.Add(client.ToEntity());
//            }
//            context.SaveChanges();
//        }

//        if (!context.IdentityResources.Any())
//        {
//            foreach (var resource in Config.Ids)
//            {
//                context.IdentityResources.Add(resource.ToEntity());
//            }
//            context.SaveChanges();
//        }

//        if (!context.ApiResources.Any())
//        {
//            foreach (var resource in Config.Apis)
//            {
//                context.ApiResources.Add(resource.ToEntity());
//            }
//            context.SaveChanges();
//        }
//    }
//}

app.MapGet("/", () => "Hello World!");

app.Run();
