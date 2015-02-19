using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL;

namespace Menu
{
    public class TestMenu :IMenu
    {
        public TestMenu()
        {
            
        }

        void IMenu.OptieEen()
        {
            throw new NotImplementedException();
        }

        private event EventHandler ButtonClickedEvent;

        public event EventHandler OnButtonClicked
        {
            add
            {
                if(ButtonClickedEvent != null)
                {
                    lock(ButtonClickedEvent)
                    {
                        ButtonClickedEvent += value;
                    }
                }
                else
                {
                    ButtonClickedEvent = new EventHandler(value);
                }
            }

            remove
            {
                if (ButtonClickedEvent != null)
                {
                    ButtonClickedEvent -= value;
                }
            }
        }

        public void ButtonClick()
        {
            EventHandler handler = ButtonClickedEvent;
            if(handler != null)
            {
                ClickedArgs args = new ClickedArgs();
                args.CommandName = "testClick";
                handler(this, args);
            }
        }
    }
}
