using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Enums
{
    public enum UltimateState
    {
        UltimateNotPicked = 0,
        UltimateIsOnCooldown = 1,
        UltimateIsReadyButNotEnoughMana = 2,
        UltimateIsReady = 3
    }
}
