using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.EditorInput;

using Autodesk.AutoCAD.Ribbon;
using Autodesk.Windows;

//别名引用，防止同时存在于两个命名空间而导致的代码冲突
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using AcadWnd = Autodesk.AutoCAD.Windows;

namespace CustomDialog
{
    #region Here is the Event handler that is called when the control is clicked.
    public class AdskCommandHandler : System.Windows.Input.ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //is from a Ribbon Button?
            RibbonButton ribBtn = parameter as RibbonButton;
            if (ribBtn != null)
                Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.SendStringToExecute((String)ribBtn.CommandParameter, true, false, true);

            //is from a Ribbon Textbox?
            RibbonTextBox ribTxt = parameter as RibbonTextBox;
            if (ribTxt != null)
                System.Windows.Forms.MessageBox.Show(ribTxt.TextValue);
        }
    }
    #endregion

    public class CustomDialog:IExtensionApplication
    {
        [CommandMethod("createWomanPants")]
        public void womanPants()
        {
            FormNew form = new FormNew();
            //WomanPants form = new WomanPants();
            AcadApp.ShowModalDialog(form);
        }

        public void Initialize()
        {
            womanPants();
            //throw new NotImplementedException();
        }

        public void Terminate()
        {
            //throw new NotImplementedException();
        }
    }

    public class MyRibbon//:IExtensionApplication
    {
        private const String MY_TAB_ID = "MY_TAB_ID";

        [CommandMethod("addMyRibbon")]
        public void createRibbon()
        {
            //Get the AutoCAD Ribbon
            Autodesk.Windows.RibbonControl ribCntrl =
               Autodesk.AutoCAD.Ribbon.RibbonServices.RibbonPaletteSet.RibbonControl;
            //can also use Autodesk.Windows.ComponentManager.Ribbon;     

            //Create a tab
            RibbonTab ribTab = new RibbonTab();
            ribTab.Title = "女裤";
            ribTab.Id = MY_TAB_ID;

            // Add the tab to the ribbon.
            ribCntrl.Tabs.Add(ribTab);

            // Create and add a couple of panels. (Methods are below)
            AddPanel1(ribTab);
            AddPanel2(ribTab);

            //Make the tab active
            ribTab.IsActive = true;
        }

        private void AddPanel1(RibbonTab ribTab)
        {
            //create the panel source
            Autodesk.Windows.RibbonPanelSource ribSourcePanel = new RibbonPanelSource();
            ribSourcePanel.Title = "廓形";
            //now the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribSourcePanel;
            ribTab.Panels.Add(ribPanel);

            //create button 1
            Autodesk.Windows.RibbonButton ribButton1 = new RibbonButton();
            ribButton1.Text = "H型";
            ribButton1.CommandParameter = "REGISTERME ";
            ribButton1.ShowText = true;
            ribButton1.CommandHandler = new AdskCommandHandler();

            //now create button 2
            Autodesk.Windows.RibbonButton ribButton2 = new RibbonButton();
            ribButton2.Text = "Y型";
            ribButton2.CommandParameter = "UNREGISTERME ";
            ribButton2.ShowText = true;
            ribButton2.CommandHandler = new AdskCommandHandler();

            //create a tooltip
            Autodesk.Windows.RibbonToolTip ribToolTip = new RibbonToolTip();
            ribToolTip.Command = "REGISTERME";
            ribToolTip.Title = "Register me command";
            ribToolTip.Content = "Register this assembly on AutoCAD startup";
            ribToolTip.ExpandedContent = "Add the necessary registry key to allow this assembly to auto load on startup. Also check which event you should add handle to add custom ribbon on AutoCAD startup.";
            ribButton1.ToolTip = ribToolTip;

            //now add the 2 button with a RowBreak
            ribSourcePanel.Items.Add(ribButton1);
            ribSourcePanel.Items.Add(new RibbonRowBreak());
            ribSourcePanel.Items.Add(ribButton2);

            //now add and expanded panel (with 1 button)
            Autodesk.Windows.RibbonRowPanel ribExpPanel = new RibbonRowPanel();

            //and add it to source 
            ribSourcePanel.Items.Add(ribExpPanel);//needs to be here

            Autodesk.Windows.RibbonButton ribExpButton1 = new RibbonButton();
            ribExpButton1.Text = "A型";
            ribExpButton1.ShowText = true;
            ribExpButton1.CommandParameter = "LINE ";
            ribExpButton1.CommandHandler = new AdskCommandHandler();
            ribExpPanel.Items.Add(ribExpButton1);


            //ribSourcePanel.Items.Add(new RibbonPanelBreak());
            //ribSourcePanel.Items.Add(ribExpPanel);//needs to be above
        }

        private static void AddPanel2(RibbonTab ribTab)
        {
            //create the panel source
            Autodesk.Windows.RibbonPanelSource ribSourcePanel = new RibbonPanelSource();
            ribSourcePanel.Title = "裤长";
            //now the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribSourcePanel;
            ribTab.Panels.Add(ribPanel);

            //create a Ribbon text
            Autodesk.Windows.RibbonTextBox ribTxt = new RibbonTextBox();
            ribTxt.Width = 100;
            ribTxt.IsEmptyTextValid = false;
            ribTxt.InvokesCommand = true;
            ribTxt.CommandHandler = new AdskCommandHandler();

            //create a Ribbon List Button
            Autodesk.Windows.RibbonSplitButton ribListBtn = new RibbonSplitButton();
            Autodesk.Windows.RibbonButton ribButton1 = new RibbonButton();
            ribButton1.Text = "长裤";
            ribButton1.ShowText = true;
            ribButton1.CommandParameter = "LINE ";
            ribButton1.CommandHandler = new AdskCommandHandler();
            Autodesk.Windows.RibbonButton ribButton2 = new RibbonButton();
            ribButton2.Text = "九分裤";
            ribButton2.ShowText = true;
            ribButton2.CommandParameter = "CIRCLE ";
            ribButton2.CommandHandler = new AdskCommandHandler();
            ribListBtn.Text = "Some options";
            ribListBtn.ShowText = true;
            ribListBtn.Items.Add(ribButton1);
            ribListBtn.Items.Add(ribButton2);

            ribSourcePanel.Items.Add(ribTxt);
            ribSourcePanel.Items.Add(new RibbonRowBreak());
            ribSourcePanel.Items.Add(ribListBtn);
        }

        //This command will remove the ribbon
        [CommandMethod("removeMyRibbon")]
        public void removeRibbon()
        {
            Autodesk.Windows.RibbonControl ribCntrl = Autodesk.AutoCAD.Ribbon.RibbonServices.RibbonPaletteSet.RibbonControl;
            //find the custom tab using the Id
            for (int i = 0; i < ribCntrl.Tabs.Count; i++)
            {
                if (ribCntrl.Tabs[i].Id.Equals(MY_TAB_ID))
                {
                    ribCntrl.Tabs.Remove(ribCntrl.Tabs[i]);
                    return;
                }
            }
        }

        //public void Initialize()
        //{
        //    createRibbon();
        //    //throw new NotImplementedException();
        //}

        //public void Terminate()
        //{
        //    //throw new NotImplementedException();
        //}
    }

}