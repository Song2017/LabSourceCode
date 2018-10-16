using CommonSnappableTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitLoad();
        }

        private void InitLoad()
        {
            this.snapInModuleToolStripMenuItem.Click += SnapInModuleToolStripMenuItem_Click;

        }

        private void SnapInModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Allow user to select an assembly to load.
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.Contains("CommonSnappableTypes"))
                        MessageBox.Show("CommonSnappableTypes has no snap-ins!");

                    else if (!LoadExternalModule(dlg.FileName))
                        MessageBox.Show("Nothing implements IAppFunctionality!");
                }
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly theSnapInAsm = null;
            try
            {
                // Dynamically load the selected assembly.
                theSnapInAsm = Assembly.LoadFrom(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return foundSnapIn;
            }
            // Get all IAppFunctionality-compatible classes in assembly.
            var theClassTypes = from t in theSnapInAsm.GetTypes()
                                where t.IsClass &&
                                (t.GetInterface("IAppFunctionality") != null)
                                select t;
            // Now, create the object and call DoIt() method.
            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;
                // Use late binding to create the type.
                IAppFunctionality itfApp =
                (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);
            }
            return foundSnapIn;
        }
    }
}
