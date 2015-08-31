using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Enums
{
    public enum PlayerStatus
    {
        /// <summary>
        /// Also set when the profile is Private
        /// </summary>
        Offline = 0,
        Online = 1,
        Busy = 2,
        Away = 3,
        Snooze = 4,
        LookingToTrade = 5,
        LookingToPlay = 6
    }
}
