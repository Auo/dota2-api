using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class Team
    {
        #region Private
        private int _teamId;
        private string _name;
        private string _tag;
        private DateTime _created;
        private string _rating;
        private long _logo;
        private long _logoSponsor;
        private string _countryCode;
        private Uri _uri;
        private int _gamesPlayedWithCurrentRoster;
        private int _adminAccountId;
        #endregion
        [JsonProperty("admin_account_id")]
        public int AdminAccountId
        {
            get { return _adminAccountId; }
            set { _adminAccountId = value; }
        }
        
        [JsonProperty("games_played_with_current_roster")]
        public int GamesPlayedWithCurrentRoster
        {
            get { return _gamesPlayedWithCurrentRoster; }
            set { _gamesPlayedWithCurrentRoster = value; }
        }
        
        [JsonProperty("url")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }
        
        [JsonProperty("country_code")]
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        
        [JsonProperty("logo_sponsor")]
        public long LogoSponsor
        {
            get { return _logoSponsor; }
            set { _logoSponsor = value; }
        }
        
        [JsonProperty("logo")]
        public long Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }
        
        [JsonProperty("rating")]
        public string Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        
        [JsonProperty("time_created")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        
        [JsonProperty("tag")]
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
        
        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        [JsonProperty("team_id")]
        public int TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }

        public List<long> PlayerAccountIds { get; set; }

        public List<long> LeagueIds { get; set; }
        
    }
}
