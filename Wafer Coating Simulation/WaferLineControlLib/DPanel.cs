using System.Windows.Forms;

namespace WaferLineControlLib
{
    public class DPanel : Panel
    {
        public DPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }
    }
}
