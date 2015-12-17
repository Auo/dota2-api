﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Converters
{
    public class StringUriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Uri);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = reader.Value.ToString();
            Uri uri;

            if (string.IsNullOrEmpty(value))
                return null;

            if (!value.StartsWith("http://"))
                value = "http://" + value;

            Uri.TryCreate(value, UriKind.Absolute, out uri);

            return uri;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
