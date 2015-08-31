using Dota2Api.Converters;
using Dota2Api.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class DetailedMatch : Match
    {
        #region Private
        private Faction _winningFaction;
        private int _duration;
        private string _towerStatusRadiant;
        private string _towerStatusDire;
        private string _barracksStatusRadiant;
        private string _barracksStatusDire;
        private string _cluster;
        private int _firstBloodTime;
        private int _humanPlayers;
        private int _leagueId;
        private int _positiveVotes;
        private int _negativeVotes;
        private GameMode _gameMode;
        private List<MatchPlayer> _players;
        private List<PickBanHero> _pickAndBans;
        private List<Tower> _towersRadiant;
        private List<Tower> _towersDire;
        private List<Barrack> _barracksRadiant;
        private List<Barrack> _barracksDire;
        #endregion
        [JsonProperty("players")]
        public List<MatchPlayer> Players
        {
            get { return _players; }
            set { _players = value; }
        }
        [JsonProperty("game_mode")]
        [JsonConverter(typeof(NumberToEnumConverter<GameMode>))]
        public GameMode GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; }
        }
        [JsonProperty("negative_votes")]
        public int NegativeVotes
        {
            get { return _negativeVotes; }
            set { _negativeVotes = value; }
        }
        [JsonProperty("positive_votes")]
        public int PositiveVotes
        {
            get { return _positiveVotes; }
            set { _positiveVotes = value; }
        }
        [JsonProperty("leagueid")]
        public int LeagueId
        {
            get { return _leagueId; }
            set { _leagueId = value; }
        }
        [JsonProperty("human_players")]
        public int HumanPlayers
        {
            get { return _humanPlayers; }
            set { _humanPlayers = value; }
        }
        [JsonProperty("first_blood_time")]
        public int FirstBloodTime
        {
            get { return _firstBloodTime; }
            set { _firstBloodTime = value; }
        }
        [JsonProperty("cluster")]
        public string Cluster
        {
            get { return _cluster; }
            set { _cluster = value; }
        }
        [JsonProperty("barracks_status_dire")]
        public string BarracksStatusDire
        {
            get { return _barracksStatusDire; }
            set
            {
                _barracksStatusDire = value;
                BarracksDire = Utils.ConvertStringToBarrackStatus(value).ToList();
            }
        }
        [JsonProperty("barracks_status_radiant")]
        public string BarracksStatusRadiant
        {
            get { return _barracksStatusRadiant; }
            set
            {
                _barracksStatusRadiant = value;
                BarracksRadiant = Utils.ConvertStringToBarrackStatus(value).ToList();
            }
        }
        [JsonProperty("tower_status_dire")]
        public string TowerStatusDire
        {
            get { return _towerStatusDire; }
            set
            {
                _towerStatusDire = value;
                TowersDire = Utils.ConvertStringToTowerStatus(value).ToList();
            }
        }
        [JsonProperty("tower_status_radiant")]
        public string TowerStatusRadiant
        {
            get { return _towerStatusRadiant; }
            set
            {
                _towerStatusRadiant = value;
                TowersRadiant = Utils.ConvertStringToTowerStatus(value).ToList();

            }
        }
        [JsonProperty("duration")]
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
        [JsonProperty("radiant_win")]
        [JsonConverter(typeof(DetailMatchFactionConverter))]
        public Faction WinningFaction
        {
            get { return _winningFaction; }
            set { _winningFaction = value; }
        }
        [JsonProperty("picks_bans")]
        public List<PickBanHero> PickAndBans
        {
            get { return _pickAndBans; }
            set { _pickAndBans = value; }
        }

        public DateTime EndTime
        {
            get { return StartTime.AddSeconds(Duration); }

        }

        public List<Tower> TowersRadiant
        {
            get { return _towersRadiant; }
            set { _towersRadiant = value; }
        }

        public List<Tower> TowersDire
        {
            get { return _towersDire; }
            set { _towersDire = value; }
        }

        public List<Barrack> BarracksDire
        {
            get { return _barracksDire; }
            set { _barracksDire = value; }
        }

        public List<Barrack> BarracksRadiant
        {
            get { return _barracksRadiant; }
            set { _barracksRadiant = value; }
        }
    }
}