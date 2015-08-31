using Dota2Api.ApiClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Results
{
    public class GetTeamInfoResult
    {
        #region Private
        private int _status;
        private List<Team> _teams;
        #endregion

        [JsonProperty("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [JsonProperty("teams")]
        public List<Team> Teams
        {
            get { return _teams; }
            set { _teams = value; }
        }
    }
}
