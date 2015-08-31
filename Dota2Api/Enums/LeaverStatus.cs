using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Enums
{
    public enum LeaverStatus
    {
        DotaLeaverNone = 0,
        DotaLeaverDisconnected = 1,
        DotaLeaverDisconnectedTooLong = 2,
        DotaLeaverAbandoned = 3,
        DotaLeaverAFK = 4,
        DotaLeaverNeverConnected = 5,
        DotaLeaverNeverConnectedTooLong = 6
    }
}
