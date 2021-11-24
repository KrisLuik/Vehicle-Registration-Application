
namespace VehicleRegistrationApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButtonTag = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonLinear = new System.Windows.Forms.Button();
            this.ButtonBinary = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.tagTextBoxOutput = new System.Windows.Forms.TextBox();
            this.listBoxDisplay = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStripMessage = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonTag
            // 
            this.ButtonTag.Location = new System.Drawing.Point(208, 44);
            this.ButtonTag.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonTag.Name = "ButtonTag";
            this.ButtonTag.Size = new System.Drawing.Size(94, 42);
            this.ButtonTag.TabIndex = 0;
            this.ButtonTag.Text = "Tag";
            this.toolTip1.SetToolTip(this.ButtonTag, "Tag a number plate for investigation");
            this.ButtonTag.UseVisualStyleBackColor = true;
            this.ButtonTag.Click += new System.EventHandler(this.ButtonTag_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(208, 115);
            this.ButtonOpen.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(94, 42);
            this.ButtonOpen.TabIndex = 1;
            this.ButtonOpen.Text = "Open";
            this.toolTip1.SetToolTip(this.ButtonOpen, "Open a text file");
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(208, 157);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(94, 42);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save";
            this.toolTip1.SetToolTip(this.ButtonSave, "Save a text file");
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(208, 199);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(94, 42);
            this.ButtonAdd.TabIndex = 3;
            this.ButtonAdd.Text = "Add";
            this.toolTip1.SetToolTip(this.ButtonAdd, "Add a number plate to listbox");
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(302, 115);
            this.ButtonEdit.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(94, 42);
            this.ButtonEdit.TabIndex = 4;
            this.ButtonEdit.Text = "Edit";
            this.toolTip1.SetToolTip(this.ButtonEdit, "Edit a number plate");
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonLinear
            // 
            this.ButtonLinear.Location = new System.Drawing.Point(302, 157);
            this.ButtonLinear.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLinear.Name = "ButtonLinear";
            this.ButtonLinear.Size = new System.Drawing.Size(94, 42);
            this.ButtonLinear.TabIndex = 5;
            this.ButtonLinear.Text = "Linear Search";
            this.toolTip1.SetToolTip(this.ButtonLinear, "Linear search a number plate");
            this.ButtonLinear.UseVisualStyleBackColor = true;
            this.ButtonLinear.Click += new System.EventHandler(this.ButtonLinear_Click);
            // 
            // ButtonBinary
            // 
            this.ButtonBinary.Location = new System.Drawing.Point(302, 199);
            this.ButtonBinary.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonBinary.Name = "ButtonBinary";
            this.ButtonBinary.Size = new System.Drawing.Size(94, 42);
            this.ButtonBinary.TabIndex = 6;
            this.ButtonBinary.Text = "Binary Search";
            this.toolTip1.SetToolTip(this.ButtonBinary, "Binary search a number plate");
            this.ButtonBinary.UseVisualStyleBackColor = true;
            this.ButtonBinary.Click += new System.EventHandler(this.ButtonBinary_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(302, 241);
            this.ButtonReset.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(94, 42);
            this.ButtonReset.TabIndex = 7;
            this.ButtonReset.Text = "Reset";
            this.toolTip1.SetToolTip(this.ButtonReset, "Clear all data fields");
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(208, 241);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(94, 42);
            this.ButtonDelete.TabIndex = 8;
            this.ButtonDelete.Text = "Delete";
            this.toolTip1.SetToolTip(this.ButtonDelete, "Delete a number plate from listbox");
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(9, 11);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxInput.MaxLength = 8;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(371, 20);
            this.textBoxInput.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxInput, "Textbox for user input");
            this.textBoxInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxInput_KeyPress);
            // 
            // tagTextBoxOutput
            // 
            this.tagTextBoxOutput.Location = new System.Drawing.Point(303, 45);
            this.tagTextBoxOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tagTextBoxOutput.Multiline = true;
            this.tagTextBoxOutput.Name = "tagTextBoxOutput";
            this.tagTextBoxOutput.ReadOnly = true;
            this.tagTextBoxOutput.Size = new System.Drawing.Size(94, 41);
            this.tagTextBoxOutput.TabIndex = 10;
            this.toolTip1.SetToolTip(this.tagTextBoxOutput, "Displays tagged number plate");
            // 
            // listBoxDisplay
            // 
            this.listBoxDisplay.FormattingEnabled = true;
            this.listBoxDisplay.Location = new System.Drawing.Point(9, 45);
            this.listBoxDisplay.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxDisplay.Name = "listBoxDisplay";
            this.listBoxDisplay.Size = new System.Drawing.Size(197, 238);
            this.listBoxDisplay.TabIndex = 11;
            this.toolTip1.SetToolTip(this.listBoxDisplay, "Displays all number plates");
            this.listBoxDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxDisplay_MouseClick);
            this.listBoxDisplay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBoxDisplay_MouseDoubleClick);
            // 
            // statusStripMessage
            // 
            this.statusStripMessage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStripMessage.Location = new System.Drawing.Point(0, 301);
            this.statusStripMessage.Name = "statusStripMessage";
            this.statusStripMessage.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStripMessage.Size = new System.Drawing.Size(401, 22);
            this.statusStripMessage.TabIndex = 12;
            this.statusStripMessage.Text = "statusStrip1";
            this.toolTip1.SetToolTip(this.statusStripMessage, "Status strip message displays here");
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 16);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 323);
            this.Controls.Add(this.statusStripMessage);
            this.Controls.Add(this.listBoxDisplay);
            this.Controls.Add(this.tagTextBoxOutput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonReset);
            this.Controls.Add(this.ButtonBinary);
            this.Controls.Add(this.ButtonLinear);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.ButtonTag);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Vehicle Registration Management";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStripMessage.ResumeLayout(false);
            this.statusStripMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonTag;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonLinear;
        private System.Windows.Forms.Button ButtonBinary;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox tagTextBoxOutput;
        private System.Windows.Forms.ListBox listBoxDisplay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStripMessage;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}

