using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class TeamInfo
    {
        private string _teamName;
        private int _teamId;
        private long _teamLogo;
        private bool _complete;

        [JsonProperty("complete")]
        public bool Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }
        
        [JsonProperty("team_logo")]
        public long TeamLogo
        {
            get { return _teamLogo; }
            set { _teamLogo = value; }
        }
        
        [JsonProperty("team_id")]
        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }
        
        [JsonProperty("team_name")]
        public string TeamName
        {
            get { return _teamName; }
            set { _teamName = value; }
        }
        
    }
}
