using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace test

{
    [Serializable]
    public partial class Form1 : Form
    {
        // Declare a Farm object to hold tractors
        Farm farm;

        // Constructor
        public Form1()
        {
            // Initialize the farm object
            farm = new Farm();
            InitializeComponent();

            // Attach event handler for double-clicking on a node in the treeView
            treeView1.NodeMouseDoubleClick += TreeView1_NodeMouseDoubleClick;
        }

        // Event handler for label1 click event
        private void label1_Click(object sender, EventArgs e)
        {
            // No action taken in this method
        }

        // Populate the treeView with tractors
        private void PopulateTreeView()
        {
            // Clear existing nodes in the treeView
            treeView1.Nodes.Clear();

            // Sort the tractors in the farm
            farm._tractors.Sort();

            // Iterate through each tractor and add it as a node in the treeView
            foreach (var tractor in farm._tractors)
            {
                TreeNode node = new TreeNode(tractor.ToString());
                treeView1.Nodes.Add(node);
            }
        }

        // Event handler for button1 click event (Add Tractor button)
        private void button1_Click(object sender, EventArgs e)
        {
            // Open Form2 to add a new tractor
            using (var form2 = new Form2())
            {
                if (DialogResult.OK == form2.ShowDialog())
                {
                    // Add the new tractor to the farm
                    farm.addTractor(form2.tractor);
                    // Update the treeView with the new tractor
                    PopulateTreeView();
                }
            }
        }

        // Event handler for double-clicking on a node in the treeView
        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                // Get the selected node and its index
                TreeNode selectedNode = e.Node;
                int selectedIndex = treeView1.Nodes.IndexOf(selectedNode);
                // Get the corresponding tractor object
                Tractor tractor = farm._tractors[selectedIndex];
                // Open Form2 to edit the selected tractor
                using (var form2 = new Form2())
                {
                    form2.tractor = tractor;
                    if (DialogResult.OK == form2.ShowDialog())
                    {
                        // Update the tractor in the farm with the edited tractor
                        farm._tractors[selectedIndex] = form2.tractor;
                        // Update the treeView with the edited tractor
                        PopulateTreeView();
                    }
                }
            }
        }

        // Event handler for toolStripButton1 click event (Serialize button)
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Serialize the farm object to XML and save it to a file
            XmlSerializer serializer = new XmlSerializer(typeof(Farm));
            using (FileStream stream = File.Create("serialized.xml"))
            {
                serializer.Serialize(stream, farm);
            }
        }

        // Event handler for toolStripButton2 click event (Deserialize button)
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Deserialize the farm object from the XML file and populate the treeView
            XmlSerializer serializer = new XmlSerializer(typeof(Farm));
            using (FileStream stream = File.OpenRead("serialized.xml"))
            {
                farm = (Farm)serializer.Deserialize(stream);
                PopulateTreeView();
            }
        }
    }
}
