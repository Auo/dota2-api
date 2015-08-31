using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dota2Api.Exceptions;
using Dota2Api.Enums;
using Dota2Api.ApiClasses;
using Newtonsoft.Json;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class LiveLeagueScoreboardPlayer : ExtendedPlayer
    {
        #region Private
        private int _playerSlot;
        private decimal _positionX;
        private decimal _positionY;
        private int _netWorth;
        private int _respawnTimer;
        private int _ultimateCooldown;
        private UltimateState _ultimateState;
        #endregion

        [JsonProperty("ultimate_state")]
        [JsonConverter(typeof(NumberToEnumConverter<UltimateState>))]
        public UltimateState UltimateState
        {
            get { return _ultimateState; }
            set { _ultimateState = value; }
        }

        [JsonProperty("ultimate_cooldown")]
        public int UltimateCooldown
        {
            get { return _ultimateCooldown; }
            set { _ultimateCooldown = value; }
        }

        [JsonProperty("respawn_timer")]
        public int RespawnTimer
        {
            get { return _respawnTimer; }
            set { _respawnTimer = value; }
        }

        [JsonProperty("net_worth")]
        public int NetWorth
        {
            get { return _netWorth; }
            set { _netWorth = value; }
        }

        [JsonProperty("position_y")]
        public decimal PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        [JsonProperty("position_x")]
        public decimal PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        [JsonProperty("player_slot")]
        public int PlayerSlot
        {
            get { return _playerSlot; }
            set { _playerSlot = value; }
        }
    }
}
