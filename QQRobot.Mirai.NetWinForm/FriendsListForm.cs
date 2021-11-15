using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQRobot.Mirai.NetWinForm
{
    public partial class FriendsListForm : Form
    {
        private string BotAddressText = ConfigurationSettings.AppSettings["MiraiBotServerUrl"].ToString();
        private string ChoiceType;
        public FriendsListForm(string botQQ, string botVerifyKey, string type = "friend")
        {
            InitializeComponent();
            this.ChoiceType = type;
            this.listView1.View = System.Windows.Forms.View.Details;    //报表模式
            this.listView1.GridLines = true;                 //显示表格线
            this.listView1.MultiSelect = true;            //允许多行选择
            this.listView1.FullRowSelect = true;             //整行选择
            this.listView1.CheckBoxes = true;                //显示复选框
            this.listView1.HideSelection = true;             //始终显示选中项,即使没焦点
            if (type.ToLower() == "friend")
            {
                InitFriendListView(botQQ, botVerifyKey);
            }
            else {
                InitGroupsListView(botQQ, botVerifyKey);
            }
        }
        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="botQQ"></param>
        /// <param name="botVerifyKey"></param>
        public async void InitFriendListView(string botQQ, string botVerifyKey) {
            try
            {
                using var bot = new MiraiBot
                {
                    Address = BotAddressText,
                    VerifyKey = botVerifyKey,
                    QQ = botQQ
                };
                await bot.LaunchAsync();
                var friendList = await AccountManager.GetFriendsAsync();
                this.listView1.Columns.Clear();  //好习惯，先清除再添加保证数据的一致性
                this.listView1.Columns.Add(new ColumnHeader() {
                    Text = "",
                    Width = 20
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "序号",
                    Width = 40,
                    TextAlign = HorizontalAlignment.Center
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "QQ号",
                    Width = 120,
                    TextAlign = HorizontalAlignment.Left
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "昵称",
                    Width = 120,
                    TextAlign = HorizontalAlignment.Left
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "备注",
                    Width = 120,
                    TextAlign = HorizontalAlignment.Left
                });
                this.listView1.Items.Clear();
                int rowIndex = 1;
                foreach (var item in friendList) {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(rowIndex.ToString());
                    lvi.SubItems.Add(item.Id);
                    lvi.SubItems.Add(item.NickName); 
                    lvi.SubItems.Add(item.Remark);
                    this.listView1.Items.Add(lvi);//最后进行添加  
                    rowIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:" + ex.ToString());
            }
        }

        public async void InitGroupsListView(string botQQ, string botVerifyKey) {
            try
            {
                using var bot = new MiraiBot
                {
                    Address = BotAddressText,
                    VerifyKey = botVerifyKey,
                    QQ = botQQ
                };
                await bot.LaunchAsync();
                var friendList = await AccountManager.GetGroupsAsync();
                this.listView1.Columns.Clear();  //好习惯，先清除再添加保证数据的一致性
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "",
                    Width = 20
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "序号",
                    Width = 40,
                    TextAlign = HorizontalAlignment.Center
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "群ID",
                    Width = 120,
                    TextAlign = HorizontalAlignment.Left
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "群昵称",
                    Width = 200,
                    TextAlign = HorizontalAlignment.Left
                });
                this.listView1.Columns.Add(new ColumnHeader()
                {
                    Text = "群权限",
                    Width = 80,
                    TextAlign = HorizontalAlignment.Center
                });
                this.listView1.Items.Clear();
                int rowIndex = 1;
                foreach (var item in friendList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(rowIndex.ToString());
                    lvi.SubItems.Add(item.Id);
                    lvi.SubItems.Add(item.Name);
                    string PermissionStr = "";
                    switch (item.Permission) {
                        case Permissions.Administrator:
                            PermissionStr = "管理员";
                            break;
                        case Permissions.Member:
                            PermissionStr = "成员";
                            break;
                        case Permissions.Owner:
                            PermissionStr = "创建者";
                            break;
                    }
                    lvi.SubItems.Add(PermissionStr);
                    this.listView1.Items.Add(lvi);//最后进行添加  
                    rowIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:" + ex.ToString());
            }
        }


        private void ChoiceBtn_Click(object sender, EventArgs e)
        {
            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < this.listView1.Items.Count; i++) {
                if (this.listView1.Items[i].Checked) {
                    hashtable.Add(this.listView1.Items[i].SubItems[2].Text, this.listView1.Items[i].SubItems[3].Text);
                }
            }
            if (hashtable.Count > 0)
            {
                MainForm mainForm = (MainForm)this.Owner;
                mainForm.SaveSelectFriendOrGroupsByList(this.ChoiceType, hashtable);
                this.Close();
            }
            else {
                MessageBox.Show("请先选择数据");
            }
        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
