using System.Windows.Forms;

namespace Voenkaff.Wrappers
{
    public class PanelWrapper
    {
        public PanelWrapper(Panel entity,int identifier)
        {
            Entity = entity;
            Identifier = identifier;
            PictureIndex = 0;
        }

        public PanelWrapper()
        {

        }

        public int Identifier { get; set; }
        public int PictureIndex { get; set; }
        public Panel Entity { get; set; }
    }
}
