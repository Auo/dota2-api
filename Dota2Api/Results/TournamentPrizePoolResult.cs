using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Results
{
    public class TournamentPrizePoolResult
    {
        #region Private
        private int prizePool;
        private int leagueId;
        private int status;
        #endregion

        [JsonProperty("status")]
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        [JsonProperty("league_id")]
        public int LeagueId
        {
            get { return leagueId; }
            set { leagueId = value; }
        }
        /// <summary>
        /// Dollars
        /// </summary>
        [JsonProperty("prize_pool")]
        public int PrizePool
        {
            get { return prizePool; }
            set { prizePool = value; }
        }
    }
}
