using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace L1FEOutdoors.LOControls
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        //Fields
        private Color _primaryColor;
        private Color _textColor;
        private int _arrowThickness;
        
        //Constructor
        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor) 
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            _primaryColor = primaryColor;
            _textColor = textColor;

            _arrowThickness = isMainMenu ? 3 : 2;
        }
        
        //Overrides
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = e.Item.Selected ? Color.White : _textColor;
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            //Fields
            var graphics = e.Graphics;
            var arrowSize = new Size(5, 12);
            var arrowColor = e.Item.Selected ? Color.White : _primaryColor;
            var rect = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - arrowSize.Height) / 2, 
                arrowSize.Width, arrowSize.Height);

            using var path = new GraphicsPath();
            using var pen = new Pen(arrowColor, _arrowThickness);
            
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            path.AddLine(rect.Left,rect.Top,rect.Right,rect.Top + rect.Height / 2);
            path.AddLine(rect.Right,rect.Top + rect.Height / 2, rect.Left, rect.Top + rect.Height);
            graphics.DrawPath(pen,path);
        }
    }
}