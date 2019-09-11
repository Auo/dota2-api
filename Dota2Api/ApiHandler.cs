using Dota2Api.ApiClasses;
using Dota2Api.Enums;
using Dota2Api.Exceptions;
using Dota2Api.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Api
{
    public class ApiHandler : IDisposable
    {
        #region Private
        private bool disposed = false;
        private readonly string apiKey;
        private const string BASE_ADDRESS = "https://api.steampowered.com/";
        private const string BASE_ADDRESS_CDN = "http://cdn.dota2.com/";
        private string KeyString
        {
            get { return "?key=" + apiKey; }
        }
        protected HttpClient _client;
        #endregion

        #region Constructor
        public ApiHandler(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new InvalidApiKeyException("Missing API-key");

            apiKey = key;

            _client = new HttpClient();
        }
        #endregion

        #region Public Methods
        //public async Task<GetTeamInfoResult> GetTeamInfoByTeamId(int startAtTeamId = -1, int teamsRequested = -1)
        //{
        //    try
        //    {
        //        StringBuilder extra = new StringBuilder();

        //        if (startAtTeamId != -1)
        //            extra.AppendFormat("{0}{1}", "&start_at_team_id=", startAtTeamId);

        //        if (teamsRequested != -1)
        //            extra.AppendFormat("{0}{1}", "&teams_requested=", teamsRequested);

        //        string query = QueryBuilder(BASE_ADDRESS, "IDOTA2Match_570/GetTeamInfoByTeamID/v001/", _keyString, extra.ToString());

        //        string content = await GetStringAsync(query);
        //        var apiResult = JsonConvert.DeserializeObject<ApiResult<GetTeamInfoResult>>(content);

        //        JObject dynamicContent = JObject.Parse(content);
        //        IEnumerable<JToken> teams = dynamicContent.Values().First()["teams"].Children();

        //        string playerStart = "player_";
        //        string leagueStart = "league_id";

        //        foreach (JObject team in teams)
        //        {
        //            int teamId = team["team_id"].Value<int>();

        //            Team currentTeam = apiResult.Result.Teams.FirstOrDefault(q => q.TeamId == teamId);
        //            currentTeam.PlayerAccountIds = new List<long>();
        //            currentTeam.LeagueIds = new List<long>();

        //            foreach (var property in team.Properties().Where(prop => prop.Name.StartsWith(playerStart) || prop.Name.StartsWith(leagueStart)))
        //            {
        //                if (property.Name.StartsWith(playerStart))
        //                    currentTeam.PlayerAccountIds.Add(property.Value.Value<long>());

        //                if (property.Name.StartsWith(leagueStart))
        //                    currentTeam.LeagueIds.Add(property.Value.Value<long>());
        //            }
        //        }
        //        return apiResult.Result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<LiveLeagueGamesResult> GetLiveLeagueGames()
        {
            try
            {
                string content = await GetStringAsync(BASE_ADDRESS + "IDOTA2Match_570/GetLiveLeagueGames/v0001/" + KeyString);
                var apiResult = JsonConvert.DeserializeObject<ApiResult<LiveLeagueGamesResult>>(content);

                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<LeagueListingResult> GetLeagueListings()
        {
            try
            {
                string content = await GetStringAsync(BASE_ADDRESS + "IDOTA2Match_205790/GetLeagueListing/v0001/" + KeyString);
                var apiResult = JsonConvert.DeserializeObject<ApiResult<LeagueListingResult>>(content);

                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountIds">64-bit accountId</param>
        /// <returns></returns>
        public async Task<SteamPlayerSummaryResult> GetPlayerSummary(IEnumerable<string> accountIds)
        {
            try
            {
                if (accountIds == null || !accountIds.Any())
                    throw new MissingAccountIdException("Atleast one accountId must be specified");

                string ids = accountIds.Aggregate((current, next) => current + "," + next);
                string queryString = QueryBuilder(BASE_ADDRESS, "ISteamUser/GetPlayerSummaries/v0002/", KeyString, "&steamids=", ids);

                string content = await GetStringAsync(queryString);
                var apiResult = JsonConvert.DeserializeObject<ApiResult<SteamPlayerSummaryResult>>(content);

                return apiResult.Response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HeroResult> GetHeroes()
        {
            try
            {
                string queryString = QueryBuilder(BASE_ADDRESS, "IEconDOTA2_570/GetHeroes/v0001/", KeyString);
                string content = await GetStringAsync(queryString);
                var apiResult = JsonConvert.DeserializeObject<ApiResult<HeroResult>>(content);
                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valveHeroName">Get the correct Hero name by calling GetHeroes and use the property ValveName</param>
        /// <param name="size"></param>
        /// <returns>byte[] if FullQualityVerticalPortrait .jpg image, else  .png image</returns>
        public async Task<byte[]> GetHeroPortrait(string valveHeroName, HeroPortraitSize size)
        {
            try
            {
                string suffix = string.Empty;

                switch (size)
                {
                    default:
                    case HeroPortraitSize.SmallHorizontalPortrait:
                        suffix = "sb.png";
                        break;
                    case HeroPortraitSize.LargeHorizontalPortrait:
                        suffix = "lg.png";
                        break;
                    case HeroPortraitSize.FullQualityHorizontalPortrait:
                        suffix = "full.png";
                        break;
                    case HeroPortraitSize.FullQualityVerticalPortrait:
                        suffix = "vert.jpg";
                        break;
                }

                string heroAndSuffix = string.Format("{0}_{1}", valveHeroName, suffix);
                string queryString = QueryBuilder(BASE_ADDRESS_CDN, "apps/dota2/images/heroes/", heroAndSuffix);
                byte[] content = await GetByteArrayAsync(queryString);

                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        /// <summary>
        /// Gets matches based on parameters, to get next matches. Use the last match ID as the parameter startAtMatchId.
        /// </summary>
        /// <param name="startAtMatchId"></param>
        /// <param name="accountId">32-bit account id</param>
        /// <param name="heroId"></param>
        /// <param name="gameMode"></param>
        /// <param name="skill"></param>
        /// <param name="minPlayers"></param>
        /// <param name="leagueId"></param>
        /// <param name="matchesRequested"></param>
        /// <param name="tournamentGamesOnly"></param>
        /// <returns></returns>
        public async Task<MatchHistoryResult> GetMatchHistory(string startAtMatchId = null, string accountId = null, int heroId = -1, GameMode gameMode = GameMode.AllGameModes, string skill = null, int minPlayers = -1, string leagueId = null, string matchesRequested = null, bool tournamentGamesOnly = false)
        {
            try
            {
                StringBuilder extra = new StringBuilder();

                if (!string.IsNullOrEmpty(startAtMatchId))
                    extra.AppendFormat("{0}{1}", "&start_at_match_id=", startAtMatchId);

                if (!string.IsNullOrEmpty(accountId))
                    extra.AppendFormat("{0}{1}", "&account_id=", accountId);

                if (heroId != -1)
                    extra.AppendFormat("{0}{1}", "&hero_id=", heroId);

                //NONE same as AllGameModes? 
                if (gameMode != GameMode.AllGameModes)
                    extra.AppendFormat("{0}{1}", "&game_mode=", (int)gameMode);

                if (!string.IsNullOrEmpty(skill))
                    extra.AppendFormat("{0}{1}", "&skill=", skill);

                if (minPlayers != -1)
                    extra.AppendFormat("{0}{1}", "&min_players=", minPlayers);

                if (!string.IsNullOrEmpty(leagueId))
                    extra.AppendFormat("{0}{1}", "&league_id=", leagueId);

                if (!string.IsNullOrEmpty(matchesRequested))
                    extra.AppendFormat("{0}{1}", "&matches_requested=", matchesRequested);

                if (tournamentGamesOnly)
                    extra.AppendFormat("{0}{1}", "&tournament_games_only=", tournamentGamesOnly);

                string queryString = QueryBuilder(BASE_ADDRESS, "IDOTA2Match_570/GetMatchHistory/V001/", KeyString, extra.ToString());

                string content = await GetStringAsync(queryString);

                var apiResult = JsonConvert.DeserializeObject<ApiResult<MatchHistoryResult>>(content);

                if (apiResult.Result.Status == 15)
                    throw new UserNotAllowingDataCollectionException(apiResult.Result.StatusDetail);

                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DetailedMatch> GetDetailedMatch(string matchId)
        {
            try
            {
                string queryString = QueryBuilder(BASE_ADDRESS, "IDOTA2Match_570/GetMatchDetails/V001/", KeyString, "&match_id=", matchId);
                string content = await GetStringAsync(queryString);

                var apiResult = JsonConvert.DeserializeObject<ApiResult<DetailedMatch>>(content);


                //Fix structure since Valves API is giving some strange values that we can't parse
                JObject dynamicContent = JObject.Parse(content);
                IEnumerable<JToken> players = dynamicContent.Values().First()["players"].Children();

                string propertyStartName = "item_";
                foreach (JObject player in players)
                {
                    int slot = player["player_slot"].Value<int>();
                    MatchPlayer matchPlayer = apiResult.Result.Players.FirstOrDefault(p => p.PlayerSlot == slot);
                    matchPlayer.Items = new List<SlotItem>();

                    foreach (var property in player.Properties().Where(prop => prop.Name.StartsWith(propertyStartName)))
                    {
                        var i = int.Parse(property.Name.Replace(propertyStartName, ""));
                        var itemId = property.Value.Value<int>();
                        matchPlayer.Items.Add(new SlotItem(i, itemId));
                    }
                }
                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TournamentPrizePoolResult> GetTournamentPrizePool(int leagueId = -1)
        {
            try {
                StringBuilder extra = new StringBuilder();

                if (leagueId != -1)
                    extra.AppendFormat("{0}{1}", "&leagueid=", leagueId);


                string queryString = QueryBuilder(BASE_ADDRESS, "IEconDOTA2_570/GetTournamentPrizePool/v1/", KeyString, extra.ToString());



                string content = await GetStringAsync(queryString);

                var apiResult = JsonConvert.DeserializeObject<ApiResult<TournamentPrizePoolResult>>(content);

                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GetMatchHistoryBySequenceNumResult> GetMatchHistoryBySequenceNumber(string startAtMatchSeqNumber = null, int matchesRequested = -1)
        {
            try
            {
                StringBuilder extra = new StringBuilder();

                if (!string.IsNullOrEmpty(startAtMatchSeqNumber))
                    extra.AppendFormat("{0}{1}", "&start_at_match_seq_num=", startAtMatchSeqNumber);

                if (matchesRequested != -1)
                    extra.AppendFormat("{0}{1}", "&matches_requested=", matchesRequested);

                string queryString = QueryBuilder(BASE_ADDRESS, "IDOTA2Match_570/GetMatchHistoryBySequenceNum/v0001/", KeyString, extra.ToString());
                string content = await GetStringAsync(queryString);

                var apiResult = JsonConvert.DeserializeObject<ApiResult<GetMatchHistoryBySequenceNumResult>>(content);

                if (apiResult.Result.Status != 1)
                    throw new ServiceUnavailableException("Something went wrong with the request, the status was != 1");

                return apiResult.Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="valveItemName">tango, blade_mail</param>
        /// <returns>byte[] .png image</returns>
        public async Task<byte[]> GetItemIcon(string valveItemName)
        {
            try
            {
                string queryString = QueryBuilder(BASE_ADDRESS_CDN, "apps/dota2/images/items/", valveItemName, "_lg.png");
                byte[] content = await GetByteArrayAsync(queryString);

                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CancelPendingRequests()
        {
            _client.CancelPendingRequests();
        }
        #endregion

        #region Private methods
        private string QueryBuilder(params string[] urlParts)
        {
            if (urlParts == null || !urlParts.Any())
                return string.Empty;
            return urlParts.Aggregate((a, b) => a + b);
        }

        #region HttpRequest
        private async Task<string> GetStringAsync(string address)
        {
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, address);
                var response = await _client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.Forbidden)
                    throw new InvalidApiKeyException("Api-Key most likely wrong");
                else if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                    throw new ServiceUnavailableException("Server is busy or api-call limit exceeded. Please wait 30 seconds and try again. Call only ~1 request/second.");

                string content = await response.Content.ReadAsStringAsync();

                return content;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<byte[]> GetByteArrayAsync(string address)
        {
            try
            {
                return await _client.GetByteArrayAsync(new Uri(address));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _client.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}