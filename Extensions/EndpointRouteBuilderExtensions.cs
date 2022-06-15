namespace RetroAchievementsApi.Extensions
{
    internal static class EndpointRouteBuilderExtensions
    {
        public static void MapEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/auth", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string apiToken) =>
            {
                return apiClient.Authent(userName, apiToken);
            });

            endpoints.MapGet("/getTopTenUsers", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory) =>
            {
                return apiClient.GetTopTenUsers();
            });

            endpoints.MapGet("/getGameInfo", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory, 
                string gameId) =>
            {
                return apiClient.GetGameInfo(gameId);
            });

            endpoints.MapGet("/getGameInfoExtended", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory, 
                string gameId) =>
            {
                return apiClient.GetGameInfoExtended(gameId);
            });

            endpoints.MapGet("/getConsoleIDs", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory) =>
            {
                return apiClient.GetConsoleIDs();
            });

            endpoints.MapGet("/getGameList", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory, 
                string consoleId) =>
            {
                return apiClient.GetGameList(consoleId);
            });

            endpoints.MapGet("/getFeedFor", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string count, string offset) =>
            {
                return apiClient.GetFeedFor(userName, count, offset);
            });

            endpoints.MapGet("/getUserRankAndScore", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory, 
                string userName) =>
            {
                return apiClient.GetUserRankAndScore(userName);
            });

            endpoints.MapGet("/getUserProgress", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string gameIDCSV) =>
            {
                return apiClient.GetUserProgress(userName, gameIDCSV);
            });

            endpoints.MapGet("/getUserRecentlyPlayedGames", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string count, string offset) =>
            {
                return apiClient.GetUserRecentlyPlayedGames(userName, count, offset);
            });

            endpoints.MapGet("/getUserSummary", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string numRecentGames) =>
            {
                return apiClient.GetUserSummary(userName, numRecentGames);
            });

            endpoints.MapGet("/getGameInfoAndUserProgress", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, string gameId) =>
            {
                return apiClient.GetGameInfoAndUserProgress(userName, gameId);
            });

            endpoints.MapGet("/getAchievementsEarnedOnDay", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, DateTime dateInput) =>
            {
                return apiClient.GetAchievementsEarnedOnDay(userName, dateInput);
            });

            endpoints.MapGet("/getAchievementsEarnedBetween", (RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory,
                string userName, DateTime dateFrom, DateTime dateTo) =>
            {
                return apiClient.GetAchievementsEarnedBetween(userName, dateFrom, dateTo);
            });

            endpoints.MapGet("/getUserGamesCompleted", (string userName,
                RetroAchievementsApiClient apiClient, IHttpClientFactory httpClientFactory) =>
            {
                return apiClient.GetUserGamesCompleted(userName);
            });
        }
    }
}
