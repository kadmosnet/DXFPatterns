namespace DXFPatterns
{
    partial class HatchSelector
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
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.TextBoxScale = new System.Windows.Forms.TextBox();
            this.TextBoxRotation = new System.Windows.Forms.TextBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Location = new System.Drawing.Point(165, 127);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(88, 24);
            this.ButtonCancel.TabIndex = 4;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonOk
            // 
            this.ButtonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonOk.Location = new System.Drawing.Point(68, 127);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(88, 24);
            this.ButtonOk.TabIndex = 3;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            // 
            // TextBoxScale
            // 
            this.TextBoxScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxScale.Location = new System.Drawing.Point(124, 84);
            this.TextBoxScale.Name = "TextBoxScale";
            this.TextBoxScale.Size = new System.Drawing.Size(129, 20);
            this.TextBoxScale.TabIndex = 19;
            this.TextBoxScale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxScale_KeyPress);
            // 
            // TextBoxRotation
            // 
            this.TextBoxRotation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxRotation.Location = new System.Drawing.Point(124, 50);
            this.TextBoxRotation.Name = "TextBoxRotation";
            this.TextBoxRotation.Size = new System.Drawing.Size(129, 20);
            this.TextBoxRotation.TabIndex = 18;
            this.TextBoxRotation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxRotation_KeyPress);
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "SOLID",
            "ANGLE",
            "ANSI31",
            "ANSI32",
            "ANSI33",
            "ANSI34",
            "ANSI35",
            "ANSI36",
            "ANSI37",
            "ANSI38",
            "AR-B816",
            "AR-B816C",
            "AR-B88",
            "AR-BRELM",
            "AR-BRSTD",
            "AR-CONC",
            "AR-HBONE",
            "AR-PARQ1",
            "AR-RROOF",
            "AR-RSHKE",
            "AR-SAND",
            "BOX",
            "BRASS",
            "BRICK",
            "BRSTONE",
            "CLAY",
            "CORK",
            "CROSS",
            "DASH",
            "DOLMIT",
            "DOTS",
            "EARTH",
            "ESCHER",
            "FLEX",
            "GRASS",
            "GRATE",
            "GRAVEL",
            "HEX",
            "HONEY",
            "HOUND",
            "INSUL",
            "ACAD_ISO02W100",
            "ACAD_ISO03W100",
            "ACAD_ISO04W100",
            "ACAD_ISO05W100",
            "ACAD_ISO06W100",
            "ACAD_ISO07W100",
            "ACAD_ISO08W100",
            "ACAD_ISO09W100",
            "ACAD_ISO10W100",
            "ACAD_ISO11W100",
            "ACAD_ISO12W100",
            "ACAD_ISO13W100",
            "ACAD_ISO14W100",
            "ACAD_ISO15W100",
            "LINE",
            "MUDST",
            "NET",
            "NET3",
            "PLAST",
            "PLASTI",
            "SACNCR",
            "SQUARE",
            "STARS",
            "STEEL",
            "SWAMP",
            "TRANS",
            "TRIANG",
            "ZIGZAG"});
            this.ComboBox1.Location = new System.Drawing.Point(124, 12);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(129, 21);
            this.ComboBox1.TabIndex = 17;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(9, 87);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(34, 13);
            this.Label3.TabIndex = 16;
            this.Label3.Text = "Scale";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(9, 53);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(89, 13);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "Rotation angle [°]";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 13);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "Pattern type";
            // 
            // HatchSelector
            // 
            this.AcceptButton = this.ButtonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(266, 168);
            this.Controls.Add(this.TextBoxScale);
            this.Controls.Add(this.TextBoxRotation);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HatchSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DXFReader.NET Demo Program - Hatch";
            this.Load += new System.EventHandler(this.HatchSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ButtonCancel;
        internal System.Windows.Forms.Button ButtonOk;
        internal System.Windows.Forms.TextBox TextBoxScale;
        internal System.Windows.Forms.TextBox TextBoxRotation;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}