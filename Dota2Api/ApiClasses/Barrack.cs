using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dota2Api.Enums;

namespace Dota2Api.ApiClasses
{
    public class Barrack
    {
        public BarrackPosition Position { get; set; }
        public bool Alive { get; set; }
    }
}
