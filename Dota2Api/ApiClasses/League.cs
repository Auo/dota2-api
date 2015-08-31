using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class League
    {
        #region Private
        private string _name;
        private int _leagueId;
        private string _description;
        private Uri _tournamentUri;
        private int _itemDef;
        #endregion

        [JsonProperty("itemdef")]
        public int ItemDef
        {
            get { return _itemDef; }
            set { _itemDef = value; }
        }
        [JsonProperty("tournament_url")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri TournamentUri
        {
            get { return _tournamentUri; }
            set { _tournamentUri = value; }
        }
        [JsonProperty("description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [JsonProperty("leagueid")]
        public int LeagueId
        {
            get { return _leagueId; }
            set { _leagueId = value; }
        }
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
