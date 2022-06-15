namespace RetroAchievementsApi.Extensions
{
    internal static class ServiceExtensions
    {
        public static void ConfigureMyServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpClient();
            services.AddSingleton<RetroAchievementsApiClient>();
        }
    }
}
