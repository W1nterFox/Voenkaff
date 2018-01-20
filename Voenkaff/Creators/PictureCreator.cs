using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using SerializablePicutre;
using Voenkaff.Wrappers;

namespace Voenkaff.Creators
{
    public class PictureCreator
    {
        public void CreatePictures(Test test,string path)
        {
            foreach (var control in test.ListPanelsTasks)
            {
                foreach (var testElement in control.Entity.Controls.Find("panelQuestion", false)[0].Controls)
                {
                    if (testElement is PictureBox && (testElement as PictureBox).Name.Contains(test.TestName))
                    {
                        PictureBox picture = (testElement as PictureBox);
                        var serializationFile = path + "\\picture\\" + picture.Name + ".bin";
                        var serializationPicture = new SerializablePicture {Picture = picture.Image as Bitmap};
                        Directory.CreateDirectory(path + "\\picture\\");
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
