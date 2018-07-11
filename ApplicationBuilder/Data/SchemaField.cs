using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBuilder.Data
{
    public class SchemaField
    {
        public string Name;
        public SchemaFieldType FieldType;
        public string Comments;
        public string DefaultValue;
    }

    public enum SchemaFieldType
    {
        Text,
        Memo,
        Boolean,
        Number,
        Currency,
        Date
    }
}
