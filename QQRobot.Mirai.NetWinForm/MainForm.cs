﻿using Mirai.Net.Common;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Timers;
using QQRobot.Mirai.NetWinForm.Helper;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Windows.Documents;
using Mirai.Net.Data.Messages;
using PinDuoDuo.Models;
using Mirai.Net.Data.Exceptions;
using System.Diagnostics;
using QQRobot.Mirai.NetWinForm.Service;

namespace QQRobot.Mirai.NetWinForm
{
    public partial class MainForm : Form
    {
        #region 变量定义
        /// <summary>
        /// Mirai.Net服务所在文件夹地址
        /// </summary>
        private string MiraiBotServerFile = ConfigurationSettings.AppSettings["MiraiBotServerFile"].ToString();
        /// <summary>
        /// 优惠券获取地址
        /// </summary>
        private string CouponSerUrl = ConfigurationSettings.AppSettings["CouponSerUrl"].ToString();
        /// <summary>
        /// 拼多多商品列表
        /// </summary>
        public List<goods_basic_detail_List> P_GoodsList = new List<goods_basic_detail_List>();
        /// <summary>
        /// 发送QQ定时默认间隔
        /// </summary>
        public int FriendTimerInterval = ConfigurationSettings.AppSettings["FriendTimerInterval"].ToInt();
        /// <summary>
        /// 是否连接成功
        /// </summary>
        public bool IsConnnectSuccess = false;

        private int BotServerProcessID = 0;
        #endregion

        public MainForm()
        {
            InitializeComponent();
            // 解决线程间操作无效: 从不是创建控件“XXXXXX”的线程
            CheckForIllegalCrossThreadCalls = false;

            this.BotAddressText.Text = ConfigurationSettings.AppSettings["MiraiBotServerUrl"].ToString();
            this.FriendIntervalTimerBox.Text = FriendTimerInterval.ToString();

            // 配置定时器， 1秒 = 1000 毫秒
            SendTimer1.Enabled = false;
            SendTimer1.Interval = this.FriendIntervalTimerBox.Text.ToInt() * 1000;
            SendGroupsTimer.Enabled = false;
            SendGroupsTimer.Interval = this.FriendIntervalTimerBox.Text.ToInt() * 1000;
        }

        //建立一个委托来实现非创建控件的线程更新控件
        public delegate void AsynUpdateUI(string log);
        /// <summary>
        /// 建立连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(BotAddressText.Text)) {
                MessageBox.Show("机器人地址不能为空");
            }
            else if(string.IsNullOrEmpty(BotQQText.Text)) {
                MessageBox.Show("机器人QQ不能为空");
            }
            else if (string.IsNullOrEmpty(BotVerifyKeyText.Text))
            {
                MessageBox.Show("机器人QQ不能为空");
            }
            else
            {
                BuildConnect();
            }
        }

        public async void BuildConnect()
        {
            this.BuildConnectBtn.Enabled = false;
            this.BuildConnectBtn.Text = "连接中...";
            
            var exit = new ManualResetEvent(false);
            using var bot = new MiraiBot
            {
                Address = BotAddressText.Text,
                VerifyKey = BotVerifyKeyText.Text,
                QQ = BotQQText.Text
            };

            var task = Task.Run(() =>
            {
                bot.LaunchAsync();
            });

            await task;

            bot.MessageReceived
               .OfType<FriendMessageReceiver>()
               .Subscribe(async x =>
               {
                   AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
                   updateUI.Invoke("好友消息>>>>" + x.Sender.NickName + "("+x.Sender.Id+")");
                   updateUI.Invoke("/r/n消息:" + x.MessageChain.OfType<PlainMessage>().First().Text);
                   await x.Sender.SendFriendMessageAsync("你是谁");
               });

            bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(async x =>
                {
                    LogHelper.Info("群组消息");
                    LogHelper.Info(JsonConvert.SerializeObject(x));
                    if (x.Sender.Group.Id == "754335459") {
                        await x.Sender.Group.SendGroupMessageAsync("回去上班去");
                    }
                });

            if (task.Status == TaskStatus.RanToCompletion) {
                this.BuildConnectBtn.Text = "连接成功";
            }
            else {
                this.BuildConnectBtn.Text = "连接失败";
                this.BuildConnectBtn.Enabled = true;
            }

            exit.WaitOne();
        }
        /// <summary>
        /// 打开机器人服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBotBtn_Click(object sender, EventArgs e)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory + @"MiraiNetService";
            string strDirPath = System.IO.Path.GetDirectoryName(str);
            string strFilePath = System.IO.Path.GetFileName(str);
            string command = "mcl.cmd";
            Task.Run(()=> {
                AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
                try
                {
                    updateUI.Invoke("正在打开服务，请稍等...");
                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = str;
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.UseShellExecute = false;     //是否使用操作系统shell启动
                    process.StartInfo.CreateNoWindow = true;        //不显示程序窗口
                    process.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
                    process.StartInfo.RedirectStandardInput = true;  //接受来自调用程序的输入信息
                    process.StartInfo.RedirectStandardError = true;  //重定向标准错误输出

                    process.Start();
                    BotServerProcessID = process.Id;
                    process.StandardInput.WriteLine(command);   //向cmd窗口发送输入信息，&exit意思为不论command命令执行成功与否，接下来都执行exit这句
                    process.StandardInput.AutoFlush = true;

                    process.BeginOutputReadLine();
                    // 为异步获取订阅事件  
                    process.OutputDataReceived +=  new DataReceivedEventHandler(process_OutputDataReceived);
                    //string output = process.StandardOutput.ReadToEnd();  //获取cmd的输出信息
                    process.WaitForExit();
                    process.Close();
                    process.Dispose();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            });
        }

        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
            // 这里仅做输出的示例，实际上您可以根据情况取消获取命令行的内容  
            if (e.Data.IndexOf("mirai-console started successfully") >= 0) {
                updateUI.Invoke("服务已开启。");
            }
        }

        /// <summary>
        /// 测试连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestConnectBtn_Click(object sender, EventArgs e)
        {
            TestConnectBtnClickMain();
        }

        private void TestConnectBtnClickMainProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
            // 这里仅做输出的示例，实际上您可以根据情况取消获取命令行的内容  
            //if (e.Data.IndexOf("mirai-console started successfully") >= 0)
            //{

            //}
            updateUI.Invoke("登录中" + e.Data);
        }

        private async Task TestConnectBtnClickMain()
        {
            try
            {
                using var bot = new MiraiBot
                {
                    Address = BotAddressText.Text,
                    VerifyKey = BotVerifyKeyText.Text,
                    QQ = BotQQText.Text
                };
                await bot.LaunchAsync();
                IsConnnectSuccess = true;
                MessageBox.Show("测试连接成功");
            }
            catch (InvalidResponseException ex)
            {
                MessageBox.Show("连接失败：请检查是否开启当前QQ的Bot");
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:" + ex.ToString());
            }

            //try
            //{
            //    if (BotServerProcessID > 0)
            //    {
            //        var process = Process.GetProcessById(BotServerProcessID);
            //        MessageBox.Show(process.GetCommandLineArgs());

            //        string command = "/login 2770434195 chao@123";

            //        //process.StartInfo.RedirectStandardOutput = true;  //由调用程序获取输出信息
            //        //process.StartInfo.RedirectStandardInput = true;  //接受来自调用程序的输入信息
            //        //process.StartInfo.RedirectStandardError = true;  //重定向标准错误输出

            //        //process.Start();
            //        process.StandardInput.WriteLine(command);   //向cmd窗口发送输入信息，&exit意思为不论command命令执行成功与否，接下来都执行exit这句
            //        process.StandardInput.AutoFlush = true;
            //        process.BeginOutputReadLine();
            //        process.OutputDataReceived += new DataReceivedEventHandler(TestConnectBtnClickMainProcessOutputDataReceived);
            //        process.WaitForExit();
            //        process.Close();
            //        process.Dispose();
            //    }
            //    else {
            //        MessageBox.Show("请先打开Bot服务");
            //    }
            //}
            //catch (InvalidResponseException ex) {
            //    MessageBox.Show("连接失败：请检查是否开启当前QQ的Bot");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("异常:" + ex.ToString());
            //}
        }

        /// <summary>
        /// 消息推送主方法
        /// </summary>
        /// <param name="messages1"></param>
        /// <param name="MsgToType">friend：好友;Groups ： 群</param>
        private async void SendMessageBase(MessageBase[] messages1, string MsgToType = "friend")
        {
            try
            {
                using var bot = new MiraiBot
                {
                    Address = BotAddressText.Text,
                    VerifyKey = BotVerifyKeyText.Text,
                    QQ = BotQQText.Text
                };
                await bot.LaunchAsync();
                if (MsgToType == "friend")
                {
                    string[] friendQQs = this.FriendQQBox.Text.Split(',');
                    for (int fi = 0; fi < friendQQs.Length; fi++)
                    {
                        string sendQQ = friendQQs[fi];
                        await MessageManager.SendFriendMessageAsync(sendQQ, messages1);
                    }
                }
                else {
                    string[] groupQQs = this.GroupsQQBox.Text.Split(',');
                    for (int gi = 0; gi < groupQQs.Length; gi++)
                    {
                        string sendQQ = groupQQs[gi];
                        await MessageManager.SendGroupMessageAsync(sendQQ, messages1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        

        private async void SendMsgBtnEvent(string message = "") {
            try
            {
                using var bot = new MiraiBot
                {
                    Address = BotAddressText.Text,
                    VerifyKey = BotVerifyKeyText.Text,
                    QQ = BotQQText.Text
                };
                await bot.LaunchAsync();
                await MessageManager.SendFriendMessageAsync("2094835564", message == "" ? "你好呀" : message);
            }
            catch (Exception ex) {
                MessageBox.Show("异常:" + ex.ToString());
            }
        }

        /// <summary>
        /// 更新富文本控件
        /// </summary>
        /// <param name="msg"></param>
        private void UpdateRunLogRichText(string msg) {
            this.RunLogRichText.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ">>>:" + msg + System.Environment.NewLine;
        }

        /// <summary>
        /// 开启QQ定时发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendTimer1_Tick(object sender, EventArgs e)
        {
            AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
            try
            {
                if (P_GoodsList.Count <= 0)
                {
                    GetPinduoduoGoods();
                }
                if (P_GoodsList.Count > 0)
                {
                    var model = P_GoodsList[0];
                    Goods_DetailAndPromotion goodDetails = GetPinduoduoGoodDetail(model.goods_sign, model.search_id);
                    if (goodDetails != null)
                    {
                        string goodDesc = goodDetails.Detail.goods_desc;
                        if (goodDetails.Detail.material_list != null)
                        {
                            var material = goodDetails.Detail.material_list.FirstOrDefault(x => x.type == 1);
                            if (material != null)
                            {
                                goodDesc = material.text_list[0];
                            }
                        }
                        //new FaceMessage()
                        //{
                        //    FaceId = "144",
                        //    Name = "喝彩"
                        //}
                        List<MessageBase> messages = new List<MessageBase> {
                                new PlainMessage()
                                {
                                    Text = goodDesc  + "\n"
                                },
                                new FaceMessage()
                                {
                                    FaceId="63",
                                    Name="玫瑰"
                                },
                                new PlainMessage()
                                {
                                    Text = "到手价： "+ Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100) - (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100), 2) +"元\n"
                                },
                                new ImageMessage()
                                {
                                    Url = goodDetails.Detail.goods_image_url
                                },
                                new PlainMessage()
                                {
                                    Text = "\n下单链接： "+ goodDetails.Promotion.short_url
                                },
                            };
                        updateUI.Invoke("QQ发送商品：" + CommonUtils.HtmlToText(goodDesc));
                        SendGoodsRecordService send = new SendGoodsRecordService();
                        send.AddSendGoodsRecord(new Business.Model.BOT_SENDGOODSRECORD()
                        {
                            GoodsDesc = goodDesc,
                            GoodsHasCoupon = goodDetails.Detail.has_coupon ? "Y" : "N",
                            GoodsName = goodDetails.Detail.goods_name,
                            GoodsShareDesc = goodDesc,
                            GoodsOrderUrl = goodDetails.Promotion.short_url,
                            GoodsUrl = goodDetails.Promotion.url,
                            GoodsSignID = goodDetails.Detail.goods_sign,
                            GoodsOptID = goodDetails.Detail.opt_id.ToStr(),
                            GoodsOptName = goodDetails.Detail.opt_name,
                            GoodsMinGroupPrice = Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100), 2),
                            GoodsMinNormalPrice = Math.Round((goodDetails.Detail.min_normal_price.ObjToDecimal() / 100), 2),
                            GoodsMinOrderPrice = Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100) - (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100), 2),
                            CouponPrice = (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100).ObjToDecimal(),
                            SendToPlatform = "QQ",
                            BrandName = goodDetails.Detail.brand_name,
                            GoodsSalesTip = goodDetails.Detail.sales_tip,
                            MerchantType = goodDetails.Detail.merchant_type == 1 ? "个人店" : goodDetails.Detail.merchant_type == 2 ? "企业店" : goodDetails.Detail.merchant_type == 3 ? "旗舰店" : goodDetails.Detail.merchant_type == 4 ? "专卖店" : goodDetails.Detail.merchant_type == 5 ? "专营店" : goodDetails.Detail.merchant_type == 6 ? "普通店" : "",
                            ShopID = goodDetails.Detail.mall_id.ToStr(),
                            ShopName = goodDetails.Detail.mall_name,
                            ShopLogo = goodDetails.Detail.mall_img_url,
                            Platform = "PinDuoduo",
                            PreferentialLabels = string.Join(',', goodDetails.Detail.unified_tags),
                            GoodsThumbnails = string.Join(',', goodDetails.Detail.goods_gallery_urls),
                            GoodsLgstTxt = goodDetails.Detail.lgst_txt
                        });
                        SendMessageBase(messages.ToArray());
                    }
                    P_GoodsList.Remove(model);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("发送商品信息异常:" + ex.ToString());
                updateUI.Invoke("发送商品信息异常");
            }
        }

        private int GoodsPageOffset = 0;
        private int GoodsPageLimit = 10;
        //1-今日热销榜,3-相似商品推荐,4-猜你喜欢(和进宝网站精选一致),5-实时热销榜,6-实时收益榜
        private int[] PinduoduoGoodsChannelType = new int[] { 1, 5, 6, 4 };
        private int PinduoduoGoodsChannelTypeIndex = 0;
        /// <summary>
        /// 获取商品列表
        /// </summary>
        private void GetPinduoduoGoods() {
            // 大于 10 页之后，换类型，从0页开始
            if (GoodsPageOffset > 5) {
                GoodsPageOffset = 0;
                PinduoduoGoodsChannelTypeIndex++;
                if (PinduoduoGoodsChannelTypeIndex >= PinduoduoGoodsChannelType.Length) {
                    PinduoduoGoodsChannelTypeIndex = 0;
                }
            }
            Hashtable param = new Hashtable();
            param.Add("channel_type", PinduoduoGoodsChannelType[PinduoduoGoodsChannelTypeIndex]);
            param.Add("limit", GoodsPageLimit);
            param.Add("offset", GoodsPageOffset * GoodsPageLimit);
            string result = HttpUitls.DoPost(CouponSerUrl + "/DuoduoJuan/GetGoodsRecommendList", param);
            var resultData = JObject.Parse(result.ToString());
            LogHelper.Info(resultData["Issuccess"].ToString());
            P_GoodsList.Clear();
            if (resultData["Issuccess"].ToString().ToLower() == "true")
            {
                var goodResultEntity = JsonHelper.ParseFormByJson<goods_basic_detail_response>(resultData["Data"].ToString());
                P_GoodsList = goodResultEntity.list;
                if (P_GoodsList.Count < GoodsPageLimit)
                {
                    GoodsPageOffset = 6;
                }
                else
                {
                    GoodsPageOffset++;
                }
            }
            else {
                GoodsPageOffset = 6;

            }
        }
        /// <summary>
        /// 获取商品详细
        /// </summary>
        /// <param name="search_id"></param>
        /// <param name="goods_sign"></param>
        private Goods_DetailAndPromotion GetPinduoduoGoodDetail(string goods_sign, string search_id)
        {
            Goods_DetailAndPromotion goods_Detail = null;
            LogHelper.Info("获取商品详细>>>>>>");
            LogHelper.Info("goods_sign=" + goods_sign);
            LogHelper.Info("search_id=" + search_id);
            Hashtable param = new Hashtable();
            param.Add("goods_sign", goods_sign);
            param.Add("search_id", search_id);
            string result = HttpUitls.DoPost(CouponSerUrl+ "/app/AppDuoduoJuan/GetGoodsDetailInfoAndPromotionUrl", param);
            LogHelper.Info("获取商品详细返回结果：" + result + "/r/n");
            var resultData = JObject.Parse(result.ToString());
            if (resultData["Issuccess"].ToString().ToLower() == "true")
            {
                goods_Detail = JsonHelper.ParseFormByJson<Goods_DetailAndPromotion>(resultData["Data"].ToString());
            }
            return goods_Detail;
        }

        /// <summary>
        /// 开启QQ定时发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSendBtn_Click(object sender, EventArgs e)
        {
            if (!IsConnnectSuccess) {
                MessageBox.Show("请先点击测试连接按钮");
                return;
            }
            if (string.IsNullOrEmpty(this.FriendQQBox.Text))
            {
                MessageBox.Show("定时发送的QQ不能为空");
                return;
            }
            if (string.IsNullOrEmpty(this.FriendIntervalTimerBox.Text))
            {
                MessageBox.Show("时间间隔不能为空");
                return;
            }
            this.SendTimer1.Interval = this.FriendIntervalTimerBox.Text.ToInt() * 1000;
            if (this.SendTimer1.Enabled)
            {
                this.FriendIntervalTimerBox.Enabled = true;
                this.FriendQQBox.Enabled = true;

                this.SendTimer1.Enabled = false;
                this.SendTimer1.Stop();
                this.StartFriendSendBtn.Text = "开启定时推送";
            }
            else {
                this.FriendIntervalTimerBox.Enabled = false;
                this.FriendQQBox.Enabled = false;

                this.SendTimer1.Enabled = true;
                this.SendTimer1.Start();
                this.StartFriendSendBtn.Text = "已开启，点击暂停";
            }


        }

        
        /// <summary>
        /// 群聊发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartGroupsSendBtn_Click(object sender, EventArgs e)
        {
            if (!IsConnnectSuccess)
            {
                MessageBox.Show("请先点击测试连接按钮");
                return;
            }
            if (string.IsNullOrEmpty(this.GroupsQQBox.Text))
            {
                MessageBox.Show("定时发送的QQ群不能为空");
                return;
            }
            if (string.IsNullOrEmpty(this.GroupsIntervalTimerBox.Text))
            {
                MessageBox.Show("时间间隔不能为空");
                return;
            }
            this.SendGroupsTimer.Interval = this.GroupsIntervalTimerBox.Text.ToInt() * 1000;
            if (this.SendGroupsTimer.Enabled)
            {
                this.GroupsIntervalTimerBox.Enabled = true;
                this.GroupsQQBox.Enabled = true;

                this.SendGroupsTimer.Enabled = false;
                this.SendGroupsTimer.Stop();
                this.StartGroupsSendBtn.Text = "开启定时推送";
            }
            else
            {
                this.GroupsIntervalTimerBox.Enabled = false;
                this.GroupsQQBox.Enabled = false;

                this.SendGroupsTimer.Enabled = true;
                this.SendGroupsTimer.Start();
                this.StartGroupsSendBtn.Text = "已开启，点击暂停";
            }
        }
        /// <summary>
        /// 群组定时发送事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendGroupsTimer_Tick(object sender, EventArgs e)
        {
            AsynUpdateUI updateUI = new AsynUpdateUI(UpdateRunLogRichText);
            bool isNeedSend = CommonUtils.IsInTimeInterval(DateTime.Now, ConfigurationSettings.AppSettings["StartSendTimeSpan"].ToStr(), ConfigurationSettings.AppSettings["EndSendTimeSpan"].ToStr());
            if (isNeedSend)
            {
                try
                {
                    if (P_GoodsList.Count <= 0)
                    {
                        GetPinduoduoGoods();
                    }
                    if (P_GoodsList.Count > 0)
                    {
                        var model = P_GoodsList[0];
                        Goods_DetailAndPromotion goodDetails = GetPinduoduoGoodDetail(model.goods_sign, model.search_id);
                        if (goodDetails != null)
                        {
                            string goodDesc = goodDetails.Detail.goods_desc;
                            if (goodDetails.Detail.material_list != null)
                            {
                                var material = goodDetails.Detail.material_list.FirstOrDefault(x => x.type == 1);
                                if (material != null)
                                {
                                    if (material.text_list != null && material.text_list.Count() > 0)
                                    {
                                        goodDesc = material.text_list[0];
                                    }
                                }
                            }
                            //new FaceMessage()
                            //{
                            //    FaceId = "144",
                            //    Name = "喝彩"
                            //}
                            List<MessageBase> messages = new List<MessageBase> {
                                new PlainMessage()
                                {
                                    Text = goodDesc  + "\n"
                                },
                                new FaceMessage()
                                {
                                    FaceId="63",
                                    Name="玫瑰"
                                },
                                new PlainMessage()
                                {
                                    Text = "到手价： "+ Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100) - (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100), 2) +"元\n"
                                },
                                new ImageMessage()
                                {
                                    Url = goodDetails.Detail.goods_image_url
                                },
                                new PlainMessage()
                                {
                                    Text = "\n下单链接： "+ goodDetails.Promotion.short_url
                                },
                            };
                            updateUI.Invoke("QQ群发送商品：" + CommonUtils.HtmlToText(goodDesc));
                            SendGoodsRecordService send = new SendGoodsRecordService();
                            send.AddSendGoodsRecord(new Business.Model.BOT_SENDGOODSRECORD()
                            {
                                GoodsDesc = goodDesc,
                                GoodsHasCoupon = goodDetails.Detail.has_coupon ? "Y" : "N",
                                GoodsName = goodDetails.Detail.goods_name,
                                GoodsShareDesc = goodDesc,
                                GoodsOrderUrl = goodDetails.Promotion.short_url,
                                GoodsUrl = goodDetails.Promotion.url,
                                GoodsSignID = goodDetails.Detail.goods_sign,
                                GoodsOptID = goodDetails.Detail.opt_id.ToStr(),
                                GoodsOptName = goodDetails.Detail.opt_name,
                                GoodsMinGroupPrice = Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100), 2),
                                GoodsMinNormalPrice = Math.Round((goodDetails.Detail.min_normal_price.ObjToDecimal() / 100), 2),
                                GoodsMinOrderPrice = Math.Round((goodDetails.Detail.min_group_price.ObjToDecimal() / 100) - (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100), 2),
                                CouponPrice = (goodDetails.Detail.coupon_discount.ObjToDecimal() / 100).ObjToDecimal(),
                                SendToPlatform = "QQ",
                                BrandName = goodDetails.Detail.brand_name,
                                GoodsSalesTip = goodDetails.Detail.sales_tip,
                                MerchantType = goodDetails.Detail.merchant_type == 1 ? "个人店" : goodDetails.Detail.merchant_type == 2 ? "企业店" : goodDetails.Detail.merchant_type == 3 ? "旗舰店" : goodDetails.Detail.merchant_type == 4 ? "专卖店" : goodDetails.Detail.merchant_type == 5 ? "专营店" : goodDetails.Detail.merchant_type == 6 ? "普通店" : "",
                                ShopID = goodDetails.Detail.mall_id.ToStr(),
                                ShopName = goodDetails.Detail.mall_name,
                                ShopLogo = goodDetails.Detail.mall_img_url,
                                Platform = "PinDuoduo",
                                PreferentialLabels = string.Join(',', goodDetails.Detail.unified_tags),
                                GoodsThumbnails = string.Join(',', goodDetails.Detail.goods_gallery_urls),
                                GoodsLgstTxt = goodDetails.Detail.lgst_txt
                            });
                            SendMessageBase(messages.ToArray(), "Groups");
                        }
                        P_GoodsList.Remove(model);
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error("发送商品信息异常:" + ex.ToString());
                    updateUI.Invoke("发送商品信息异常");
                }
            }
            else {
                updateUI.Invoke("QQ群发送商品，未到发送时间，暂不发送");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (BotServerProcessID > 0)
                {
                    var process = Process.GetProcessById(BotServerProcessID);
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常:" + ex.ToString());
            }
        }

        #region 辅助功能
        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetFriendsBtn_Click(object sender, EventArgs e)
        {
            if (!IsConnnectSuccess)
            {
                MessageBox.Show("请先点击测试连接按钮");
                return;
            }
            FriendsListForm friends = new FriendsListForm(BotQQText.Text, BotVerifyKeyText.Text);
            friends.Owner = this;
            friends.ShowDialog();
        }
        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GetGroupsBtn_Click(object sender, EventArgs e)
        {
            if (!IsConnnectSuccess)
            {
                MessageBox.Show("请先点击测试连接按钮");
                return;
            }
            FriendsListForm friends = new FriendsListForm(BotQQText.Text, BotVerifyKeyText.Text, "Groups");
            friends.Owner = this;
            friends.ShowDialog();
        }
        /// <summary>
        /// 保存从好友或群列表页面选中的数据
        /// </summary>
        /// <param name="ChoiceType">friend：好友;Groups ： 群</param>
        /// <param name="list"></param>
        public void SaveSelectFriendOrGroupsByList(string ChoiceType, Hashtable hashtable)
        {
            ArrayList idArr = new ArrayList();
            foreach (var item in hashtable.Keys)
            {
                idArr.Add(item);
            }
            string ids = string.Join(',', idArr.ToArray());
            if (ChoiceType.ToLower() == "friend")
            {
                this.FriendQQBox.Text = ids;
            }
            else
            {
                this.GroupsQQBox.Text = ids;
            }
        }
        #endregion

    }
}
