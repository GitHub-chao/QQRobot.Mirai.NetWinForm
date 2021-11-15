using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinDuoDuo.Models
{
    /// <summary>
    /// 多多进宝商品详情查询
    /// 返回结果类
    /// </summary>
    public class goods_detail_response
    {
        /// <summary>
        /// 素材ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string[] image_list { get; set; }
        /// <summary>
        /// 文字列表
        /// </summary>
        public string[] text_list { get; set; }
        /// <summary>
        /// 视频缩略图
        /// </summary>
        public string thumbnail_url { get; set; }
        /// <summary>
        /// 素材类型，1-图文，2-视频
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 视频url
        /// </summary>
        public string video_url { get; set; }
        public List<goods_details> goods_details { get; set; }
    }
    /// <summary>
    /// 多多进宝商品详情查询
    /// 返回结果类 ---- 商品对象列表
    /// </summary>
    public class goods_details
    {
        /// <summary>
        /// 活动佣金比例，千分比（特定活动期间的佣金比例）
        /// </summary>
        public long activity_promotion_rate { get; set; }
        /// <summary>
        /// 商品活动标记数组，例：[4,7]，4-秒杀 7-百亿补贴等
        /// </summary>
        public int[] activity_tags { get; set; }
        /// <summary>
        /// 商品品牌词信息，如“苹果”、“阿迪达斯”、“李宁”等
        /// </summary>
        public string brand_name { get; set; }
        /// <summary>
        /// 全局礼金金额，单位分
        /// </summary>
        public long cash_gift_amount { get; set; }
        /// <summary>
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public long cat_id { get; set; }
        /// <summary>
        /// 商品一~四级类目ID列表
        /// </summary>
        public int[] cat_ids { get; set; }
        /// <summary>
        /// 店铺收藏券id
        /// </summary>
        public string clt_cpn_batch_sn { get; set; }
        /// <summary>
        /// 店铺收藏券面额,单位为分
        /// </summary>
        public long clt_cpn_discount { get; set; }
        /// <summary>
        /// 店铺收藏券截止时间
        /// </summary>
        public long clt_cpn_end_time { get; set; }
        /// <summary>
        /// 店铺收藏券使用门槛价格,单位为分
        /// </summary>
        public long clt_cpn_min_amt { get; set; }
        /// <summary>
        /// 店铺收藏券总量
        /// </summary>
        public long clt_cpn_quantity { get; set; }
        /// <summary>
        /// 店铺收藏券剩余量
        /// </summary>
        public long clt_cpn_remain_quantity { get; set; }
        /// <summary>
        /// 店铺收藏券起始时间
        /// </summary>
        public long clt_cpn_start_time { get; set; }
        /// <summary>
        /// 优惠券面额，单位为分
        /// </summary>
        public long coupon_discount { get; set; }
        /// <summary>
        /// 优惠券失效时间，UNIX时间戳
        /// </summary>
        public long coupon_end_time { get; set; }
        /// <summary>
        /// 优惠券门槛金额，单位为分
        /// </summary>
        public long coupon_min_order_amount { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        public long coupon_remain_quantity { get; set; }
        /// <summary>
        /// 优惠券生效时间，UNIX时间戳
        /// </summary>
        public long coupon_start_time { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        public long coupon_total_quantity { get; set; }
        /// <summary>
        /// 创建时间（unix时间戳）
        /// </summary>
        public long create_at { get; set; }
        /// <summary>
        /// 描述分
        /// </summary>
        public string desc_txt { get; set; }
        /// <summary>
        /// 额外优惠券
        /// </summary>
        public long extra_coupon_amount { get; set; }
        /// <summary>
        /// 参与多多进宝的商品描述
        /// </summary>
        public string goods_desc { get; set; }
        /// <summary>
        /// 商品轮播图
        /// </summary>
        public string[] goods_gallery_urls { get; set; }
        /// <summary>
        /// 多多进宝商品主图
        /// </summary>
        public string goods_image_url { get; set; }
        /// <summary>
        /// 参与多多进宝的商品标题
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品goodsSign，支持通过goodsSign查询商品。
        /// goodsSign是加密后的goodsId, goodsId已下线，请使用goodsSign来替代。使用说明：https://jinbao.pinduoduo.com/qa-system?questionId=252
        /// </summary>
        public string goods_sign { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        public string goods_thumbnail_url { get; set; }
        /// <summary>
        /// 商品是否有优惠券 true-有，false-没有
        /// </summary>
        public bool has_coupon { get; set; }
        /// <summary>
        /// 是否有店铺券
        /// </summary>
        public bool has_mall_coupon { get; set; }
        /// <summary>
        /// 物流分
        /// </summary>
        public string lgst_txt { get; set; }

        /// <summary>
        /// 店铺折扣
        /// </summary>
        public int mall_coupon_discount_pct { get; set; }
        /// <summary>
        /// 店铺券使用结束时间
        /// </summary>
        public long mall_coupon_end_time { get; set; }
        /// <summary>
        /// 最大使用金额
        /// </summary>
        public int mall_coupon_max_discount_amount { get; set; }
        /// <summary>
        /// 最小使用金额
        /// </summary>
        public int mall_coupon_min_order_amount { get; set; }
        /// <summary>
        /// 店铺券余量
        /// </summary>
        public long mall_coupon_remain_quantity { get; set; }
        /// <summary>
        /// 店铺券使用开始时间
        /// </summary>
        public long mall_coupon_start_time { get; set; }
        /// <summary>
        /// 店铺券总量
        /// </summary>
        public long mall_coupon_total_quantity { get; set; }
        /// <summary>
        /// 该商品所在店铺是否参与全店推广，0：否，1：是
        /// </summary>
        public int mall_cps { get; set; }
        /// <summary>
        /// 商家id
        /// </summary>
        public long mall_id { get; set; }
        /// <summary>
        /// 店铺logo图
        /// </summary>
        public string mall_img_url { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string mall_name { get; set; }
        /// <summary>
        /// 商品素材列表
        /// </summary>
        public List<goods_details_materiallist> material_list { get; set; }
        /// <summary>
        /// 店铺类型，1-个人，2-企业，3-旗舰店，4-专卖店，5-专营店，6-普通店（未传为全部）
        /// </summary>
        public int merchant_type { get; set; }
        /// <summary>
        /// 最低价sku的拼团价，单位为分
        /// </summary>
        public long min_group_price { get; set; }
        /// <summary>
        /// 最低价sku的单买价，单位为分
        /// </summary>
        public long min_normal_price { get; set; }
        /// <summary>
        /// 快手专享
        /// </summary>
        public bool only_scene_auth { get; set; }
        /// <summary>
        /// 商品标签ID，使用pdd.goods.opt.get接口获取
        /// </summary>
        public long opt_id { get; set; }
        /// <summary>
        /// 商品标签ID
        /// </summary>
        public int[] opt_ids { get; set; }
        /// <summary>
        /// 商品标签名称
        /// </summary>
        public string opt_name { get; set; }
        /// <summary>
        /// 推广计划类型: 1-全店推广 2-单品推广 3-定向推广 4-招商推广 5-分销推广
        /// </summary>
        public int plan_type { get; set; }
        /// <summary>
        /// 比价行为预判定佣金，需要用户备案
        /// </summary>
        public long predict_promotion_rate { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        public long promotion_rate { get; set; }
        /// <summary>
        /// 已售卖件数
        /// </summary>
        public string sales_tip { get; set; }
        /// <summary>
        /// 服务标签: 4-送货入户并安装,5-送货入户,6-电子发票,9-坏果包赔,11-闪电退款,12-24小时发货,13-48小时发货,17-顺丰包邮,18-只换不修,1可定制化,29-预约配送,1000001-正品发票,1000002-送货入户并安装
        /// </summary>
        public int[] service_tags { get; set; }
        /// <summary>
        /// 服务分
        /// </summary>
        public string serv_txt { get; set; }
        /// <summary>
        /// 招商分成服务费比例，千分比
        /// </summary>
        public int share_rate { get; set; }
        /// <summary>
        /// 优势渠道专属商品补贴金额，单位为分。针对优质渠道的补贴活动，指定优势渠道可通过推广该商品获取相应补贴。
        /// 补贴活动入口：[进宝网站-官方活动-千万补贴]，报名入口：https://jinbao.pinduoduo.com/ten-million-subsidy/entry
        /// </summary>
        public int subsidy_amount { get; set; }
        /// <summary>
        /// 千万补贴给渠道的收入补贴，不允许直接给下级代理展示，单位为分
        /// </summary>
        public int subsidy_duo_amount_ten_million { get; set; }
        /// <summary>
        /// 优惠标签列表，包括："X元券","比全网低X元","服务费","精选素材","近30天低价","同款低价","同款好评","同款热销","旗舰店","一降到底","招商优选","商家优选","好价再降X元","全站销量XX","实时热销榜第X名","实时好评榜第X名","额外补X元"等
        /// </summary>
        public string[] unified_tags { get; set; }
        /// <summary>
        /// 商品视频url
        /// </summary>
        public string[] video_urls { get; set; }
        /// <summary>
        /// 招商团长id
        /// </summary>
        public long zs_duo_id { get; set; }
    }

    /// <summary>
    /// 多多进宝商品详情查询
    /// 返回结果类 ---- 商品对象列表 ---商品素材列表
    /// </summary>
    public class goods_details_materiallist
    {
        /// <summary>
        /// 素材ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string[] image_list { get; set; }
        /// <summary>
        /// 文字列表
        /// </summary>
        public string[] text_list { get; set; }
        /// <summary>
        /// 视频缩略图
        /// </summary>
        public string thumbnail_url { get; set; }
        /// <summary>
        /// 素材类型，1-图文，2-视频
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 视频url
        /// </summary>
        public string video_url { get; set; }
    }
}
