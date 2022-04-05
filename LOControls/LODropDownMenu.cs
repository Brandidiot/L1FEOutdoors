using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace L1FEOutdoors.LOControls
{
    public class LODropDownMenu : ContextMenuStrip
    {
        //Fields
        private bool _isMainMenu;
        private int _menuItemHeight = 25;
        private Color _textColor = Color.DimGray;
        private Color _primaryColor = Color.MediumSlateBlue;

        private Bitmap _menuItemHeaderSize;
        
        //Constructor
        public LODropDownMenu(IContainer container) : base(container)
        {
            
        }
        
        //Properties
        [Browsable(false)]
        public bool IsMainMenu
        {
            get
            {
                return _isMainMenu;
            }
            set
            {
                _isMainMenu = value;
            }
        }
        
        [Browsable(false)]
        public int MenuItemHeight
        {
            get
            {
                return _menuItemHeight;
            }
            set
            {
                _menuItemHeight = value;
            }
        }
        
        [Browsable(false)]
        public Color TextColor
        {
            get
            {
                return _textColor;
            }
            set
            {
                _textColor = value;
            }
        }
        
        [Browsable(false)]
        public Color PrimaryColor
        {
            get
            {
                return _primaryColor;
            }
            set
            {
                _primaryColor = value;
            }
        }
        
        //Private Methods
        private void LoadMenuItemApperance()
        {
            if (_isMainMenu)
            {
                _menuItemHeaderSize = new Bitmap(25, 45);
                _textColor = Color.Gainsboro;
            }
            else
            {
                _menuItemHeaderSize = new Bitmap(15, _menuItemHeight);
            }

            foreach (ToolStripMenuItem menuItem1 in Items)
            {
                menuItem1.ForeColor = _textColor;
                menuItem1.ImageScaling = ToolStripItemImageScaling.None;

                menuItem1.Image ??= _menuItemHeaderSize;
                
                foreach (ToolStripMenuItem menuItem2 in menuItem1.DropDownItems)
                {
                    menuItem1.ForeColor = _textColor;
                    menuItem1.ImageScaling = ToolStripItemImageScaling.None;

                    menuItem1.Image ??= _menuItemHeaderSize;
                    
                    foreach (ToolStripMenuItem menuItem3 in menuItem2.DropDownItems)
                    {
                        menuItem1.ForeColor = _textColor;
                        menuItem1.ImageScaling = ToolStripItemImageScaling.None;

                        menuItem1.Image ??= _menuItemHeaderSize;
                        
                        foreach (ToolStripMenuItem menuItem4 in menuItem3.DropDownItems)
                        {
                            menuItem1.ForeColor = _textColor;
                            menuItem1.ImageScaling = ToolStripItemImageScaling.None;

                            menuItem1.Image ??= _menuItemHeaderSize;
                        }
                    }
                }
            }
        }
        
        //Overrides
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (!DesignMode)
            {
                LoadMenuItemApperance();
                Renderer = new MenuRenderer(_isMainMenu, _primaryColor, _textColor);
            }
        }
    }
}