using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class AbilityUpgrade
    {
        #region Private
        private int _abilityId;
        private int _time;
        private int _level;
        #endregion

        [JsonProperty("level")]
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        [JsonProperty("time")]
        public int Time
        {
            get { return _time; }
            set { _time = value; }
        }
        [JsonProperty("ability")]
        public int AbilityId
        {
            get { return _abilityId; }
            set { _abilityId = value; }
        }
        
    }
}
