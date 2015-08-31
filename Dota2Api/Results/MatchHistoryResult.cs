using Dota2Api.ApiClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Results
{
    public class MatchHistoryResult
    {
        #region Private
        private int _status;
        private int _numberOfResults;
        private int _totalResults;
        private int _resultsRemaining;
        private List<Match> _matches;
        private string _statusDetail;
        #endregion

        [JsonProperty("matches")]
        public List<Match> Matches
        {
            get { return _matches; }
            set { _matches = value; }
        }

        [JsonProperty("results_remaining")]
        public int ResultsRemaining
        {
            get { return _resultsRemaining; }
            set { _resultsRemaining = value; }
        }

        [JsonProperty("total_results")]
        public int TotalResults
        {
            get { return _totalResults; }
            set { _totalResults = value; }
        }

        [JsonProperty("num_results")]
        public int NumberOfResults
        {
            get { return _numberOfResults; }
            set { _numberOfResults = value; }
        }

        [JsonProperty("statusDetail")]
        public string StatusDetail
        {
            get { return _statusDetail; }
            set { _statusDetail = value; }
        }

        [JsonProperty("status")]
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
