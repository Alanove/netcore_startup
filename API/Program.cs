using lw.Core.Cte;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configureServices(builder.Services);
configureApp(builder.Build());
void configureServices(IServiceCollection services)
{
	services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    var databaseSettings = configuration.GetSection(ConfigKeys.DatabaseSettings).Get<DatabaseSettings>();

    services.AddDatabase(databaseSettings);

	services.AddControllersWithViews()
        .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    #region Configure Swagger  
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Liteweb CMS Core", Version = "v1" });
    });
    #endregion
}
void configureApp(WebApplication app)
{
	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
	
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        // Configure your endpoints here
        endpoints.MapControllers();
    });
    app.UseStaticFiles();
    
    app.Run();
}