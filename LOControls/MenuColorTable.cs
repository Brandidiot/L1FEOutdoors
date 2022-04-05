using System.Windows.Forms;
using System.Drawing;

namespace L1FEOutdoors.LOControls
{
    public class MenuColorTable : ProfessionalColorTable
    {
        //Fields
        private Color _backColor;
        private Color _leftColumnColor;
        private Color _borderColor;
        private Color _menuItemBorderColor;
        private Color _menuItemSelectedColor;
        
        //Constructor
        public MenuColorTable(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                _backColor = Color.FromArgb(51, 51, 76);
                _leftColumnColor = Color.FromArgb(46, 46, 70);
                _borderColor = Color.FromArgb(46, 46, 70);
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
            else
            {
                _backColor = Color.White;
                _leftColumnColor = Color.LightGray;
                _borderColor = Color.LightGray;;
                _menuItemBorderColor = primaryColor;
                _menuItemSelectedColor = primaryColor;
            }
        }
        
        //Overrides
        public override Color ToolStripDropDownBackground => _backColor;

        public override Color MenuBorder => _borderColor;

        public override Color MenuItemBorder => _menuItemBorderColor;

        public override Color MenuItemSelected => _menuItemSelectedColor;

        public override Color ImageMarginGradientBegin => _leftColumnColor;

        public override Color ImageMarginGradientMiddle => _leftColumnColor;

        public override Color ImageMarginGradientEnd => _leftColumnColor;
    }
}
