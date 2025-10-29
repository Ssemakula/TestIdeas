using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestIdeas.Maps;

namespace TestIdeas
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            this.Text = "Test Form Loaded";
            string test1 = Environment.SpecialFolder.ApplicationData.ToString();
            string test2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string test3 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string test4 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string test5 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Special Folders:");
            sb.AppendLine($"1. ApplicationData (enum): {test1}");
            sb.AppendLine($"2. ApplicationData (path): {test2}");
            sb.AppendLine($"3. LocalApplicationData: {test3}");
            sb.AppendLine($"4. CommonApplicationData: {test4}");
            sb.AppendLine($"5. UserProfile: {test5}");

            resultTextBox.Text = sb.ToString();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(locationTextBox.Text))
            {
                try
                {
                    MapMethods.OpenMapInBrowser(placeTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    MapMethods.ShowMap(locationTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}