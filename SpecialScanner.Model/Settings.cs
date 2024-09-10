using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using DirectShowLib;
using Emgu.CV.CvEnum;

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
        // Barrels scanner settings
        [DataMember]
        public int BarrelBlurSizeX { get; set; }
        [DataMember]
        public int BarrelBlurSizeY { get; set; }
        [DataMember]
        public int BarrelElementSizeX { get; set; }
        [DataMember]
        public int BarrelElementSizeY { get; set; }
        [DataMember]
        public int BarrelCannyX { get; set; }
        [DataMember]
        public int BarrelCannyY { get; set; }
        [DataMember]
        public RetrType BarrelRetrType { get; set; }
        // Board scanner settings
        [DataMember]
        public int BoardBlurSizeX { get; set; }
        [DataMember]
        public int BoardBlurSizeY { get; set; }
        [DataMember]
        public int BoardElementSizeX { get; set; }
        [DataMember]
        public int BoardElementSizeY { get; set; }
        [DataMember]
        public int BoardCannyX { get; set; }
        [DataMember]
        public int BoardCannyY { get; set; }
        [DataMember]



        public bool showBlur { get; set; }
        public bool showKernel { get; set; }
        public bool showEdge { get; set; }
        public bool showClose { get; set; }


        public RetrType BoardRetrType { get; set; }

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
