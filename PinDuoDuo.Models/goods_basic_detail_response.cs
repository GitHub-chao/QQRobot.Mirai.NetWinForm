using System;
using System.Collections.Generic;

namespace PinDuoDuo.Models
{
    /// <summary>
    /// 进宝频道推广商品
    /// 返回结果类
    /// </summary>
    public class goods_basic_detail_response
    {
        /// <summary>
        /// 翻页时必填前页返回的list_id值
        /// </summary>
        public string list_id { get; set; }
        /// <summary>
        /// 搜索id，建议生成推广链接时候填写，提高收益
        /// </summary>
        public string search_id { get; set; }
        /// <summary>
        /// total总条数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<goods_basic_detail_List> list { get; set; }
    }

    public class goods_basic_detail_List
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
        /// 商品类目id
        /// </summary>
        public string cat_id { get; set; }
        /// <summary>
        /// 商品一~四级类目ID列表
        /// </summary>
        public long[] cat_ids { get; set; }
        /// <summary>
        /// 优惠券面额,单位为分
        /// </summary>
        public long coupon_discount { get; set; }
        /// <summary>
        /// 优惠券失效时间,UNIX时间戳
        /// </summary>
        public long coupon_end_time { get; set; }
        /// <summary>
        /// 优惠券门槛价格,单位为分
        /// </summary>
        public long coupon_min_order_amount { get; set; }
        /// <summary>
        /// 优惠券金额
        /// </summary>
        public long coupon_price { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        public long coupon_remain_quantity { get; set; }
        /// <summary>
        /// 优惠券生效时间,UNIX时间戳
        /// </summary>
        public long coupon_start_time { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        public long coupon_total_quantity { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long create_at { get; set; }
        /// <summary>
        /// 描述分
        /// </summary>
        public string desc_txt { get; set; }
        /// <summary>
        /// 额外优惠券，单位为分
        /// </summary>
        public long extra_coupon_amount { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string goods_desc { get; set; }
        /// <summary>
        /// 商品主图
        /// </summary>
        public string goods_image_url { get; set; }
        /// <summary>
        /// 商品特殊标签列表。例: [1]，1-APP专享
        /// </summary>
        public int[] goods_labels { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品等级
        /// </summary>
        public long goods_rate { get; set; }
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
        /// 商品类型
        /// </summary>
        public int goods_type { get; set; }
        /// <summary>
        /// 商品是否带券,true-带券,false-不带券
        /// </summary>
        public bool has_coupon { get; set; }
        /// <summary>
        /// 物流分
        /// </summary>
        public string lgst_txt { get; set; }
        /// <summary>
        /// 商家id
        /// </summary>
        public long mall_id { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string mall_name { get; set; }
        /// <summary>
        /// 市场服务费
        /// </summary>
        public long market_fee { get; set; }
        /// <summary>
        /// 商家类型
        /// </summary>
        public string merchant_type { get; set; }
        /// <summary>
        /// 最小成团价格，单位分
        /// </summary>
        public long min_group_price { get; set; }
        /// <summary>
        /// 最小单买价格，单位分
        /// </summary>
        public long min_normal_price { get; set; }
        /// <summary>
        /// 商品标签类目ID,使用pdd.goods.opt.get获取
        /// </summary>
        public string opt_id { get; set; }
        /// <summary>
        /// 商品一~四级标签类目ID列表
        /// </summary>
        public long[] opt_ids { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        public string opt_name { get; set; }
        /// <summary>
        /// 比价行为预判定佣金，需要用户备案
        /// </summary>
        public long predict_promotion_rate { get; set; }
        /// <summary>
        /// 佣金比例,千分比
        /// </summary>
        public long promotion_rate { get; set; }
        /// <summary>
        /// 二维码主图
        /// </summary>
        public string qr_code_image_url { get; set; }
        /// <summary>
        /// 商品近1小时在多多进宝的实时销量（仅实时热销榜提供）
        /// </summary>
        public string realtime_sales_tip { get; set; }
        /// <summary>
        /// 销售量
        /// </summary>
        public string sales_tip { get; set; }
        /// <summary>
        /// 搜索id，建议生成推广链接时候填写，提高收益
        /// </summary>
        public string search_id { get; set; }
        /// <summary>
        /// 服务分
        /// </summary>
        public string serv_txt { get; set; }
        /// <summary>
        /// 分享描述
        /// </summary>
        public string share_desc { get; set; }
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
    }
}
