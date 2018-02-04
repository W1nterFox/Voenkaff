using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SerializablePicutre;
using Voenkaff.Wrappers;
using System.Collections.Generic;

namespace Voenkaff.Creators
{
    public class PictureCreator
    {
        public void CreatePictures(Test test,string path)
        {
            Directory.CreateDirectory(path + "\\picture\\");
            foreach (KeyValuePair<LinkLabel, PanelWrapper> keyValue in test.ListPanelsTasks)
            {
                foreach (var testElement in keyValue.Value.Entity.Controls.Find("panelQuestion", false)[0].Controls)
                {
                    if (testElement is PictureBox && (testElement as PictureBox).Name.Contains(test.TestName))
                    {
                        PictureBox picture = (testElement as PictureBox);
                        var serializationFile = path + "\\picture\\" + picture.Name + ".bin";
                        var serializationPicture = new SerializablePicture {Picture = picture.Image as Bitmap};
                        using (var stream = File.Open(serializationFile, FileMode.Create))
                        {
                            var binaryFormatter = new BinaryFormatter();
                            binaryFormatter.Serialize(stream, serializationPicture);
                        }
                        
                    }
                }
            }
        }


    }
}
