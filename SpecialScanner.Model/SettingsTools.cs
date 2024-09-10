using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SpecialScanner.Model
{
    public class SettingsTools
    {
        public static string SETTINGS_FILE_PATH { get; set; } = "settings.json";

        public static void SaveJson()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(Settings));

            using (var file = new FileStream(SETTINGS_FILE_PATH, FileMode.Create))
            {
                jsonFormatter.WriteObject(file, Settings.Instance);
            }

        }

        public static void LoadJson()
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
                //Board settings download
                Settings.Instance.BoardBlurSizeX = ((Settings)settings).BoardBlurSizeX;
                Settings.Instance.BoardBlurSizeY = ((Settings)settings).BoardBlurSizeY;
                Settings.Instance.BoardCannyX = ((Settings)settings).BoardCannyX;
                Settings.Instance.BoardCannyY = ((Settings)settings).BoardCannyY;
                Settings.Instance.BoardElementSizeX = ((Settings)settings).BoardElementSizeX;
                Settings.Instance.BoardElementSizeY = ((Settings)settings).BoardElementSizeY;
                Settings.Instance.BoardRetrType = ((Settings)settings).BoardRetrType;
                //Barrel settings download
                Settings.Instance.BarrelBlurSizeX = ((Settings)settings).BarrelBlurSizeX;
                Settings.Instance.BarrelBlurSizeY = ((Settings)settings).BarrelBlurSizeY;
                Settings.Instance.BarrelCannyX = ((Settings)settings).BarrelCannyX;
                Settings.Instance.BarrelCannyY = ((Settings)settings).BarrelCannyY;
                Settings.Instance.BarrelElementSizeX = ((Settings)settings).BarrelElementSizeX;
                Settings.Instance.BarrelElementSizeY = ((Settings)settings).BarrelElementSizeY;
                Settings.Instance.BarrelRetrType = ((Settings)settings).BarrelRetrType;

            }
        }
    }
}
