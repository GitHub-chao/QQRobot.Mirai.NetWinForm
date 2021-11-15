
namespace QQRobot.Mirai.NetWinForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BotQQText = new System.Windows.Forms.TextBox();
            this.BotVerifyKeyText = new System.Windows.Forms.TextBox();
            this.BotAddressText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BuildConnectBtn = new System.Windows.Forms.Button();
            this.RunLogRichText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AutoReplyRichText = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TestConnectBtn = new System.Windows.Forms.Button();
            this.NeedSendFriendsLabel = new System.Windows.Forms.Label();
            this.FriendQQBox = new System.Windows.Forms.TextBox();
            this.StartFriendSendBtn = new System.Windows.Forms.Button();
            this.SendTimer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.FriendIntervalTimerBox = new System.Windows.Forms.TextBox();
            this.FriendIntervalTimerLabel = new System.Windows.Forms.Label();
            this.FriendSendNextLabel = new System.Windows.Forms.Label();
            this.GetFriendsBtn = new System.Windows.Forms.Button();
            this.GetGroupsBtn = new System.Windows.Forms.Button();
            this.NeedSendGroupsLabel = new System.Windows.Forms.Label();
            this.GroupsQQBox = new System.Windows.Forms.TextBox();
            this.GroupsSendNextLabel = new System.Windows.Forms.Label();
            this.GroupsIntervalTimerLabel = new System.Windows.Forms.Label();
            this.GroupsIntervalTimerBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.StartGroupsSendBtn = new System.Windows.Forms.Button();
            this.OpenBotBtn = new System.Windows.Forms.Button();
            this.SendGroupsTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BotQQText
            // 
            resources.ApplyResources(this.BotQQText, "BotQQText");
            this.BotQQText.Name = "BotQQText";
            // 
            // BotVerifyKeyText
            // 
            resources.ApplyResources(this.BotVerifyKeyText, "BotVerifyKeyText");
            this.BotVerifyKeyText.Name = "BotVerifyKeyText";
            // 
            // BotAddressText
            // 
            resources.ApplyResources(this.BotAddressText, "BotAddressText");
            this.BotAddressText.Name = "BotAddressText";
            this.BotAddressText.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // BuildConnectBtn
            // 
            resources.ApplyResources(this.BuildConnectBtn, "BuildConnectBtn");
            this.BuildConnectBtn.Name = "BuildConnectBtn";
            this.BuildConnectBtn.UseVisualStyleBackColor = true;
            this.BuildConnectBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // RunLogRichText
            // 
            resources.ApplyResources(this.RunLogRichText, "RunLogRichText");
            this.RunLogRichText.Name = "RunLogRichText";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // AutoReplyRichText
            // 
            resources.ApplyResources(this.AutoReplyRichText, "AutoReplyRichText");
            this.AutoReplyRichText.Name = "AutoReplyRichText";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // TestConnectBtn
            // 
            resources.ApplyResources(this.TestConnectBtn, "TestConnectBtn");
            this.TestConnectBtn.Name = "TestConnectBtn";
            this.TestConnectBtn.UseVisualStyleBackColor = true;
            this.TestConnectBtn.Click += new System.EventHandler(this.TestConnectBtn_Click);
            // 
            // NeedSendFriendsLabel
            // 
            resources.ApplyResources(this.NeedSendFriendsLabel, "NeedSendFriendsLabel");
            this.NeedSendFriendsLabel.Name = "NeedSendFriendsLabel";
            // 
            // FriendQQBox
            // 
            resources.ApplyResources(this.FriendQQBox, "FriendQQBox");
            this.FriendQQBox.Name = "FriendQQBox";
            // 
            // StartFriendSendBtn
            // 
            resources.ApplyResources(this.StartFriendSendBtn, "StartFriendSendBtn");
            this.StartFriendSendBtn.Name = "StartFriendSendBtn";
            this.StartFriendSendBtn.UseVisualStyleBackColor = true;
            this.StartFriendSendBtn.Click += new System.EventHandler(this.StartSendBtn_Click);
            // 
            // SendTimer1
            // 
            this.SendTimer1.Enabled = true;
            this.SendTimer1.Interval = 1000;
            this.SendTimer1.Tick += new System.EventHandler(this.SendTimer1_Tick);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // FriendIntervalTimerBox
            // 
            resources.ApplyResources(this.FriendIntervalTimerBox, "FriendIntervalTimerBox");
            this.FriendIntervalTimerBox.Name = "FriendIntervalTimerBox";
            // 
            // FriendIntervalTimerLabel
            // 
            resources.ApplyResources(this.FriendIntervalTimerLabel, "FriendIntervalTimerLabel");
            this.FriendIntervalTimerLabel.ForeColor = System.Drawing.Color.Red;
            this.FriendIntervalTimerLabel.Name = "FriendIntervalTimerLabel";
            // 
            // FriendSendNextLabel
            // 
            resources.ApplyResources(this.FriendSendNextLabel, "FriendSendNextLabel");
            this.FriendSendNextLabel.Name = "FriendSendNextLabel";
            // 
            // GetFriendsBtn
            // 
            resources.ApplyResources(this.GetFriendsBtn, "GetFriendsBtn");
            this.GetFriendsBtn.Name = "GetFriendsBtn";
            this.GetFriendsBtn.UseVisualStyleBackColor = true;
            this.GetFriendsBtn.Click += new System.EventHandler(this.GetFriendsBtn_Click);
            // 
            // GetGroupsBtn
            // 
            resources.ApplyResources(this.GetGroupsBtn, "GetGroupsBtn");
            this.GetGroupsBtn.Name = "GetGroupsBtn";
            this.GetGroupsBtn.UseVisualStyleBackColor = true;
            this.GetGroupsBtn.Click += new System.EventHandler(this.GetGroupsBtn_Click);
            // 
            // NeedSendGroupsLabel
            // 
            resources.ApplyResources(this.NeedSendGroupsLabel, "NeedSendGroupsLabel");
            this.NeedSendGroupsLabel.Name = "NeedSendGroupsLabel";
            // 
            // GroupsQQBox
            // 
            resources.ApplyResources(this.GroupsQQBox, "GroupsQQBox");
            this.GroupsQQBox.Name = "GroupsQQBox";
            // 
            // GroupsSendNextLabel
            // 
            resources.ApplyResources(this.GroupsSendNextLabel, "GroupsSendNextLabel");
            this.GroupsSendNextLabel.Name = "GroupsSendNextLabel";
            // 
            // GroupsIntervalTimerLabel
            // 
            resources.ApplyResources(this.GroupsIntervalTimerLabel, "GroupsIntervalTimerLabel");
            this.GroupsIntervalTimerLabel.ForeColor = System.Drawing.Color.Red;
            this.GroupsIntervalTimerLabel.Name = "GroupsIntervalTimerLabel";
            // 
            // GroupsIntervalTimerBox
            // 
            resources.ApplyResources(this.GroupsIntervalTimerBox, "GroupsIntervalTimerBox");
            this.GroupsIntervalTimerBox.Name = "GroupsIntervalTimerBox";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // StartGroupsSendBtn
            // 
            resources.ApplyResources(this.StartGroupsSendBtn, "StartGroupsSendBtn");
            this.StartGroupsSendBtn.Name = "StartGroupsSendBtn";
            this.StartGroupsSendBtn.UseVisualStyleBackColor = true;
            this.StartGroupsSendBtn.Click += new System.EventHandler(this.StartGroupsSendBtn_Click);
            // 
            // OpenBotBtn
            // 
            resources.ApplyResources(this.OpenBotBtn, "OpenBotBtn");
            this.OpenBotBtn.Name = "OpenBotBtn";
            this.OpenBotBtn.UseVisualStyleBackColor = true;
            this.OpenBotBtn.Click += new System.EventHandler(this.OpenBotBtn_Click);
            // 
            // SendGroupsTimer
            // 
            this.SendGroupsTimer.Tick += new System.EventHandler(this.SendGroupsTimer_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OpenBotBtn);
            this.Controls.Add(this.StartGroupsSendBtn);
            this.Controls.Add(this.GroupsSendNextLabel);
            this.Controls.Add(this.GroupsIntervalTimerLabel);
            this.Controls.Add(this.GroupsIntervalTimerBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.GroupsQQBox);
            this.Controls.Add(this.NeedSendGroupsLabel);
            this.Controls.Add(this.GetGroupsBtn);
            this.Controls.Add(this.GetFriendsBtn);
            this.Controls.Add(this.FriendSendNextLabel);
            this.Controls.Add(this.FriendIntervalTimerLabel);
            this.Controls.Add(this.FriendIntervalTimerBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.StartFriendSendBtn);
            this.Controls.Add(this.FriendQQBox);
            this.Controls.Add(this.NeedSendFriendsLabel);
            this.Controls.Add(this.TestConnectBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AutoReplyRichText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RunLogRichText);
            this.Controls.Add(this.BuildConnectBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BotAddressText);
            this.Controls.Add(this.BotVerifyKeyText);
            this.Controls.Add(this.BotQQText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BotQQText;
        private System.Windows.Forms.TextBox BotVerifyKeyText;
        private System.Windows.Forms.TextBox BotAddressText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BuildConnectBtn;
        private System.Windows.Forms.RichTextBox RunLogRichText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox AutoReplyRichText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button TestConnectBtn;
        private System.Windows.Forms.Label NeedSendFriendsLabel;
        private System.Windows.Forms.TextBox FriendQQBox;
        private System.Windows.Forms.Button StartFriendSendBtn;
        private System.Windows.Forms.Timer SendTimer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox FriendIntervalTimerBox;
        private System.Windows.Forms.Label FriendIntervalTimerLabel;
        private System.Windows.Forms.Label FriendSendNextLabel;
        private System.Windows.Forms.Button GetFriendsBtn;
        private System.Windows.Forms.Button GetGroupsBtn;
        private System.Windows.Forms.Label NeedSendGroupsLabel;
        private System.Windows.Forms.TextBox GroupsQQBox;
        private System.Windows.Forms.Label GroupsSendNextLabel;
        private System.Windows.Forms.Label GroupsIntervalTimerLabel;
        private System.Windows.Forms.TextBox GroupsIntervalTimerBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button StartGroupsSendBtn;
        private System.Windows.Forms.Button OpenBotBtn;
        private System.Windows.Forms.Timer SendGroupsTimer;
    }
}

