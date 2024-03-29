﻿namespace Villainous.WinForm
{
    partial class MainMenu
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
            this.LogoImg = new System.Windows.Forms.PictureBox();
            this.CreateGameBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.joinGameBtn = new System.Windows.Forms.Button();
            this.JoinPnl = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.NameJoinPanelLBL = new System.Windows.Forms.Label();
            this.gameCodeTxtBx = new System.Windows.Forms.TextBox();
            this.playerNameTxtBX = new System.Windows.Forms.TextBox();
            this.gameCodePanelLBL = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelJoinPanelBtn = new System.Windows.Forms.Button();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.gameCodeTextLbl = new System.Windows.Forms.Label();
            this.gameCodeLbl = new System.Windows.Forms.Label();
            this.playersListBx = new System.Windows.Forms.ListBox();
            this.playerReadyBtn = new System.Windows.Forms.Button();
            this.startGameBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoImg)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.JoinPnl.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoImg
            // 
            this.LogoImg.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogoImg.BackColor = System.Drawing.Color.Transparent;
            this.LogoImg.Image = global::Villainous.WinForm.Properties.Resources.VillainousLogo;
            this.LogoImg.Location = new System.Drawing.Point(336, 12);
            this.LogoImg.Name = "LogoImg";
            this.LogoImg.Size = new System.Drawing.Size(533, 140);
            this.LogoImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoImg.TabIndex = 0;
            this.LogoImg.TabStop = false;
            // 
            // CreateGameBTN
            // 
            this.CreateGameBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateGameBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateGameBTN.CausesValidation = false;
            this.CreateGameBTN.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateGameBTN.Location = new System.Drawing.Point(134, 3);
            this.CreateGameBTN.MaximumSize = new System.Drawing.Size(300, 40);
            this.CreateGameBTN.MinimumSize = new System.Drawing.Size(100, 35);
            this.CreateGameBTN.Name = "CreateGameBTN";
            this.CreateGameBTN.Size = new System.Drawing.Size(300, 35);
            this.CreateGameBTN.TabIndex = 1;
            this.CreateGameBTN.Text = "Create game";
            this.CreateGameBTN.UseVisualStyleBackColor = true;
            this.CreateGameBTN.Click += new System.EventHandler(this.CreateGameBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.joinGameBtn, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CreateGameBTN, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 556);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1136, 54);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // joinGameBtn
            // 
            this.joinGameBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.joinGameBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.joinGameBtn.CausesValidation = false;
            this.joinGameBtn.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.joinGameBtn.Location = new System.Drawing.Point(702, 3);
            this.joinGameBtn.MaximumSize = new System.Drawing.Size(300, 40);
            this.joinGameBtn.MinimumSize = new System.Drawing.Size(100, 35);
            this.joinGameBtn.Name = "joinGameBtn";
            this.joinGameBtn.Size = new System.Drawing.Size(300, 35);
            this.joinGameBtn.TabIndex = 2;
            this.joinGameBtn.Text = "Join game";
            this.joinGameBtn.UseVisualStyleBackColor = true;
            this.joinGameBtn.Click += new System.EventHandler(this.joinGameBtn_Click);
            // 
            // JoinPnl
            // 
            this.JoinPnl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JoinPnl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.JoinPnl.Controls.Add(this.tableLayoutPanel2);
            this.JoinPnl.Location = new System.Drawing.Point(283, 199);
            this.JoinPnl.Name = "JoinPnl";
            this.JoinPnl.Size = new System.Drawing.Size(629, 227);
            this.JoinPnl.TabIndex = 3;
            this.JoinPnl.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.NameJoinPanelLBL, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.gameCodeTxtBx, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.playerNameTxtBX, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.gameCodePanelLBL, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(629, 227);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // NameJoinPanelLBL
            // 
            this.NameJoinPanelLBL.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameJoinPanelLBL.Location = new System.Drawing.Point(3, 88);
            this.NameJoinPanelLBL.Name = "NameJoinPanelLBL";
            this.NameJoinPanelLBL.Size = new System.Drawing.Size(623, 26);
            this.NameJoinPanelLBL.TabIndex = 0;
            this.NameJoinPanelLBL.Text = "Name";
            this.NameJoinPanelLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameCodeTxtBx
            // 
            this.gameCodeTxtBx.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameCodeTxtBx.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameCodeTxtBx.Location = new System.Drawing.Point(114, 41);
            this.gameCodeTxtBx.Name = "gameCodeTxtBx";
            this.gameCodeTxtBx.Size = new System.Drawing.Size(400, 32);
            this.gameCodeTxtBx.TabIndex = 0;
            // 
            // playerNameTxtBX
            // 
            this.playerNameTxtBX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerNameTxtBX.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerNameTxtBX.Location = new System.Drawing.Point(114, 129);
            this.playerNameTxtBX.Name = "playerNameTxtBX";
            this.playerNameTxtBX.Size = new System.Drawing.Size(400, 32);
            this.playerNameTxtBX.TabIndex = 1;
            // 
            // gameCodePanelLBL
            // 
            this.gameCodePanelLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameCodePanelLBL.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameCodePanelLBL.Location = new System.Drawing.Point(3, 0);
            this.gameCodePanelLBL.Name = "gameCodePanelLBL";
            this.gameCodePanelLBL.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.gameCodePanelLBL.Size = new System.Drawing.Size(623, 26);
            this.gameCodePanelLBL.TabIndex = 0;
            this.gameCodePanelLBL.Text = "Gamecode";
            this.gameCodePanelLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cancelJoinPanelBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.JoinBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 179);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(623, 45);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // cancelJoinPanelBtn
            // 
            this.cancelJoinPanelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelJoinPanelBtn.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelJoinPanelBtn.Location = new System.Drawing.Point(46, 5);
            this.cancelJoinPanelBtn.Name = "cancelJoinPanelBtn";
            this.cancelJoinPanelBtn.Size = new System.Drawing.Size(219, 35);
            this.cancelJoinPanelBtn.TabIndex = 3;
            this.cancelJoinPanelBtn.Text = "Cancel";
            this.cancelJoinPanelBtn.UseVisualStyleBackColor = true;
            this.cancelJoinPanelBtn.Click += new System.EventHandler(this.cancelJoinPanelBtn_Click);
            // 
            // JoinBtn
            // 
            this.JoinBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JoinBtn.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.JoinBtn.Location = new System.Drawing.Point(357, 5);
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.Size = new System.Drawing.Size(219, 35);
            this.JoinBtn.TabIndex = 2;
            this.JoinBtn.Text = "Join game";
            this.JoinBtn.UseVisualStyleBackColor = true;
            this.JoinBtn.Click += new System.EventHandler(this.JoinBtn_Click);
            // 
            // gameCodeTextLbl
            // 
            this.gameCodeTextLbl.AutoSize = true;
            this.gameCodeTextLbl.BackColor = System.Drawing.Color.Transparent;
            this.gameCodeTextLbl.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameCodeTextLbl.Location = new System.Drawing.Point(134, 157);
            this.gameCodeTextLbl.Name = "gameCodeTextLbl";
            this.gameCodeTextLbl.Size = new System.Drawing.Size(127, 39);
            this.gameCodeTextLbl.TabIndex = 4;
            this.gameCodeTextLbl.Text = "Gamecode: ";
            this.gameCodeTextLbl.Visible = false;
            // 
            // gameCodeLbl
            // 
            this.gameCodeLbl.AutoSize = true;
            this.gameCodeLbl.BackColor = System.Drawing.Color.Transparent;
            this.gameCodeLbl.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameCodeLbl.Location = new System.Drawing.Point(248, 157);
            this.gameCodeLbl.Name = "gameCodeLbl";
            this.gameCodeLbl.Size = new System.Drawing.Size(32, 39);
            this.gameCodeLbl.TabIndex = 5;
            this.gameCodeLbl.Text = "#";
            this.gameCodeLbl.Visible = false;
            // 
            // playersListBx
            // 
            this.playersListBx.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playersListBx.FormattingEnabled = true;
            this.playersListBx.ItemHeight = 25;
            this.playersListBx.Location = new System.Drawing.Point(134, 198);
            this.playersListBx.Name = "playersListBx";
            this.playersListBx.Size = new System.Drawing.Size(868, 304);
            this.playersListBx.TabIndex = 6;
            this.playersListBx.Visible = false;
            // 
            // playerReadyBtn
            // 
            this.playerReadyBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerReadyBtn.CausesValidation = false;
            this.playerReadyBtn.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerReadyBtn.Location = new System.Drawing.Point(417, 508);
            this.playerReadyBtn.MaximumSize = new System.Drawing.Size(300, 40);
            this.playerReadyBtn.MinimumSize = new System.Drawing.Size(100, 35);
            this.playerReadyBtn.Name = "playerReadyBtn";
            this.playerReadyBtn.Size = new System.Drawing.Size(300, 35);
            this.playerReadyBtn.TabIndex = 3;
            this.playerReadyBtn.Text = "I\'m ready";
            this.playerReadyBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.playerReadyBtn.UseVisualStyleBackColor = true;
            this.playerReadyBtn.Visible = false;
            this.playerReadyBtn.Click += new System.EventHandler(this.playerReadyBtn_Click);
            // 
            // startGameBtn
            // 
            this.startGameBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.startGameBtn.CausesValidation = false;
            this.startGameBtn.Enabled = false;
            this.startGameBtn.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startGameBtn.Location = new System.Drawing.Point(418, 508);
            this.startGameBtn.MaximumSize = new System.Drawing.Size(300, 40);
            this.startGameBtn.MinimumSize = new System.Drawing.Size(100, 35);
            this.startGameBtn.Name = "startGameBtn";
            this.startGameBtn.Size = new System.Drawing.Size(300, 35);
            this.startGameBtn.TabIndex = 7;
            this.startGameBtn.Text = "Start the game";
            this.startGameBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.startGameBtn.UseVisualStyleBackColor = true;
            this.startGameBtn.Visible = false;
            this.startGameBtn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Villainous.WinForm.Properties.Resources.VillainousBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1136, 610);
            this.Controls.Add(this.playerReadyBtn);
            this.Controls.Add(this.gameCodeLbl);
            this.Controls.Add(this.gameCodeTextLbl);
            this.Controls.Add(this.JoinPnl);
            this.Controls.Add(this.LogoImg);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.playersListBx);
            this.Controls.Add(this.startGameBtn);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoImg)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.JoinPnl.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox LogoImg;
        private Button CreateGameBTN;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel JoinPnl;
        private Label gameCodePanelLBL;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox playerNameTxtBX;
        private Label NameJoinPanelLBL;
        private TextBox gameCodeTxtBx;
        private Label gameCodeTextLbl;
        private Label gameCodeLbl;
        private Button joinGameBtn;
        private ListBox playersListBx;
        private Button playerReadyBtn;
        private Button startGameBtn;
        private TableLayoutPanel tableLayoutPanel3;
        private Button cancelJoinPanelBtn;
        private Button JoinBtn;
    }
}