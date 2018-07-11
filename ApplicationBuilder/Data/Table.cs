using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBuilder.Data
{
    public class Table
    {
        public string Name;
        public List<SchemaField> Fields = new List<SchemaField>();

        public Table()
        {
            Fields.Add(new SchemaField() { Comments = "Primary Key", DefaultValue = "AUTO", FieldType = SchemaFieldType.Number, Name = "Id" });
        }
    }
}
