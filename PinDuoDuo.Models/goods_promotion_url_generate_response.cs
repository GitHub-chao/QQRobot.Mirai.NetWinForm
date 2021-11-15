using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinDuoDuo.Models
{
    /// <summary>
    /// 多多进宝推广链接生成
    /// 返回结果类
    /// </summary>
    public class goods_promotion_url_generate_response
    {
        /// <summary>
        /// 多多进宝推广链接对象列表
        /// </summary>
        public List<goods_promotion_url_list> goods_promotion_url_list { get; set; }
    }
    /// <summary>
    /// 多多进宝推广链接生成
    /// 返回结果类----多多进宝推广链接对象列表
    /// </summary>
    public class goods_promotion_url_list
    {
        /// <summary>
        /// 对应出参mobile_url的短链接，与mobile_url功能一致。
        /// </summary>
        public string mobile_short_url { get; set; }
        /// <summary>
        /// 使用此推广链接，用户安装微信的情况下，默认拉起拼多多福利券微信小程序，否则唤起H5页面
        /// </summary>
        public string mobile_url { get; set; }

        /// <summary>
        /// qq小程序信息
        /// </summary>
        public goods_promotion_QQ_App_Info qq_app_info { get; set; }

        /// <summary>
        /// 使用此推广链接，用户安装拼多多APP的情况下会唤起APP（需客户端支持schema跳转协议）
        /// </summary>
        public string schema_url { get; set; }
        /// <summary>
        /// 对应出参url的短链接，与url功能一致
        /// </summary>
        public string short_url { get; set; }
        /// <summary>
        /// 普通推广长链接，唤起H5页面
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 拼多多福利券微信小程序信息
        /// </summary>
        public goods_promotion_WE_App_info we_app_info { get; set; }
    }

    /// <summary>
    /// 多多进宝推广链接生成
    /// 返回结果类----qq小程序信息
    /// </summary>
    public class goods_promotion_QQ_App_Info
    {
        /// <summary>
        /// 拼多多小程序id
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// Banner图
        /// </summary>
        public string banner_url { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 小程序path值
        /// </summary>
        public string page_path { get; set; }
        /// <summary>
        /// 小程序icon
        /// </summary>
        public string qq_app_icon_url { get; set; }
        /// <summary>
        /// 来源名
        /// </summary>
        public string source_display_name { get; set; }
        /// <summary>
        /// 小程序标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }

    }
    /// <summary>
    /// 多多进宝推广链接生成
    /// 返回结果类----拼多多福利券微信小程序信息
    /// </summary>
    public class goods_promotion_WE_App_info
    {
        /// <summary>
        /// 小程序id
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// Banner图
        /// </summary>
        public string banner_url { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 小程序path值
        /// </summary>
        public string page_path { get; set; }
        /// <summary>
        /// 来源名
        /// </summary>
        public string source_display_name { get; set; }
        /// <summary>
        /// 小程序标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 小程序图片
        /// </summary>
        public string we_app_icon_url { get; set; }
    }
}
