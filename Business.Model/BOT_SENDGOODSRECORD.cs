

namespace Business.Model
{
    /// <summary>
    /// 机器人自动发券记录
    /// </summary>
    public class BOT_SENDGOODSRECORD
    {
        /// <summary>
        /// 机器人自动发券记录
        /// </summary>
        public BOT_SENDGOODSRECORD()
        {
        }

        private System.Int32 _SendGoodsID;
        /// <summary>
        /// 
        /// </summary>
        public System.Int32 SendGoodsID { get { return this._SendGoodsID; } set { this._SendGoodsID = value; } }

        private System.String _SendToIsGroup;
        /// <summary>
        /// 是否群组
        /// </summary>
        public System.String SendToIsGroup { get { return this._SendToIsGroup; } set { this._SendToIsGroup = value; } }

        private System.String _SendToPlatform;
        /// <summary>
        /// QQ/WeChat
        /// </summary>
        public System.String SendToPlatform { get { return this._SendToPlatform; } set { this._SendToPlatform = value; } }

        private System.String _SendToGroupNum;
        /// <summary>
        /// 推送群组号
        /// </summary>
        public System.String SendToGroupNum { get { return this._SendToGroupNum; } set { this._SendToGroupNum = value; } }

        private System.String _Platform;
        /// <summary>
        /// 拼多多：PinDuoduo;京东:JD;淘宝：TaoBao
        /// </summary>
        public System.String Platform { get { return this._Platform; } set { this._Platform = value; } }

        private System.String _PID;
        /// <summary>
        /// 推广位ID
        /// </summary>
        public System.String PID { get { return this._PID; } set { this._PID = value; } }

        private System.String _GoodsSignID;
        /// <summary>
        /// 商品ID主键
        /// </summary>
        public System.String GoodsSignID { get { return this._GoodsSignID; } set { this._GoodsSignID = value; } }

        private System.String _GoodsName;
        /// <summary>
        /// 商品标题
        /// </summary>
        public System.String GoodsName { get { return this._GoodsName; } set { this._GoodsName = value; } }

        private System.String _GoodsDesc;
        /// <summary>
        /// 商品描述
        /// </summary>
        public System.String GoodsDesc { get { return this._GoodsDesc; } set { this._GoodsDesc = value; } }

        private System.String _GoodsThumbnails;
        /// <summary>
        /// 商品缩略图图片，多个英文逗号隔开
        /// </summary>
        public System.String GoodsThumbnails { get { return this._GoodsThumbnails; } set { this._GoodsThumbnails = value; } }

        private System.String _GoodsShareDesc;
        /// <summary>
        /// 商品分享简介
        /// </summary>
        public System.String GoodsShareDesc { get { return this._GoodsShareDesc; } set { this._GoodsShareDesc = value; } }

        private System.String _GoodsUrl;
        /// <summary>
        /// 商品详情、落地页链接地址
        /// </summary>
        public System.String GoodsUrl { get { return this._GoodsUrl; } set { this._GoodsUrl = value; } }

        private System.String _GoodsOrderUrl;
        /// <summary>
        /// 商品下单链接
        /// </summary>
        public System.String GoodsOrderUrl { get { return this._GoodsOrderUrl; } set { this._GoodsOrderUrl = value; } }

        private System.String _GoodsSalesTip;
        /// <summary>
        /// 销售量
        /// </summary>
        public System.String GoodsSalesTip { get { return this._GoodsSalesTip; } set { this._GoodsSalesTip = value; } }

        private System.Decimal? _GoodsMinNormalPrice;
        /// <summary>
        /// 商品最低价格
        /// </summary>
        public System.Decimal? GoodsMinNormalPrice { get { return this._GoodsMinNormalPrice; } set { this._GoodsMinNormalPrice = value ?? default(System.Decimal); } }

        private System.Decimal? _GoodsMinGroupPrice;
        /// <summary>
        /// 商品最低拼团价
        /// </summary>
        public System.Decimal? GoodsMinGroupPrice { get { return this._GoodsMinGroupPrice; } set { this._GoodsMinGroupPrice = value ?? default(System.Decimal); } }

        private System.Decimal? _GoodsSeckillPrice;
        /// <summary>
        /// 商品秒杀价格
        /// </summary>
        public System.Decimal? GoodsSeckillPrice { get { return this._GoodsSeckillPrice; } set { this._GoodsSeckillPrice = value ?? default(System.Decimal); } }
        
        private System.Decimal? _GoodsMinOrderPrice;
        /// <summary>
        /// 商品最低到手价
        /// </summary>
        public System.Decimal? GoodsMinOrderPrice { get { return this._GoodsMinOrderPrice; } set { this._GoodsMinOrderPrice = value ?? default(System.Decimal); } }

        private System.String _GoodsOptID;
        /// <summary>
        /// 类目ID
        /// </summary>
        public System.String GoodsOptID { get { return this._GoodsOptID; } set { this._GoodsOptID = value; } }

        private System.String _GoodsOptName;
        /// <summary>
        /// 类目名称
        /// </summary>
        public System.String GoodsOptName { get { return this._GoodsOptName; } set { this._GoodsOptName = value; } }

        private System.String _BrandCode;
        /// <summary>
        /// 商品品牌code
        /// </summary>
        public System.String BrandCode { get { return this._BrandCode; } set { this._BrandCode = value; } }

        private System.String _BrandName;
        /// <summary>
        /// 商品品牌名称
        /// </summary>
        public System.String BrandName { get { return this._BrandName; } set { this._BrandName = value; } }

        private System.String _GoodsLgstTxt;
        /// <summary>
        /// 物流分
        /// </summary>
        public System.String GoodsLgstTxt { get { return this._GoodsLgstTxt; } set { this._GoodsLgstTxt = value; } }

        private System.String _ShopID;
        /// <summary>
        /// 商家店铺ID
        /// </summary>
        public System.String ShopID { get { return this._ShopID; } set { this._ShopID = value; } }

        private System.String _ShopName;
        /// <summary>
        /// 商家店铺名称
        /// </summary>
        public System.String ShopName { get { return this._ShopName; } set { this._ShopName = value; } }

        private System.String _ShopLogo;
        /// <summary>
        /// 商家店铺logo
        /// </summary>
        public System.String ShopLogo { get { return this._ShopLogo; } set { this._ShopLogo = value; } }

        private System.String _MerchantType;
        /// <summary>
        /// 商家类型
        /// </summary>
        public System.String MerchantType { get { return this._MerchantType; } set { this._MerchantType = value; } }

        private System.String _ShopOwner;
        /// <summary>
        /// 是否京东自营【g=自营，p=pop】
        /// </summary>
        public System.String ShopOwner { get { return this._ShopOwner; } set { this._ShopOwner = value; } }

        private System.String _GoodsHasCoupon;
        /// <summary>
        /// 商品是否有优惠券
        /// </summary>
        public System.String GoodsHasCoupon { get { return this._GoodsHasCoupon; } set { this._GoodsHasCoupon = value; } }

        private System.Decimal? _CouponPrice;
        /// <summary>
        /// 优惠券金额
        /// </summary>
        public System.Decimal? CouponPrice { get { return this._CouponPrice; } set { this._CouponPrice = value ?? default(System.Decimal); } }

        private System.String _PreferentialLabels;
        /// <summary>
        ///  优惠标签列表
        /// </summary>
        public System.String PreferentialLabels { get { return this._PreferentialLabels; } set { this._PreferentialLabels = value; } }

        private System.DateTime _CREATEDATE;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CREATEDATE { get { return this._CREATEDATE; } set { this._CREATEDATE = value; } }

        private System.String _CREATEUSERID;
        /// <summary>
        /// 
        /// </summary>
        public System.String CREATEUSERID { get { return this._CREATEUSERID; } set { this._CREATEUSERID = value; } }

        private System.String _RECORDSTATUS;
        /// <summary>
        /// 
        /// </summary>
        public System.String RECORDSTATUS { get { return this._RECORDSTATUS; } set { this._RECORDSTATUS = value; } }

        private System.DateTime? _MODIFYDATE;
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? MODIFYDATE { get { return this._MODIFYDATE; } set { this._MODIFYDATE = value ?? default(System.DateTime); } }

        private System.String _MODIFYUSERID;
        /// <summary>
        /// 
        /// </summary>
        public System.String MODIFYUSERID { get { return this._MODIFYUSERID; } set { this._MODIFYUSERID = value; } }
    }
}
