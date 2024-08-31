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
        public string SourceFolderPathForBarrels { get; set; }
        [DataMember]
        public string SourceFolderPathVideoForBarrels { get; set; }
        [DataMember]
        public string SamplesFolderPathForBarrels { get; set; }
        [DataMember]
        public string SourceFolderPathForBoards { get; set; }

        public DsDevice[] _SystemCameras { get; }
        [DataMember]
        public int CameraIndex { get; set; }
        
        public Video_Device[] WebCams { get; }
        [DataMember]
        public int WebCameraIndex { get; set; }
        [DataMember]
        public string Address { get; set; } = string.Empty;
        [DataMember]
        public string Port { get; set; } = string.Empty;

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
                Settings.Instance.SourceFolderPathForBarrels = ((Settings)settings).SourceFolderPathForBarrels;
                Settings.Instance.SourceFolderPathVideoForBarrels = ((Settings)settings).SourceFolderPathVideoForBarrels;
                Settings.Instance.SamplesFolderPathForBarrels = ((Settings)settings).SamplesFolderPathForBarrels;
                Settings.Instance.SourceFolderPathForBoards = ((Settings)settings).SourceFolderPathForBoards;
                Settings.Instance.CameraIndex = ((Settings)settings).CameraIndex;
                Settings.Instance.WebCameraIndex = ((Settings)settings).WebCameraIndex;
                Settings.Instance.Address = ((Settings)settings).Address;
                Settings.Instance.Port = ((Settings)settings).Port;

            }
        }

    }
}
