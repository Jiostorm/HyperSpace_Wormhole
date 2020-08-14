using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wormhole.src
{
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            MethodInfo objMethodInfo = typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);

            object[] objArgs = new object[] { ControlStyles.AllPaintingInWmPaint |
                                      ControlStyles.UserPaint |
                                      ControlStyles.OptimizedDoubleBuffer, true };
            objMethodInfo.Invoke(this, objArgs);

            this.UpdateStyles();
            this.Size = new Size(1300, 700);
            this.BackColor = Color.Transparent;
        }
    }
}
