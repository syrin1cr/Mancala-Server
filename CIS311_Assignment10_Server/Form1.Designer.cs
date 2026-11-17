namespace CIS311_Assignment10_Server
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmdStartServer = new Button();
            cmdStopServer = new Button();
            label3 = new Label();
            label5 = new Label();
            txtServerPort = new TextBox();
            txtMessages = new TextBox();
            groupBox1 = new GroupBox();
            grpGameControls = new GroupBox();
            groupBox2 = new GroupBox();
            radP2 = new RadioButton();
            radP1 = new RadioButton();
            btn0 = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btn10 = new Button();
            btn11 = new Button();
            label1 = new Label();
            groupBox1.SuspendLayout();
            grpGameControls.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmdStartServer
            // 
            cmdStartServer.Location = new Point(6, 66);
            cmdStartServer.Name = "cmdStartServer";
            cmdStartServer.Size = new Size(175, 23);
            cmdStartServer.TabIndex = 3;
            cmdStartServer.Text = "Server Start";
            cmdStartServer.UseVisualStyleBackColor = true;
            cmdStartServer.Click += cmdStartServer_Click;
            // 
            // cmdStopServer
            // 
            cmdStopServer.Location = new Point(6, 95);
            cmdStopServer.Name = "cmdStopServer";
            cmdStopServer.Size = new Size(175, 23);
            cmdStopServer.TabIndex = 4;
            cmdStopServer.Text = "Server Stop";
            cmdStopServer.UseVisualStyleBackColor = true;
            cmdStopServer.Click += cmdStopServer_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 153);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 7;
            label3.Text = "Server Status Messages";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 11;
            label5.Text = "Server Port";
            // 
            // txtServerPort
            // 
            txtServerPort.Location = new Point(6, 37);
            txtServerPort.Name = "txtServerPort";
            txtServerPort.Size = new Size(175, 23);
            txtServerPort.TabIndex = 13;
            txtServerPort.Text = "1000";
            // 
            // txtMessages
            // 
            txtMessages.Location = new Point(12, 171);
            txtMessages.Multiline = true;
            txtMessages.Name = "txtMessages";
            txtMessages.ReadOnly = true;
            txtMessages.ScrollBars = ScrollBars.Vertical;
            txtMessages.Size = new Size(482, 121);
            txtMessages.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtServerPort);
            groupBox1.Controls.Add(cmdStopServer);
            groupBox1.Controls.Add(cmdStartServer);
            groupBox1.Location = new Point(500, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(190, 126);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Network Settings:";
            // 
            // grpGameControls
            // 
            grpGameControls.Controls.Add(label1);
            grpGameControls.Controls.Add(groupBox2);
            grpGameControls.Location = new Point(500, 138);
            grpGameControls.Name = "grpGameControls";
            grpGameControls.Size = new Size(190, 154);
            grpGameControls.TabIndex = 15;
            grpGameControls.TabStop = false;
            grpGameControls.Text = "Game Controls";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radP2);
            groupBox2.Controls.Add(radP1);
            groupBox2.Location = new Point(6, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 56);
            groupBox2.TabIndex = 20;
            groupBox2.TabStop = false;
            groupBox2.Text = "Player:";
            // 
            // radP2
            // 
            radP2.AutoSize = true;
            radP2.Location = new Point(103, 22);
            radP2.Name = "radP2";
            radP2.Size = new Size(66, 19);
            radP2.TabIndex = 18;
            radP2.Text = "Player 2";
            radP2.UseVisualStyleBackColor = true;
            // 
            // radP1
            // 
            radP1.AutoSize = true;
            radP1.Checked = true;
            radP1.Location = new Point(6, 22);
            radP1.Name = "radP1";
            radP1.Size = new Size(66, 19);
            radP1.TabIndex = 19;
            radP1.TabStop = true;
            radP1.Text = "Player 1";
            radP1.UseVisualStyleBackColor = true;
            // 
            // btn0
            // 
            btn0.Location = new Point(81, 6);
            btn0.Name = "btn0";
            btn0.Size = new Size(64, 64);
            btn0.TabIndex = 16;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(151, 6);
            btn1.Name = "btn1";
            btn1.Size = new Size(64, 64);
            btn1.TabIndex = 17;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(221, 6);
            btn2.Name = "btn2";
            btn2.Size = new Size(64, 64);
            btn2.TabIndex = 18;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn3
            // 
            btn3.Location = new Point(291, 6);
            btn3.Name = "btn3";
            btn3.Size = new Size(64, 64);
            btn3.TabIndex = 19;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btn4
            // 
            btn4.Location = new Point(361, 6);
            btn4.Name = "btn4";
            btn4.Size = new Size(64, 64);
            btn4.TabIndex = 20;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Location = new Point(431, 6);
            btn5.Name = "btn5";
            btn5.Size = new Size(63, 134);
            btn5.TabIndex = 21;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn6
            // 
            btn6.Location = new Point(361, 76);
            btn6.Name = "btn6";
            btn6.Size = new Size(64, 64);
            btn6.TabIndex = 22;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn7
            // 
            btn7.Location = new Point(291, 76);
            btn7.Name = "btn7";
            btn7.Size = new Size(64, 64);
            btn7.TabIndex = 23;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Location = new Point(221, 76);
            btn8.Name = "btn8";
            btn8.Size = new Size(64, 64);
            btn8.TabIndex = 24;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btn9
            // 
            btn9.Location = new Point(151, 76);
            btn9.Name = "btn9";
            btn9.Size = new Size(64, 64);
            btn9.TabIndex = 25;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btn10
            // 
            btn10.Location = new Point(81, 76);
            btn10.Name = "btn10";
            btn10.Size = new Size(64, 64);
            btn10.TabIndex = 26;
            btn10.Text = "10";
            btn10.UseVisualStyleBackColor = true;
            btn10.Click += btn10_Click;
            // 
            // btn11
            // 
            btn11.Location = new Point(12, 6);
            btn11.Name = "btn11";
            btn11.Size = new Size(63, 134);
            btn11.TabIndex = 27;
            btn11.Text = "11";
            btn11.UseVisualStyleBackColor = true;
            btn11.Click += btn11_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(140, 15);
            label1.TabIndex = 21;
            label1.Text = "Player 1 always goes first.";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 301);
            Controls.Add(btn11);
            Controls.Add(btn10);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(btn0);
            Controls.Add(grpGameControls);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(txtMessages);
            Name = "ServerForm";
            Text = "Server";
            Load += ServerForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpGameControls.ResumeLayout(false);
            grpGameControls.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button cmdStartServer;
        private Button cmdStopServer;
        private Label label3;
        private Label label5;
        private TextBox txtServerPort;
        private TextBox txtMessages;
        private GroupBox groupBox1;
        private GroupBox grpGameControls;
        private GroupBox groupBox2;
        private RadioButton radP2;
        private RadioButton radP1;
        private Button btn0;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btn10;
        private Button btn11;
        private Label label1;
    }
}
