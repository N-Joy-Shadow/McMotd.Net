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
    public class MotdDeserializer: IMotdDeserializer {
        private readonly MotdOption option;
        private IMotdDeserializer _deserializer;

        public MotdDeserializer(MotdOption option) {
            this.option = option; 
        }

        public MotdComponents Deserialize(string RawMotd) {
            SetDeserializer(RawMotd);            
            return this._deserializer.Deserialize(RawMotd);
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
        private void SetDeserializer(string RawMotd) {
            if (this.IsJson(RawMotd))
                this._deserializer = new MotdJsonDeserializer(option);
            else if (this.ContainSectionSign(RawMotd))
                this._deserializer = new SectionSignDeserializer(option);
            else
                this._deserializer = new PlainTextDeserializer(option);
        }
        #endregion
    }
}
