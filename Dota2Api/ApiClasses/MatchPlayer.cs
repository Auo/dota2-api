using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Enums;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class MatchPlayer : ExtendedPlayer
    {
        #region Private
        private LeaverStatus _leaverStatus;
        private int _goldSpent;
        private int _heroDamage;
        private int _towerDamage;
        private int _heroHealing;
        private List<AbilityUpgrade> _abilityUpgrades;
        private List<SlotItem> _items;
        #endregion

        [JsonProperty("ability_upgrades")]
        public List<AbilityUpgrade> AbilityUpgrades
        {
            get { return _abilityUpgrades; }
            set { _abilityUpgrades = value; }
        }

        [JsonProperty("hero_healing")]
        public int HeroHealing
        {
            get { return _heroHealing; }
            set { _heroHealing = value; }
        }

        [JsonProperty("tower_damage")]
        public int TowerDamage
        {
            get { return _towerDamage; }
            set { _towerDamage = value; }
        }

        [JsonProperty("hero_damage")]
        public int HeroDamage
        {
            get { return _heroDamage; }
            set { _heroDamage = value; }
        }

        [JsonProperty("gold_spent")]
        public int GoldSpent
        {
            get { return _goldSpent; }
            set { _goldSpent = value; }
        }

        [JsonProperty("leaver_status")]
        [JsonConverter(typeof(NumberToEnumConverter<LeaverStatus>))]
        public LeaverStatus LeaverStatus
        {
            get { return _leaverStatus; }
            set { _leaverStatus = value; }
        }

        private int _playerSlot;
        [JsonProperty("player_slot")]
        public int PlayerSlot
        {
            get { return _playerSlot; }
            set { _playerSlot = value; }
        }
        
        public Faction Faction
        {
            get { return _playerSlot < 5 ? Faction.Radiant : Faction.Dire; }
        }

        public List<SlotItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }
}
