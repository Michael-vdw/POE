﻿namespace HeroesandGoblins
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
            this.btnUp = new System.Windows.Forms.Button();
            this.btnleft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblStats = new System.Windows.Forms.Label();
            this.labelMap = new System.Windows.Forms.Label();
            this.cbxEnemies = new System.Windows.Forms.ComboBox();
            this.btnAttack = new System.Windows.Forms.Button();
            this.rtbAttack = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.lblEnemies = new System.Windows.Forms.Label();
            this.btnShop1 = new System.Windows.Forms.Button();
            this.btnShop2 = new System.Windows.Forms.Button();
            this.btnShop3 = new System.Windows.Forms.Button();
            this.lblShop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(469, 288);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click_1);
            // 
            // btnleft
            // 
            this.btnleft.Location = new System.Drawing.Point(425, 317);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(75, 23);
            this.btnleft.TabIndex = 1;
            this.btnleft.Text = "Left";
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click_1);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(517, 317);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click_1);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(469, 346);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click_1);
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(377, 9);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(35, 13);
            this.lblStats.TabIndex = 4;
            this.lblStats.Text = "label1";
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMap.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMap.Location = new System.Drawing.Point(12, 9);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(70, 20);
            this.labelMap.TabIndex = 5;
            this.labelMap.Text = "label1";
            // 
            // cbxEnemies
            // 
            this.cbxEnemies.FormattingEnabled = true;
            this.cbxEnemies.Location = new System.Drawing.Point(12, 417);
            this.cbxEnemies.Name = "cbxEnemies";
            this.cbxEnemies.Size = new System.Drawing.Size(422, 21);
            this.cbxEnemies.TabIndex = 6;
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(440, 417);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(75, 23);
            this.btnAttack.TabIndex = 7;
            this.btnAttack.Text = "Attack";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // rtbAttack
            // 
            this.rtbAttack.Location = new System.Drawing.Point(602, 193);
            this.rtbAttack.Name = "rtbAttack";
            this.rtbAttack.Size = new System.Drawing.Size(186, 247);
            this.rtbAttack.TabIndex = 8;
            this.rtbAttack.Text = "";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(521, 417);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(521, 388);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 10;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // lblEnemies
            // 
            this.lblEnemies.AutoSize = true;
            this.lblEnemies.Location = new System.Drawing.Point(12, 336);
            this.lblEnemies.Name = "lblEnemies";
            this.lblEnemies.Size = new System.Drawing.Size(35, 13);
            this.lblEnemies.TabIndex = 11;
            this.lblEnemies.Text = "label1";
            // 
            // btnShop1
            // 
            this.btnShop1.Location = new System.Drawing.Point(602, 38);
            this.btnShop1.Name = "btnShop1";
            this.btnShop1.Size = new System.Drawing.Size(186, 23);
            this.btnShop1.TabIndex = 12;
            this.btnShop1.Text = "button1";
            this.btnShop1.UseVisualStyleBackColor = true;
            this.btnShop1.Click += new System.EventHandler(this.btnShop1_Click);
            // 
            // btnShop2
            // 
            this.btnShop2.Location = new System.Drawing.Point(602, 67);
            this.btnShop2.Name = "btnShop2";
            this.btnShop2.Size = new System.Drawing.Size(186, 23);
            this.btnShop2.TabIndex = 13;
            this.btnShop2.Text = "button2";
            this.btnShop2.UseVisualStyleBackColor = true;
            this.btnShop2.Click += new System.EventHandler(this.btnShop2_Click);
            // 
            // btnShop3
            // 
            this.btnShop3.Location = new System.Drawing.Point(602, 96);
            this.btnShop3.Name = "btnShop3";
            this.btnShop3.Size = new System.Drawing.Size(186, 23);
            this.btnShop3.TabIndex = 14;
            this.btnShop3.Text = "button3";
            this.btnShop3.UseVisualStyleBackColor = true;
            this.btnShop3.Click += new System.EventHandler(this.btnShop3_Click);
            // 
            // lblShop
            // 
            this.lblShop.AutoSize = true;
            this.lblShop.Location = new System.Drawing.Point(685, 22);
            this.lblShop.Name = "lblShop";
            this.lblShop.Size = new System.Drawing.Size(32, 13);
            this.lblShop.TabIndex = 15;
            this.lblShop.Text = "Shop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblShop);
            this.Controls.Add(this.btnShop3);
            this.Controls.Add(this.btnShop2);
            this.Controls.Add(this.btnShop1);
            this.Controls.Add(this.lblEnemies);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.rtbAttack);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.cbxEnemies);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnleft);
            this.Controls.Add(this.btnUp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnleft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Label labelMap;
        private System.Windows.Forms.ComboBox cbxEnemies;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.RichTextBox rtbAttack;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label lblEnemies;
        private System.Windows.Forms.Button btnShop1;
        private System.Windows.Forms.Button btnShop2;
        private System.Windows.Forms.Button btnShop3;
        private System.Windows.Forms.Label lblShop;
    }
}

