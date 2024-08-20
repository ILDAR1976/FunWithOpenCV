using System;
using System.Runtime.Serialization;


namespace SpecialScanner.Model
{
    [DataContract]
    public class Settings
    {
        [DataMember]
        public string SourceFolderPath { get; set; }
        [DataMember]
        public string SamplesFolderPath { get; set; }
        [DataMember]
        public List<String> Cameras { get; set; } = new List<String>();

        private static Settings instance;
        private Settings() { }
        public static Settings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Settings();
                }
                return instance;
            }
        }


    }
}
