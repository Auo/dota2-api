using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Dota2Api.Exceptions;
using System.Configuration;

namespace Dota2Api.Test
{
    [TestClass]
    public class UnitTest
    {
        #region Private
        private static string _key;
        private static string _accountIdApproved;
        private static string _accountIdSixtyFour;
        private static string _accountIdNotApproved;
        private static string _specificMatchId;
        #endregion

        [ClassInitialize()]
        public static void Initialize(TestContext context)
        {
            _key = ConfigurationManager.AppSettings["Dota2ApiKey"];
            _accountIdApproved = "1115380";
            _accountIdSixtyFour = "76561197961381108";
            _accountIdNotApproved = "1115381";
            _specificMatchId = "1643018373";
        }

        [TestMethod]
        public async Task Get_Heroes()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var heroResult = await handler.GetHeroes();

                Assert.IsNotNull(heroResult);
            }
        }

        [TestMethod]
        public async Task Get_Matches_Approved()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var matchResult = await handler.GetMatchHistory();

                Assert.IsNotNull(matchResult);

                var approvedUserResult = await handler.GetMatchHistory(accountId: _accountIdApproved);

                Assert.IsNotNull(approvedUserResult);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotAllowingDataCollectionException))]
        public async Task Get_Matches_Non_Approved()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                try
                {
                    var matchResult = await handler.GetMatchHistory(accountId: _accountIdNotApproved);
                }
                catch (Exception e)
                {
                    Assert.IsTrue(!string.IsNullOrEmpty(e.Message));
                    throw;
                }
            }
        }

        [TestMethod]
        public async Task Get_Detailed_Match()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var detailedMatch = await handler.GetDetailedMatch(_specificMatchId);

                Assert.IsNotNull(detailedMatch);
                Assert.IsTrue(detailedMatch.Players.Any());
            }
        }

        [TestMethod]
        public async Task Get_Hero_Portrait()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                byte[] imageArray = await handler.GetHeroPortrait("antimage", Enums.HeroPortraitSize.SmallHorizontalPortrait);

                Assert.IsNotNull(imageArray);

            }
        }

        [TestMethod]
        public async Task Get_Item_Icon()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                byte[] imageArray = await handler.GetItemIcon("tango");

                Assert.IsNotNull(imageArray);

            }
        }

        [TestMethod]
        public async Task Get_Player_Summary()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var playerSummary = await handler.GetPlayerSummary(new string[] { _accountIdSixtyFour });

                Assert.IsNotNull(playerSummary);

            }
        }

        [TestMethod]
        public async Task Get_League_Listings()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var leagueListings = await handler.GetLeagueListings();
                
                Assert.IsNotNull(leagueListings);
            }
        }

        [TestMethod]
        public async Task Get_Live_League_Games()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var liveGames = await handler.GetLiveLeagueGames();

                Assert.IsNotNull(liveGames);
            }
        }

        [TestMethod]
        public async Task Get_Team_Info_By_Id()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var result = await handler.GetTeamInfoByTeamId();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task Get_Math_History_By_Sequence_Number()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                var result = await handler.GetMatchHistoryBySequenceNumber();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task Get_Tournament_PrizePool()
        {
            using (ApiHandler handler = new ApiHandler(_key))
            {
                int leagueId = 2733; //The International 2015
                var result = await handler.GetTournamentPrizePool(leagueId);

                Assert.IsNotNull(result);
                Assert.AreEqual<int>(leagueId, result.LeagueId);
            }
        }
    }
}
