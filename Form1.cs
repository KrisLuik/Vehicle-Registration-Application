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

// Developer: Kristiin Tribbeck
// Program: Vehicle Registration Application
// Application that logs registration plates in a large city car park
// ID: 30045325
// Date: 23/11/2021

namespace VehicleRegistrationApplication
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        // Q2: The prototype must use a List<> data structure of data type “string”.
        #region Properties
        public Form1()
        {
            InitializeComponent();
        }

        List<string> PlateList = new List<string>();
        string currentFileName = "demo_00.txt";

        #endregion
        // Q3: When the OPEN button is clicked the user can select different data from pre-saved text files. 
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
        // Q12: This method will open a save dialog box and allow the user to save all the data back to a text file.
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
        // No duplicates method.
        #region Valid Plate Method 
        // Method stops the user from entering duplicate numbers to list box.
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
        // Q4: The data will be added to the List<> and the TextBox will be cleared, and the cursor will focus in the TextBox.
        #region Add button
        // Adds new rego plate to list box.
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text) && (ValidPlate(textBoxInput.Text)))
            {
                PlateList.Add(textBoxInput.Text);
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
        // Q5: The data will be removed from the List<> and the TextBox will be cleared, and the cursor will focus in the TextBox.
        #region Delete Button and Double-Click Delete Method

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            bool isEmpty = !PlateList.Any();
            if (listBoxDisplay.SelectedIndex != -1 || PlateList.Contains(textBoxInput.Text))
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
        }
        
        // Double-Click Delete Button
        private void ListBoxDisplay_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                listBoxDisplay.SetSelected(listBoxDisplay.SelectedIndex, true);
                string message = "Do you want to remove the number plate from the list?";
                string title = "Close Window";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.OK)
                {
                    PlateList.RemoveAt(listBoxDisplay.SelectedIndex);
                    ApplicationUtility();
                    DisplayList();
                    statusLabel.Text = "Number plate removed";
                }
                else if (result == DialogResult.Cancel)
                {
                    statusLabel.Text = "Number plate NOT removed";
                    ApplicationUtility();
                    DisplayList();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                statusLabel.Text = "";
            }
        }
        #endregion
        // Q6: The updated information is written back to the List<> and the TextBox is cleared, and the cursor refocuses in the TextBox.
        #region Edit Button

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            if (textBoxInput.Text.Length > 0)
            {
                if (listBoxDisplay.Items.Count > 0 || listBoxDisplay.SelectedIndex > 0)
                {
                    if (listBoxDisplay.SelectedIndex != -1)
                    {
                        if (!PlateList.Contains(textBoxInput.Text))
                        {
                            PlateList[listBoxDisplay.SelectedIndex] = textBoxInput.Text;
                            textBoxInput.Text = listBoxDisplay.SelectedItem.ToString();
                            listBoxDisplay.FindString(textBoxInput.Text);
                            textBoxInput.Clear();
                            statusLabel.Text = "Number plate edited";
                            DisplayList();
                        }
                        else
                        {
                            statusLabel.Text = "Cannot add duplicates";
                            ApplicationUtility();
                        }
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
            else
            {
                statusLabel.Text = "Text box cannot be empty";
            }
        }
        #endregion
        // Q7: Reset button to clear all the data items from the List<>. The ListBox and TextBox should also be cleared.
        #region  Reset Button
        // Clears all data items.
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            if (textBoxInput.Text != "" || listBoxDisplay.Items.Count != 0)
            {


                PlateList.Clear();
                DisplayList();
                tagTextBoxOutput.Clear();
                ApplicationUtility();
                statusLabel.Text = "Data items cleared";
            }
            else
            {
                statusLabel.Text = "Nothing to clear";
            }
        }
        #endregion
        // Q8: Single Data Display, when a data item is selected from the ListBox on the left, the information is displayed in the TextBox on the right.
        #region ListBox Display
        // Displays all rego plates in listbox.
        private void ListBoxDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            statusLabel.Text = "";
            bool isEmpty = !PlateList.Any();
            if (listBoxDisplay.SelectedIndex != -1)
            {
                string dataItem = listBoxDisplay.SelectedItem.ToString();
                int dataItemIndex = listBoxDisplay.FindString(dataItem);
                textBoxInput.Text = PlateList[dataItemIndex].ToString();
                textBoxInput.Focus();
            }
            else if (listBoxDisplay.Items.Count > 0)
            {
                statusLabel.Text = "Select a number plate";
            }
            else if (isEmpty)
            {
                statusLabel.Text = "List box is empty, add a number plate";
            }
        }
        #endregion
        // Q10: To find a specific rego plate the user will type the information into the TextBox and click the BINARY SEARCH button. 
        #region Binary search
        // Searches for a specific rego plate using binary search method.
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
                ApplicationUtility();
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
        // Q11: Search button that implements a linear search algorithm. Confirmation message displayed if rego found/not found. 
        #region Linear Search
        // Searches for specific rego plate using linear search method.
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
                    else if (String.IsNullOrWhiteSpace(targetValue))
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
                ApplicationUtility();
            }
        }
        #endregion
        // Q13: Create tag method and associated TAG button to mark a rego plate.
        // When a rego plate is selected from the ListBox and “tagged” an additional character value “z” will be prefixed to the rego plate.
        #region Tag Button
        // Tags and un-tags a rego plate for future investigation.
        // Tagged plate appears in read only text box.
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
        // Q12: This method will open a save dialog box and allow the user to save all the data back to a text file.
        // The dialog box must have a filter to display text files only. Method saves data to a text file and auto-increments the text file demo_##.txt.
        #region Save Text File and Form Closed Method
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
            catch (System.ArgumentException)
            {

            }
        }

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

        // Q9: Clears the list box, sorts the list then iterates through the list and displays the items in the list box.
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
        // Clears the text box and sets the focus back to text box.
        private void ApplicationUtility()
        {
            textBoxInput.Clear();
            textBoxInput.Focus();
        }
        #endregion

        // Converts all input to text box to uppercase.
        // Input only accepts keyboard functions, letters, digits, and hyphens.
        #region Input Handling

        private void TextBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxInput.CharacterCasing = CharacterCasing.Upper;
            if (!(char.IsControl(e.KeyChar) || char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
