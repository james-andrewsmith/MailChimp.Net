using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using MailChimp.Net.Api.Domain;

namespace MailChimp.Net.Api.Helpers
{
    internal sealed class MergeVariableConverter :  JsonConverter
    {
        public MergeVariableConverter()
        {             
        }
         
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(MergeVariables);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {             
            var mv = (MergeVariables)value;

            writer.WriteStartObject();

            if (!string.IsNullOrEmpty(mv.Id))
            {
                writer.WritePropertyName("id");
                serializer.Serialize(writer, mv.Id);
            }
            if (!string.IsNullOrEmpty(mv.NewEmail))
            {
                writer.WritePropertyName("new-email");
                serializer.Serialize(writer, mv.NewEmail);
            }

            foreach (var tag in mv.Tags)
            {
                if (tag.Value != null)
                {
                    if (tag.Value.GetType() == typeof(string))
                    {
                        if (!string.IsNullOrEmpty((string)tag.Value))
                        {
                            writer.WritePropertyName(tag.Key);
                            serializer.Serialize(writer, tag.Value);
                        }
                    }
                    else
                    {
                        writer.WritePropertyName(tag.Key);
                        serializer.Serialize(writer, tag.Value);
                    }
                }
            }

            if (mv.Groupings != null && mv.Groupings.Count > 0)
            {
                writer.WritePropertyName("groupings");
                serializer.Serialize(writer, mv.Groupings);
            }

            if (!string.IsNullOrEmpty(mv.OptInIPAddress))
            {
                writer.WritePropertyName("optin_ip");
                serializer.Serialize(writer, mv.OptInIPAddress);
            }

            if (!string.IsNullOrEmpty(mv.OptInTime))
            {
                writer.WritePropertyName("optin_time");
                serializer.Serialize(writer, mv.OptInTime);
            }

            if (mv.Location != null)
            {
                writer.WritePropertyName("mc_location");
                serializer.Serialize(writer, mv.Location);
            }

            if (!string.IsNullOrEmpty(mv.Language))
            {
                writer.WritePropertyName("mc_language");
                serializer.Serialize(writer, mv.Language);
            }

            if (mv.Notes != null && mv.Notes.Count > 0)
            {
                writer.WritePropertyName("mc_notes");
                serializer.Serialize(writer, mv.Notes);
            }

            writer.WriteEndObject();
        }
    }
}
