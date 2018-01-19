using System.Windows.Forms;

namespace Voenkaff.Wrappers
{
    public class PanelWrapper
    {
        public PanelWrapper(Panel entity,int identifier)
        {
            Entity = entity;
            Identifier = identifier;
        }

        public PanelWrapper()
        {

        }

        public int Identifier { get; set; }
        public Panel Entity { get; set; }
    }
}
