using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Enums
{
    public enum LobbyType
    {
        Invalid = -1,
        PublicMatchmaking = 0,
        Practice = 1,
        Tournament = 2,
        Tutorial = 3,
        COOPWithBots = 4,
        TeamMatch = 5,
        SoloQueue = 6
    }
}
