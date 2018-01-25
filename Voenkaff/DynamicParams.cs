using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace Voenkaff
{
    public class DynamicParams
    {
        string Path="settings.ini"; //Имя файла.

        private Settings settings;

        // С помощью конструктора записываем пусть до файла и его имя.
        public DynamicParams()
        {
            settings = new Settings();
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
        }

        public class Settings
        {
            public string TestPath { get; set; } = "C:\\";
        }


        //Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
        public string GetPath()
        {
            ReadFile();
            return settings.TestPath;
        }

        private void ReadFile()
        {
            try
            {
                using (var stream = new FileStream(Path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    var fileSettings = (Settings) serializer.Deserialize(stream);
                    if (fileSettings.TestPath != "")
                    {
                        settings = fileSettings;
                    }
                }
            }
            catch (Exception)
            {
                settings= new Settings(){TestPath = "C:\\"};
            }
        }
        //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
        public void SetTestPath(string value)
        {
            try
            {
                settings.TestPath = value;
                using (var stream = new FileStream(Path, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(stream, settings);
                }
            }
            catch (Exception)
            {
                //Ignored
            }
        }

    }
}
