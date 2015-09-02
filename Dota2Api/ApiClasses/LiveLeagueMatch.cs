using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Enums;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class LiveLeagueMatch
    {
        #region Private
        private List<LiveLeaguePlayer> _players;
        private long _lobbyId;
        private long _matchId;
        private int _spectators;
        private string _towerState;
        private int _leagueId;
        private double _streamDelaySeconds;
        private int _radiant_series_wins;
        private int _direSeriesWins;
        private int _seriesType;
        private int _leagueTier;
        private LiveLeagueScoreboard _scoreboard;
        private TeamInfo _radiantTeam;
        private TeamInfo _direTeam;
        #endregion

        [JsonProperty("scoreboard")]
        public LiveLeagueScoreboard Scoreboard
        {
            get { return _scoreboard; }
            set { _scoreboard = value; }
        }

        [JsonProperty("league_tier")]
        public int LeagueTier
        {
            get { return _leagueTier; }
            set { _leagueTier = value; }
        }

        [JsonProperty("series_type")]
        public int SeriesType
        {
            get { return _seriesType; }
            set { _seriesType = value; }
        }

        [JsonProperty("dire_series_wins")]
        public int DireSeriesWins
        {
            get { return _direSeriesWins; }
            set { _direSeriesWins = value; }
        }

        [JsonProperty("radiant_series_wins")]
        public int RadiantSeriesWins
        {
            get { return _radiant_series_wins; }
            set { _radiant_series_wins = value; }
        }

        [JsonProperty("stream_delay_s")]
        public double StreamDelaySeconds
        {
            get { return _streamDelaySeconds; }
            set { _streamDelaySeconds = value; }
        }

        [JsonProperty("league_id")]
        public int LeagueId
        {
            get { return _leagueId; }
            set { _leagueId = value; }
        }

        [JsonProperty("tower_state")]
        public string TowerState
        {
            get { return _towerState; }
            set { _towerState = value; }
        }

        [JsonProperty("spectators")]
        public int Spectators
        {
            get { return _spectators; }
            set { _spectators = value; }
        }

        [JsonProperty("match_id")]
        public long MatchId
        {
            get { return _matchId; }
            set { _matchId = value; }
        }

        [JsonProperty("lobby_id")]
        public long LobbyId
        {
            get { return _lobbyId; }
            set { _lobbyId = value; }
        }

        [JsonProperty("players")]
        public List<LiveLeaguePlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }

        [JsonProperty("dire_team")]
        public TeamInfo DireTeam
        {
            get { return _direTeam; }
            set { _direTeam = value; }
        }
        
        [JsonProperty("radiant_team")]
        public TeamInfo RadiantTeam
        {
            get { return _radiantTeam; }
            set { _radiantTeam = value; }
        }
    }
}
