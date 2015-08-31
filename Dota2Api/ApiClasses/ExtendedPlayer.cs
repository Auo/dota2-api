using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public abstract class ExtendedPlayer : Player
    {
        #region Private
        private int _kills;
        private int _deaths;
        private int _assists;
        private int _gold;
        private int _lastHits;
        private int _denies;
        private int _goldPerMinute;
        private int _xpPerMinute;
        private int _level;
        private int _itemIdZero;
        private int _itemIdOne;
        private int _itemIdTwo;
        private int _itemIdThree;
        private int _itemIdFour;
        private int _itemIdFive;
        #endregion 

        [JsonProperty("level")]
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        [JsonProperty("xp_per_min")]
        public int XPPerMinute
        {
            get { return _xpPerMinute; }
            set { _xpPerMinute = value; }
        }

        [JsonProperty("gold_per_min")]
        public int GoldPerMinute
        {
            get { return _goldPerMinute; }
            set { _goldPerMinute = value; }
        }

        [JsonProperty("denies")]
        public int Denies
        {
            get { return _denies; }
            set { _denies = value; }
        }

        [JsonProperty("last_hits")]
        public int LastHits
        {
            get { return _lastHits; }
            set { _lastHits = value; }
        }

        [JsonProperty("gold")]
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        [JsonProperty("item_0")]
        public int ItemIdZero
        {
            get { return _itemIdZero; }
            set { _itemIdZero = value; }
        }

        [JsonProperty("item_1")]
        public int ItemIdOne
        {
            get { return _itemIdOne; }
            set { _itemIdOne = value; }
        }

        [JsonProperty("item_2")]
        public int ItemIdTwo
        {
            get { return _itemIdTwo; }
            set { _itemIdTwo = value; }
        }

        [JsonProperty("item_3")]
        public int ItemIdThree
        {
            get { return _itemIdThree; }
            set { _itemIdThree = value; }
        }

        [JsonProperty("item_4")]
        public int ItemIdFour
        {
            get { return _itemIdFour; }
            set { _itemIdFour = value; }
        }

        [JsonProperty("item_5")]
        public int ItemIdFive
        {
            get { return _itemIdFive; }
            set { _itemIdFive = value; }
        }
        [JsonProperty("assists")]
        public int Assists
        {
            get { return _assists; }
            set { _assists = value; }
        }

        [JsonProperty("deaths")]
        public int Deaths
        {
            get { return _deaths; }
            set { _deaths = value; }
        }

        [JsonProperty("kills")]
        public int Kills
        {
            get { return _kills; }
            set { _kills = value; }
        }
    }
}
