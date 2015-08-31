using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Enums;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class LiveLeagueTeam
    {

        #region Private
        private int _score;
        private List<LiveLeaguePlayer> _players;
        #endregion

        [JsonProperty("players")]
        public List<LiveLeaguePlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }
        
        [JsonProperty("score")]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
    }
}
