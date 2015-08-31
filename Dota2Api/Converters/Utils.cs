using Dota2Api.ApiClasses;
using Dota2Api.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Converters
{
    public class Utils
    {
        public static IEnumerable<Tower> ConvertStringToTowerStatus(string towers)
        {
            //16-bit unsigned integer
            //┌─┬─┬─┬─┬─────────────────────── Not used.
            //│ │ │ │ │ ┌───────────────────── Ancient Top
            //│ │ │ │ │ │ ┌─────────────────── Ancient Bottom
            //│ │ │ │ │ │ │ ┌───────────────── Bottom Tier 3
            //│ │ │ │ │ │ │ │ ┌─────────────── Bottom Tier 2
            //│ │ │ │ │ │ │ │ │ ┌───────────── Bottom Tier 1
            //│ │ │ │ │ │ │ │ │ │ ┌─────────── Middle Tier 3
            //│ │ │ │ │ │ │ │ │ │ │ ┌───────── Middle Tier 2
            //│ │ │ │ │ │ │ │ │ │ │ │ ┌─────── Middle Tier 1
            //│ │ │ │ │ │ │ │ │ │ │ │ │ ┌───── Top Tier 3
            //│ │ │ │ │ │ │ │ │ │ │ │ │ │ ┌─── Top Tier 2
            //│ │ │ │ │ │ │ │ │ │ │ │ │ │ │ ┌─ Top Tier 1
            //│ │ │ │ │ │ │ │ │ │ │ │ │ │ │ │
            //0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0

            ushort bs = ushort.Parse(towers);

            for (int i = 0; i < 11; i++)
            {
                bool alive = IsBitSet16(bs, i);
                TowerPosition position = (TowerPosition)i;
                yield return new Tower { Alive = alive, Position = position };
            }
        }

        public static IEnumerable<Barrack> ConvertStringToBarrackStatus(string barracks)
        {
            //8-bit unsigned integer
            //┌─┬───────────── Not used.
            //│ │ ┌─────────── Bottom Ranged
            //│ │ │ ┌───────── Bottom Melee
            //│ │ │ │ ┌─────── Middle Ranged
            //│ │ │ │ │ ┌───── Middle Melee
            //│ │ │ │ │ │ ┌─── Top Ranged
            //│ │ │ │ │ │ │ ┌─ Top Melee
            //│ │ │ │ │ │ │ │
            //0 0 0 0 0 0 0 0

            byte bs = byte.Parse(barracks);

            for (int i = 0; i < 6; i++)
            {
                var alive = IsBitSet(bs, i);
                BarrackPosition position = (BarrackPosition)i;
                yield return new Barrack { Alive = alive, Position = position };
            }
        }

        private static bool IsBitSet(byte b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }

        private static bool IsBitSet16(ushort b, int pos)
        {
            return (b & (1 << pos)) != 0;
        }
    }
}
