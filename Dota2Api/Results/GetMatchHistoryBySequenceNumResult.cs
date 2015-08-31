using Dota2Api.ApiClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Results
{
    public class GetMatchHistoryBySequenceNumResult
    {
        #region Private
        private int _status;
        private List<DetailedMatch> _matches;
        #endregion

        [JsonProperty("matches")]
        public List<DetailedMatch> Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        [JsonProperty("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
