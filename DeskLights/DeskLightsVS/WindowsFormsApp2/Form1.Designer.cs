namespace DeskLights
{
    partial class DeskLights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskLights));
            this.Light1Button = new System.Windows.Forms.Button();
            this.Light2Button = new System.Windows.Forms.Button();
            this.Light3Button = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.Button();
            this.offButton = new System.Windows.Forms.Button();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Light1Button
            // 
            this.Light1Button.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Light1Button.Location = new System.Drawing.Point(33, 220);
            this.Light1Button.Name = "Light1Button";
            this.Light1Button.Size = new System.Drawing.Size(180, 50);
            this.Light1Button.TabIndex = 0;
            this.Light1Button.Text = "Light 1";
            this.Light1Button.UseVisualStyleBackColor = false;
            this.Light1Button.Click += new System.EventHandler(this.Light1Button_Click);
            // 
            // Light2Button
            // 
            this.Light2Button.Location = new System.Drawing.Point(321, 222);
            this.Light2Button.Name = "Light2Button";
            this.Light2Button.Size = new System.Drawing.Size(180, 50);
            this.Light2Button.TabIndex = 1;
            this.Light2Button.Text = "Light 2";
            this.Light2Button.UseVisualStyleBackColor = true;
            this.Light2Button.Click += new System.EventHandler(this.Light2Button_Click);
            // 
            // Light3Button
            // 
            this.Light3Button.Location = new System.Drawing.Point(595, 222);
            this.Light3Button.Name = "Light3Button";
            this.Light3Button.Size = new System.Drawing.Size(180, 50);
            this.Light3Button.TabIndex = 2;
            this.Light3Button.Text = "Light 3";
            this.Light3Button.UseVisualStyleBackColor = true;
            this.Light3Button.Click += new System.EventHandler(this.Light3Button_Click);
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(178, 71);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(180, 50);
            this.onButton.TabIndex = 3;
            this.onButton.Text = "On";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.OnButton_Click);
            // 
            // offButton
            // 
            this.offButton.Location = new System.Drawing.Point(452, 71);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(180, 50);
            this.offButton.TabIndex = 4;
            this.offButton.Text = "Off";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.OffButton_Click);
            // 
            // port
            // 
            this.port.PortName = "COM1000";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(654, 320);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // DeskLights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.Light3Button);
            this.Controls.Add(this.Light2Button);
            this.Controls.Add(this.Light1Button);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DeskLights";
            this.Text = "Desk Lights";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Light1Button;
        private System.Windows.Forms.Button Light2Button;
        private System.Windows.Forms.Button Light3Button;
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

