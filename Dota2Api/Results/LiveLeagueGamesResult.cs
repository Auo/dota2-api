using Dota2Api.ApiClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Results
{
    public class LiveLeagueGamesResult
    {
        private List<LiveLeagueMatch> _games;

        [JsonProperty("games")]
        public List<LiveLeagueMatch> Games
        {
            get { return _games; }
            set { _games = value; }
        }
        
    }
}
