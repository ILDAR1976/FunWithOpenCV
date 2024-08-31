using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using DirectShowLib;

namespace SpecialScanner.Model
{
    [DataContract]
    public class Settings
    {
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

        

    }
}
