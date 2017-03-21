﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace NameConvention.db_features
{
    public class Convention
    {
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
                if (mainPart.Length > 0)
                    mainPart = mainPart.First().ToString().ToLower() + mainPart.Substring(1);
                result = result.Replace(":mainPart:", mainPart);
            }
            if (result.IndexOf(":MainPart:") != -1)
            {
                if (mainPart.Length > 0)
                    mainPart = mainPart.First().ToString().ToUpper() + mainPart.Substring(1);
                result = result.Replace(":MainPart:", mainPart);
            }
            return result;
        }

        public string GetTableName(string oldName)
        {
            string mainPart = oldName;
            string result = TableTemplate;
            if (result.IndexOf(":mainPart:") != -1)
            {
                if (mainPart.Length > 0)
                    mainPart = mainPart.First().ToString().ToLower() + mainPart.Substring(1);
                result = result.Replace(":mainPart:", mainPart);
            }
            if (result.IndexOf(":MainPart:") != -1)
            {
                if (mainPart.Length > 0)
                    mainPart = mainPart.First().ToString().ToUpper() + mainPart.Substring(1);
                result = result.Replace(":MainPart:", mainPart);
            }
            if (PluralTableNames)
            {
                if (result[result.Length - 1] != 's')
                    result += "s";
            }
            else
            {
                if (result[result.Length - 1] == 's')
                    result = result.Remove(result.Length - 1, 1);
            }
            return result;
        }
        
    }
}