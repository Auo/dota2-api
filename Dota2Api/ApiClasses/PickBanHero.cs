using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Enums;

namespace Dota2Api.ApiClasses
{
    public class PickBanHero
    {
        #region Private
        private bool _isPick;
        private int _heroId;
        private Faction _faction;
        private int _order;
        #endregion

        [JsonProperty("order")]
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
        
        [JsonProperty("team")]
        public Faction Faction
        {
            get { return _faction; }
            set { _faction = value; }
        }
        
        [JsonProperty("hero_id")]
        public int HeroId
        {
            get { return _heroId; }
            set { _heroId = value; }
        }
        
        [JsonProperty("is_pick")]
        public bool IsPick
        {
            get { return _isPick; }
            set { _isPick = value; }
        }
        
    }
}
