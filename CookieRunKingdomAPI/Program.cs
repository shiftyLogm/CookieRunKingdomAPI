using CookieRunKingdomAPI.Services;

var builder = WebApplication.CreateBuilder(args);

ApiServices.UseApiServices(builder.Services, builder.Configuration);

var app = builder.Build();

BuildServices.UseBuildServices(app);