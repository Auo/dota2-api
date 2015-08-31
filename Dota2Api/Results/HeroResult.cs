using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dota2Api.ApiClasses;

namespace Dota2Api.Results
{
    public class HeroResult
    {
        #region Private
        private int _count;
        private int _status;
        private List<Hero> _heroes;
        #endregion

        [JsonProperty("count")]
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        [JsonProperty("heroes")]
        public List<Hero> Heroes
        {
            get { return _heroes; }
            protected set { _heroes = value; }
        }

        [JsonProperty("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
