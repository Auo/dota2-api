using Dota2Api.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace Dota2Api.Test
{
    [TestClass]
    public class ApiHandlerTest
    {
        #region Private
        private static string apiKey;
        private static string approvedAccountId;
        private static string sixtyFourAccountId;
        private static string notApprovedAccountId;
        private static string matchId;
        #endregion

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            apiKey = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location).AppSettings.Settings["Api-Key"].Value;
            approvedAccountId = "1115380";
            sixtyFourAccountId = "76561197961381108";
            notApprovedAccountId = "1115381";
            matchId = "1643018373";
        }

        [TestMethod]
        public async Task GetHeroesAsync()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var heroResult = await handler.GetHeroes();
                Assert.IsNotNull(heroResult);
            }
        }

        [TestMethod]
        public async Task GetMatchesApproved()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var matchResult = await handler.GetMatchHistory();
                Assert.IsNotNull(matchResult);

                var approvedUserResult = await handler.GetMatchHistory(accountId: approvedAccountId);
                Assert.IsNotNull(approvedUserResult);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAllowingDataCollectionException))]
        public async Task GetMatchesNonApproved()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                try
                {
                    var matchResult = await handler.GetMatchHistory(accountId: notApprovedAccountId);
                }
                catch (Exception e)
                {
                    Assert.IsTrue(!string.IsNullOrEmpty(e.Message));
                    throw;
                }
            }
        }

        [TestMethod]
        public async Task GetDetailedMatch()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var detailedMatch = await handler.GetDetailedMatch(matchId);

                Assert.IsNotNull(detailedMatch);
                Assert.IsTrue(detailedMatch.Players.Count > 0);
            }
        }

        [TestMethod]
        public async Task GetHeroPortrait()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                byte[] imageArray = await handler.GetHeroPortrait("antimage", Enums.HeroPortraitSize.SmallHorizontalPortrait);
                Assert.IsNotNull(imageArray);
            }
        }

        [TestMethod]
        public async Task GetItemIcon()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                byte[] imageArray = await handler.GetItemIcon("tango");
                Assert.IsNotNull(imageArray);
            }
        }

        [TestMethod]
        public async Task GetPlayerSummary()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var playerSummary = await handler.GetPlayerSummary(new string[] { sixtyFourAccountId });
                Assert.IsNotNull(playerSummary);
            }
        }

        [TestMethod]
        public async Task GetLeagueListings()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var leagueListings = await handler.GetLeagueListings();
                Assert.IsNotNull(leagueListings);
            }
        }

        [TestMethod]
        public async Task GetLiveLeagueGames()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var liveGames = await handler.GetLiveLeagueGames();
                Assert.IsNotNull(liveGames);
            }
        }

        //TODO: should this be removed? 
        //[TestMethod]
        //public async Task GetTeamInfoById()
        //{
        //    using (ApiHandler handler = new ApiHandler(_key))
        //    {
        //        var result = await handler.GetTeamInfoByTeamId();
        //        Assert.IsNotNull(result);
        //    }
        //}

        [TestMethod]
        public async Task GetMathHistoryBySequenceNumber()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                var result = await handler.GetMatchHistoryBySequenceNumber();
                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetTournamentPrizePool()
        {
            using (ApiHandler handler = new ApiHandler(apiKey))
            {
                int leagueId = 2733; //The International 2015
                var result = await handler.GetTournamentPrizePool(leagueId);

                Assert.IsNotNull(result);
                Assert.AreEqual(leagueId, result.LeagueId);
            }
        }
    }
}

