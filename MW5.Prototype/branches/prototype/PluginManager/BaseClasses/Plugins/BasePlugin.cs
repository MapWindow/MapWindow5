//using System;
//using BaseComponents.BaseClasses.Forms;
//using BaseComponents.InterFaces.Forms;
//using BaseComponents.InterFaces.Plugins;
////using BaseComponents.Interfaces.BusinessLogic;

//namespace BaseComponents.BaseClasses.Plugins
//{
//    public abstract class BasePlugin : IPlugin2
//    {
//        public BaseMainForm MainForm { get; set; }

//        public virtual void Plugin2Test(object imapWin)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void StartUp(BaseMainForm mainForm)
//        {
//            MainForm = mainForm;

//            CreateMenu();
//            CreateToolbar();
//        }

//        public virtual void Unload()
//        {
//            RemoveMenu();
//            RemoveToolbar();
//        }

//        public virtual void ToolButtonClicked(string toolButtonName, object[] args)
//        {
            
//        }

//        protected virtual void CreateMenu()
//        {
            
//        }
//        protected virtual void CreateToolbar()
//        {
            
//        }

//        protected virtual void RemoveMenu()
//        {

//        }
//        protected virtual void RemoveToolbar()
//        {

//        }

//        public virtual void ItemClicked(string itemName)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void ShowForm(object imapWin)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void SetButton(object imapWin)
//        {
//            throw new NotImplementedException();
//        }


//        public virtual void ItemClicked(object sender, PluginEventArgs args)
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void BeforeLayerAdd()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void AfterLayerAdd()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void LayerZoom()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void LayerRemove()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void LayerPan()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void ChangedCurrentLayer()
//        {
//            throw new NotImplementedException();
//        }

//        public virtual void VisibilityChanged()
//        {
//            throw new NotImplementedException();
//        }


//        public virtual void MenuButtonClicked(string menuItem)
//        {
//        }

//        //public virtual void ToolButtonClicked(string toolButtonName)
//        //{  
//        //}
//    }
//}
