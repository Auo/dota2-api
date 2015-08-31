using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dota2Api.Enums;
using Newtonsoft.Json;

namespace Dota2Api.ApiClasses
{
    public class LiveLeagueScoreboard
    {
        #region Private
        private decimal _duration;
        private int _roshanRespawnTimer;
        private LiveLeagueTeam _radiant;
        private LiveLeagueTeam _dire;
        #endregion

        [JsonProperty("dire")]
        public LiveLeagueTeam Dire
        {
            get { return _dire; }
            set { _dire = value; }
        }
        
        [JsonProperty("radiant")]
        public LiveLeagueTeam Radiant
        {
            get { return _radiant; }
            set { _radiant = value; }
        }

        [JsonProperty("roshan_respawn_timer")]
        public int RoshanRespawnTimer
        {
            get { return _roshanRespawnTimer; }
            set { _roshanRespawnTimer = value; }
        }

        [JsonProperty("duration")]
        public decimal Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        
    }
}
