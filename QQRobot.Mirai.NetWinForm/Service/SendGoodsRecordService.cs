using Business.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QQRobot.Mirai.NetWinForm.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQRobot.Mirai.NetWinForm.Service
{
    public class SendGoodsRecordService
    {
        /// <summary>
        /// 优惠券获取地址
        /// </summary>
        private string CouponSerUrl = ConfigurationSettings.AppSettings["CouponSerUrl"].ToString();

        /// <summary>
        ///  添加推送记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> AddSendGoodsRecord(BOT_SENDGOODSRECORD model) {
            Hashtable param = new Hashtable();
            param.Add("Model", JsonConvert.SerializeObject(model));
            string result = HttpUitls.DoPost(CouponSerUrl + "/SendGoodsRecord/AddSendGoodsRecord", param);
            var resultData = JObject.Parse(result.ToString());
            bool flag = resultData["Data"].ToString().ToUpper() == "true" ? true : false;
            return await Task.FromResult<bool>(flag);

        }
    }
}
