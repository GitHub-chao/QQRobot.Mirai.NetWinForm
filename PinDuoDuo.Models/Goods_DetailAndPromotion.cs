using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinDuoDuo.Models
{
    /// <summary>
    /// 拼多多，商品明细以及转链信息
    /// </summary>
    public class Goods_DetailAndPromotion
    {
        /// <summary>
        /// 商品明细
        /// </summary>
        public goods_details Detail { get; set; }
        /// <summary>
        /// 链接信息
        /// </summary>
        public goods_promotion_url_list Promotion { get; set; }
    }
}
