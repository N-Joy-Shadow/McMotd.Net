using McMotd.Data;
using McMotd.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using McMotd.API;
using McMotd.Model;

namespace McMotd.Utils.Deserializer
{
    public class MotdDeserializer: IMotdDeserializer
    {
        
        #if DEBUG
        private readonly SectionSignDeserializer sectionSignDeserializer;
        private readonly MotdJsonDeserializer jsonDeserializer;
        private readonly PlainTextDeserializer textDeserializer;
        #else
        private readonly IMotdDeserializer sectionSignDeserializer;
        private readonly IMotdDeserializer jsonDeserializer;
        private readonly IMotdDeserializer textDeserializer;
        #endif
        public MotdDeserializer(MotdOption option)
        {
            this.sectionSignDeserializer = new SectionSignDeserializer(option);
            this.jsonDeserializer = new MotdJsonDeserializer(option);
            this.textDeserializer = new PlainTextDeserializer(option);
            
        }

        public MotdComponents Deserialize(string RawMotd) {
            if (this.IsJson(RawMotd)) 
                return jsonDeserializer.Deserialize(RawMotd);
            else 
                if (this.ContainSectionSign(RawMotd)) 
                    return sectionSignDeserializer.Deserialize(RawMotd);
                else 
                    return textDeserializer.Deserialize(RawMotd);
        }

        #region private section
        private bool ContainSectionSign(string RawMotd) {
            return RawMotd.Contains("§");
        }
        private bool IsJson(string RawMotd) {
            RawMotd = RawMotd.Trim();
            return (RawMotd.StartsWith("{") && RawMotd.EndsWith("}")) || 
                   (RawMotd.StartsWith("[") && RawMotd.EndsWith("]"));
        }
        #endregion
    }
}
