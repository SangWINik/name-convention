using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public class Convention
    {
        public static string[] ColumnTemplates = {":tName:", ":TName:", ":mainPart:", ":MainPart:"};

        private string Name;
        private string TableTemplate;
        private string ColumnTemplate;
        private string PrimaryKeyTemplate;
        private bool PluralTableNames;

        public Convention(string name, string tableTemplate, string columnTemplate, string pkTemplate, bool pluralTableNames)
        {
            Name = name;
            TableTemplate = tableTemplate;
            ColumnTemplate = columnTemplate;
            PrimaryKeyTemplate = pkTemplate;
            PluralTableNames = pluralTableNames;
        }

        public string GetColumnName(string oldName, string tableName)
        {
            string tName = tableName;
            string mainPart = oldName;
            string result = ColumnTemplate;
            if (result.IndexOf(":tName:") != -1)
            {
                if (tName.Length>0)
                    tName = tName.First().ToString().ToLower() + tName.Substring(1);
                result = result.Replace(":tName:", tName);
            }
            if (result.IndexOf(":TName:") != -1)
            {
                if (tName.Length > 0)
                    tName = tName.First().ToString().ToUpper() + tName.Substring(1);
                result = result.Replace(":tName:", tName);
            }
            if (result.IndexOf(":mainPart:") != -1)
            {
                if (tName.Length > 0)
                    mainPart = mainPart.First().ToString().ToLower() + mainPart.Substring(1);
                result = result.Replace(":mainPart:", mainPart);
            }
            if (result.IndexOf(":MainPart:") != -1)
            {
                if (tName.Length > 0)
                    mainPart = mainPart.First().ToString().ToUpper() + mainPart.Substring(1);
                result = result.Replace(":MainPart:", mainPart);
            }
            return result;
        }
    }

    public class TableConvention
    {
        private string TemplateString;

        public TableConvention(string template)
        {
            TemplateString = template;
        }
    }

    public class ColumnConvention
    {
        private string TemplateString;

        public ColumnConvention(string template)
        {
            TemplateString = template;
        }
    }

    public class PrimaryKeyConvention
    {
        private string TemplateString;

        public PrimaryKeyConvention(string template)
        {
            TemplateString = template;
        }
    }
}
