using Dota2Api.Converters;
using Dota2Api.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class LiveLeaguePlayer : Player
    {
        private Faction _faction;

        [JsonProperty("team")]
        [JsonConverter(typeof(NumberToEnumConverter<Faction>))]
        public Faction Faction
        {
            get { return _faction; }
            set { _faction = value; }
        }

    }
}
