using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NameConvention.db_features
{
    public static class DataSerializer
    {
        public static void SerializeData(string filename, ConventionSet data)
        {
            var formatter = new DataContractSerializer(typeof(ConventionSet));
            var s = new FileStream(filename, FileMode.Create);
            formatter.WriteObject(s, data);
            s.Close();
        }

        public static ConventionSet DeserializeItem(string fileName)
        {
            var s = new FileStream(fileName, FileMode.Open);
            var formatter = new DataContractSerializer(typeof(ConventionSet));
            return (ConventionSet)formatter.ReadObject(s);
        }
    }

    [DataContract]
    public class ConventionSet
    {
        [DataMember]
        public List<Convention> Conventions = new List<Convention>(); 
    }
}
