using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace VehicleRegistrationApplication
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        #region Properties
        public Form1()
        {
            InitializeComponent();
        }
        
        List<string> PlateList = new List<string>();
        string currentFileName = "demo_00.txt";

        #endregion
        #region Open Text File
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            string fileName = "demo_00.txt";
            OpenFileDialog OpenText = new OpenFileDialog();
            OpenText.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            OpenText.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult sr = OpenText.ShowDialog();
            if (sr == DialogResult.OK)
            {
                fileName = OpenText.FileName;
            }
            currentFileName = fileName;
            try
            {
                PlateList.Clear();
                using (StreamReader reader = new StreamReader(File.OpenRead(fileName)))
                {
                    while (!reader.EndOfStream)
                    {
                        PlateList.Add(reader.ReadLine());
                    }
                }
                DisplayList();
            }
            catch (IOException)
            {
                MessageBox.Show("File not opened");
            }
        }
        #endregion
        #region Save Button
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string fileName = "demo_00.txt";
            SaveFileDialog SaveText = new SaveFileDialog();
            SaveText.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            SaveText.Filter = "Txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult sr = SaveText.ShowDialog();
            if (sr == DialogResult.OK)
            {
                fileName = SaveText.FileName;
            }
            if (sr == DialogResult.Cancel)
            {
                fileName = SaveText.FileName;
            }
            SaveTextFile(fileName);
        }
        #endregion
        #region Valid Plate Method 
        private bool ValidPlate(string a)
        {
            if (PlateList.Exists(duplicateNumber => duplicateNumber.Equals(a)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion  
        #region Add button
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text) && (ValidPlate(textBoxInput.Text.ToUpper())))
            {
                PlateList.Add(textBoxInput.Text.ToUpper());
                statusLabel.Text = "Number plate added";
                ApplicationUtility();
                DisplayList();
            }
            else if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                statusLabel.Text = "Write a rego number in the text box to add it on the list";
            }
            else
            {
                statusLabel.Text = "Cannot add a duplicate number plate in the list";
            }
        }
        #endregion
        #region Delete Button
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            bool isEmpty = !PlateList.Any();
            if (listBoxDisplay.SelectedIndex != -1)
            {
                listBoxDisplay.SetSelected(listBoxDisplay.SelectedIndex, true);
                PlateList.RemoveAt(listBoxDisplay.SelectedIndex);
                ApplicationUtility();
                DisplayList();
                statusLabel.Text = "Number plate deleted";
            }
            else if (isEmpty)
            {
                statusLabel.Text = "List box is empty, add a number plate";
            }
            else
            {
                statusLabel.Text = "Please select a number to delete";
            }
        }
        #endregion
        #region Double-Click Remove Button
        private void ListBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                listBoxDisplay.SetSelected(listBoxDisplay.SelectedIndex, true);
                string message = "Do you want to remove the number plate from the list?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);
                bool isEmpty = !PlateList.Any();

                if (result == DialogResult.OK)
                {
                    PlateList.RemoveAt(listBoxDisplay.SelectedIndex);
                    ApplicationUtility();
                    DisplayList();
                    statusLabel.Text = "Number plate removed";
                }
                else
                {
                    statusLabel.Text = "You haven't selected a number plate to delete";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                statusLabel.Text = "List box is empty, add data first";
            }
        }
        #endregion
        #region Edit Button
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            if (listBoxDisplay.Items.Count < 0)
            {
                if (listBoxDisplay.SelectedIndex != -1)
                {
                    PlateList[listBoxDisplay.SelectedIndex] = textBoxInput.Text;
                    textBoxInput.Text = listBoxDisplay.SelectedIndex.ToString();
                    ApplicationUtility();
                    statusLabel.Text = "Number plate edited";
                    DisplayList();
                }
                else
                {
                    statusLabel.Text = "Please select a number plate to edit from the list box";
                }
            }
            else
            {
                statusLabel.Text = "List box is empty, add number plate(s) first";
            }

        }
        #endregion
        #region  Reset Button
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            PlateList.Clear();
            DisplayList();
            tagTextBoxOutput.Clear();
            ApplicationUtility();
            statusLabel.Text = "Data items cleared";
        }
        #endregion
        #region ListBox Display
        private void ListBoxDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            statusLabel.Text = "";
            if (listBoxDisplay.SelectedIndex != -1)
            {
                string dataItem = listBoxDisplay.SelectedItem.ToString();
                int dataItemIndex = listBoxDisplay.FindString(dataItem);
                textBoxInput.Text = PlateList[dataItemIndex].ToString();
                textBoxInput.Select();
            }
            else
            {
                statusLabel.Text = "List box is empty, add a number plate";
            }
        }
        #endregion
        #region Binary search
        private void ButtonBinary_Click(object sender, EventArgs e)
        {
            PlateList.Sort();
            if (PlateList.BinarySearch(textBoxInput.Text) >= 0)
            {
                MessageBox.Show("Number plate found");
            }
            else if (listBoxDisplay.Items.Count == 0)
            {
                MessageBox.Show("List box is empty, add number plate(s) first");
            }
            else if (listBoxDisplay.Items.Count > 0 && textBoxInput.Text == "")
            {
                MessageBox.Show("Select a number plate to search");
            }
            else
            {
                MessageBox.Show("Number plate not found");
                ApplicationUtility();
            }
        }
        #endregion
        #region Linear Search
        private void ButtonLinear_Click(object sender, EventArgs e)
        {
            string targetValue = textBoxInput.Text;
            if (listBoxDisplay.Items.Count > 0)
            {
                for (int i = 0; i < PlateList.Count; i++)
                {
                    if (PlateList[i] == targetValue)
                    {
                        statusLabel.Text = "Number plate found at index " + i;
                        listBoxDisplay.SelectedIndex = i;
                        return;
                    }
                    else if (textBoxInput.Text == "")
                    {
                        statusLabel.Text = "Select a number to search";
                    }
                    else
                    {
                        statusLabel.Text = "Number plate not found";
                        ApplicationUtility();
                        DisplayList();
                    }
                }
            }
            else
            {
                statusLabel.Text = "List box is empty, add number plate(s) first";
            }
        }
        #endregion
        #region Tag Button
        private void ButtonTag_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            try
            {
                bool isEmpty = !PlateList.Any();
                if (!listBoxDisplay.Text.StartsWith("z") && listBoxDisplay.SelectedIndex != -1)
                {
                    string taggedItem = listBoxDisplay.SelectedItem.ToString();
                    string prefix = "z" + taggedItem;
                    int taggedItemIndex = listBoxDisplay.FindString(taggedItem);
                    PlateList[taggedItemIndex] = prefix;
                    tagTextBoxOutput.Text = PlateList[taggedItemIndex];
                    ApplicationUtility();
                    DisplayList();
                    statusLabel.Text = "You have tagged a plate for investigation";
                }
                else if (listBoxDisplay.Text.StartsWith("z"))
                {
                    string unTagItem = listBoxDisplay.SelectedItem.ToString();
                    string removeTag = listBoxDisplay.Text.Remove(0, 1);
                    int unTagItemIndex = listBoxDisplay.FindString(unTagItem);
                    PlateList[unTagItemIndex] = removeTag;
                    tagTextBoxOutput.Clear();
                    ApplicationUtility();
                    DisplayList();
                    statusLabel.Text = "You have untagged a plate";
                }
                else if (isEmpty)
                {
                    statusLabel.Text = "List box is empty, add a rego plate first";
                }
                else
                {
                    statusLabel.Text = "Select an item to tag from the list box";
                }
            }
            catch (IndexOutOfRangeException)
            {
                statusLabel.Text = "Error! Try again";
            }
        }
        #endregion
        #region Save Text File Method
        private void SaveTextFile(string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    foreach (var plate in PlateList)
                    {
                        writer.WriteLine(plate);

                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File not saved");
            }
        }
        #endregion
        #region Form Closed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                int textFileNumber = int.Parse(Path.GetFileNameWithoutExtension(currentFileName).Remove(0, 5));
                textFileNumber++;
                String newValue;
                if (textFileNumber <= 9)
                {
                    newValue = "0" + textFileNumber.ToString();
                }
                else
                {
                    newValue = textFileNumber.ToString();
                }
                String newFileName = "demo_" + newValue + ".txt";
                SaveTextFile(newFileName);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please try again!");
            }
            catch
            {
                return;
            }
        }
        #endregion
        #region Utility Methods
        private void DisplayList()
        {
            listBoxDisplay.Items.Clear();
            PlateList.Sort();
            foreach (var plate in PlateList)
            {
                listBoxDisplay.Items.Add(plate);
            }
        }

        private void ApplicationUtility()
        {
            textBoxInput.Clear();
            textBoxInput.Focus();
        }
        #endregion
        #region Input Handling
        private void TextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
