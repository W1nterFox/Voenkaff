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

        // С помощью конструктора записываем пусть до файла и его имя.
        public DynamicParams()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
        }

        public class Settings
        {
            public string TestPath { get; set; } = "";
        }


        //Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
        public Settings Get()
        {
            return ReadFile();
        }

        private Settings ReadFile()
        {
            try
            {
                using (var stream = new FileStream(Path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                    var iniSet = (Settings) serializer.Deserialize(stream);
                    return iniSet;
                }
            }
            catch (Exception)
            {
                return new Settings();
            }
        }
        //Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
        public void SetTestPath(string value)
        {
            var iniFile = ReadFile();
            iniFile.TestPath = value;
            using (var stream = new FileStream(Path, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                serializer.Serialize(stream,iniFile);
            }
        }

    }
}
