using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using DirectShowLib;

namespace SpecialScanner.Model
{
    [DataContract]
    public class Settings
    {
        public string SETTINGS_FILE_PATH = "settings.json";

        [DataMember]
        public string SourceFolderPath { get; set; }
        [DataMember]
        public string SourceFolderPathVideo { get; set; }
        [DataMember]
        public string SamplesFolderPath { get; set; }
        
        public DsDevice[] _SystemCameras { get; }
        [DataMember]
        public int CameraIndex { get; set; }
        
        public Video_Device[] WebCams { get; }
        [DataMember]
        public int WebCameraIndex { get; set; }


        private static Settings instance;
        private Settings() 
        {
            _SystemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new Video_Device[_SystemCameras.Length];
        }
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

        public void SaveJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));

            using (var file = new FileStream(SETTINGS_FILE_PATH, FileMode.Create))
            {
                jsonFormatter.WriteObject(file, Settings.Instance);
            }

        }

        public void LoadJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));

            using (var file = new FileStream(SETTINGS_FILE_PATH, FileMode.OpenOrCreate))
            {
                var settings = jsonFormatter.ReadObject(file);
                Settings.Instance.SourceFolderPath = ((Settings)settings).SourceFolderPath;
                Settings.Instance.SourceFolderPathVideo = ((Settings)settings).SourceFolderPathVideo;
                Settings.Instance.SamplesFolderPath = ((Settings)settings).SamplesFolderPath;
                Settings.Instance.CameraIndex = ((Settings)settings).CameraIndex;
                Settings.Instance.WebCameraIndex = ((Settings)settings).WebCameraIndex;

            }
        }

    }
}
