namespace RetroAchievementsApi
{
    public class RetroAchievementsApiClient
    {
        #region Constructors
        public RetroAchievementsApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Private Members
        private static string ApiUrl { get => "https://retroachievements.org/API/"; }
        private static string? UserName { get; set; }
        private static string? UserApiToken { get; set; }

        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region
        public IResult Authent(string userName, string apiToken)
        {
            try
            {
                UserName = userName;
                UserApiToken = apiToken;

                return Results.Ok("User credentials are accepted.");
            }
            catch
            {
                return Results.BadRequest("Error while accepting credentials.");
            }
        }

        public async Task<IResult> GetTopTenUsers()
        {
            return await SendRequestAsync("API_GetTopTenUsers.php", null);
        }

        public async Task<IResult> GetGameInfo(string gameId)
        {
            return await SendRequestAsync("API_GetGame.php", "i=" + gameId);
        }

        public async Task<IResult> GetGameInfoExtended(string gameId)
        {
            return await SendRequestAsync("API_GetGameExtended.php", "i=" + gameId);
        }

        public async Task<IResult> GetConsoleIDs()
        {
            return await SendRequestAsync("API_GetConsoleIDs.php", null);
        }

        public async Task<IResult> GetGameList(string consoleId)
        {
            return await SendRequestAsync("API_GetGameList.php", "i=" + consoleId);
        }

        public async Task<IResult> GetFeedFor(string userName, string count, string offset = "0")
        {
            return await SendRequestAsync("API_GetFeed.php", "u=" + userName, "c=" + count, "o=" + offset);
        }

        public async Task<IResult> GetUserRankAndScore(string userName)
        {
            return await SendRequestAsync("API_GetUserRankAndScore.php", "u=" + userName);
        }

        public async Task<IResult> GetUserProgress(string userName, string gameIDCSV)
        {
            gameIDCSV = gameIDCSV.Replace(@"/\s+/", "");
            return await SendRequestAsync("API_GetUserProgress.php", "u=" + userName, "i=" + gameIDCSV);
        }

        public async Task<IResult> GetUserRecentlyPlayedGames(string userName, string count, string offset = "0")
        {
            return await SendRequestAsync("API_GetUserRecentlyPlayedGames.php",
                "u=" + userName, "c=" + count, "o=" + offset);
        }

        public async Task<IResult> GetUserSummary(string userName, string numRecentGames)
        {
            return await SendRequestAsync("API_GetUserSummary.php", "u=" + userName, "g=" + numRecentGames, "a=5");
        }

        public async Task<IResult> GetGameInfoAndUserProgress(string userName, string gameId)
        {
            return await SendRequestAsync("API_GetGameInfoAndUserProgress.php", "u=" + userName, "g=" + gameId);
        }

        public async Task<IResult> GetAchievementsEarnedOnDay(string userName, DateTime dateInput)
        {
            string date = dateInput.ToString("yyyy-MM-dd hh:mm:ss");
            return await SendRequestAsync("API_GetAchievementsEarnedOnDay.php", "u=" + userName, "d=" + date);
        }

        public async Task<IResult> GetAchievementsEarnedBetween(string userName, DateTime dateFrom, DateTime dateTo)
        {
            string from = dateFrom.ToString("yyyy-MM-dd hh:mm:ss");
            string to = dateTo.ToString("yyyy-MM-dd hh:mm:ss");

            return await SendRequestAsync("API_GetAchievementsEarnedBetween.php",
                "u=" + userName, "f=" + from, "t=" + to);
        }

        public async Task<IResult> GetUserGamesCompleted(string userName)
        {
            return await SendRequestAsync("API_GetUserCompletedGames.php", "u=" + userName);
        }
        #endregion

        #region Private Assistants
        private string BuildAuthParameters()
        {
            try { return string.Format("?z={0}&y={1}", UserName, UserApiToken); }
            catch (NullReferenceException) { throw new UnauthorizedAccessException("Not authorized"); }
            catch { throw; }
        }

        private string BuildRequestUrl(string target, params string[]? parameters)
        {
            parameters ??= Array.Empty<string>();

            string requestParameters = string.Empty;
            foreach (var item in parameters)
                requestParameters += "&" + item;

            return string.Format("{0}{1}{2}{3}", ApiUrl, target, BuildAuthParameters(), requestParameters);
        }

        private async Task<IResult> SendRequestAsync(string target, params string[]? parameters)
        {
            try
            {
                using (var client = _httpClientFactory.CreateClient())
                {
                    var requestUrl = BuildRequestUrl(target, parameters);

                    var result = await client.GetFromJsonAsync<object>(requestUrl);
                    return Results.Ok(result);
                }
            }
            catch
            {
                return Results.BadRequest("Internal server error");
            }
        }
        #endregion
    }
}
