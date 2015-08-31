using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Dota2Api.Enums;
using Dota2Api.Converters;

namespace Dota2Api.ApiClasses
{
    public class SteamPlayerSummary
    {
        #region Private
        private long _steamId;
        private CommunityVisibilityState _communityVisibilityState;
        private string _profileState;
        private string _displayName;
        private DateTime _lastLogOff;
        private Uri _profileUri;
        private Uri _avatarUri;
        private Uri _avatarMediumUri;
        private Uri _avatarFullUri;
        private PlayerStatus _playerStatus;
        private string _locationCountryCode;
        #endregion

        [JsonProperty("avatarfull")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarFullUri
        {
            get { return _avatarFullUri; }
            set { _avatarFullUri = value; }
        }

        [JsonProperty("avatarmedium")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarMediumUri
        {
            get { return _avatarMediumUri; }
            set { _avatarMediumUri = value; }
        }

        [JsonProperty("avatar")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri AvatarUri
        {
            get { return _avatarUri; }
            set { _avatarUri = value; }
        }

        [JsonProperty("profileurl")]
        [JsonConverter(typeof(StringUriConverter))]
        public Uri ProfileUri
        {
            get { return _profileUri; }
            set { _profileUri = value; }
        }

        [JsonProperty("lastlogoff")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastLogOff
        {
            get { return _lastLogOff; }
            set { _lastLogOff = value; }
        }

        [JsonProperty("personaname")]
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        [JsonProperty("profileState")]
        public string ProfileState
        {
            get { return _profileState; }
            set { _profileState = value; }
        }

        [JsonProperty("communityvisibilitystate")]
        [JsonConverter(typeof(NumberToEnumConverter<CommunityVisibilityState>))]
        public CommunityVisibilityState CommunityVisibilityState
        {
            get { return _communityVisibilityState; }
            set { _communityVisibilityState = value; }
        }

        [JsonProperty("steamid")]
        public long SteamId
        {
            get { return _steamId; }
            set { _steamId = value; }
        }

        [JsonProperty("personastate")]
        [JsonConverter(typeof(NumberToEnumConverter<PlayerStatus>))]
        public PlayerStatus PlayerStatus
        {
            get { return _playerStatus; }
            set { _playerStatus = value; }
        }

        [JsonProperty("loccountrycode")]
        public string LocationCountryCode
        {
            get { return _locationCountryCode; }
            set { _locationCountryCode = value; }
        }

    }
}
