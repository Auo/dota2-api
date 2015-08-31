using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.ApiClasses
{
    public class Hero
    {
        #region Private
        private static string NAME_BUFFER = "npc_dota_hero_";
        private int _id;
        private string _name;
        private string _valveName;
        #endregion

        [JsonProperty("id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.StartsWith(NAME_BUFFER))
                    value = value.Remove(0, NAME_BUFFER.Length);


                ValveName = value;

                string name = string.Empty;

                for (var i = 0; i < value.Length; i++)
                {
                    if (i == 0 || value[i - 1] == '_')
                        name += Char.ToUpper(value[i]);
                    else if (value[i] == '_')
                        name += ' ';
                    else
                        name += value[i];
                }

                _name = name;
            }
        }

        public string ValveName
        {
            get { return _valveName; }
            protected set { _valveName = value; }
        }

    }
}
