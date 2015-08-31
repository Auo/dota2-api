using Dota2Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class Tower
    {
        public TowerPosition Position { get; set; }
        public bool Alive { get; set; }
    }
}
