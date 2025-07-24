using CookieRunKingdomAPI.Data.Contexts;
using CookieRunKingdomAPI.Enums;
using CookieRunKingdomAPI.Profiles;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;
using System.Text.Json.Serialization;

public static class ApiServices
{
    public static IServiceCollection UseApiServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        AddContexts(services, configuration);
        ConfigureAutoMapper(services);

        return services;
    }

    private static IServiceCollection AddContexts(IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<CookieContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            o =>
            {
                o.MapEnum<CookieElements>("cookie_element", nameTranslator: new NpgsqlNullNameTranslator());
                o.MapEnum<CookieTypes>("cookie_type", nameTranslator: new NpgsqlNullNameTranslator());
                o.MapEnum<CookiePositions>("cookie_position", nameTranslator: new NpgsqlNullNameTranslator());
                o.MapEnum<CookieRarities>("cookie_rarity", nameTranslator: new NpgsqlNullNameTranslator());
            }));

        // more contexts

        return services;
    }

    private static IServiceCollection ConfigureAutoMapper(IServiceCollection services) 
    {
        services.AddAutoMapper(cfg => {},
            typeof(CookieProfile)
        );

        return services;
    }
}
