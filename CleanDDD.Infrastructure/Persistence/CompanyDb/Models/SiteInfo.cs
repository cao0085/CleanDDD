using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class SiteInfo
{
    /// <summary>
    /// 場地ID
    /// </summary>
    public long SiteInfoId { get; set; }

    /// <summary>
    /// 自定義代碼
    /// </summary>
    public string SerialNo { get; set; } = null!;

    /// <summary>
    /// 場地名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 地址
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// 連絡電話
    /// </summary>
    public string? Tel { get; set; }

    /// <summary>
    /// 業管機關代碼
    /// </summary>
    public string? Authority { get; set; }

    /// <summary>
    /// 充電資訊上傳參數
    /// Json 字串
    /// </summary>
    public string? ChargeInfoParam { get; set; }

    /// <summary>
    /// 停車證名稱
    /// </summary>
    public string? LicenseName { get; set; }

    /// <summary>
    /// 管理類型
    /// 0：無人場
    /// 1：有人場
    /// 2：路邊停車
    /// </summary>
    public byte ManagementType { get; set; }

    /// <summary>
    /// 委外類型
    /// 0: 不適用
    /// 1: 權力委外
    /// 2: 勞務委外
    /// </summary>
    public byte Outsource { get; set; }

    /// <summary>
    /// 繳費期限(天)
    /// 路邊停車開單後幾天內須繳費
    /// -1: 無限制
    /// </summary>
    public int PayDeadline { get; set; }

    /// <summary>
    /// 備註
    /// </summary>
    public string? Memo { get; set; }

    /// <summary>
    /// 狀態
    /// 0: 無效
    /// 1: 生效
    /// 9: 刪除
    /// </summary>
    public byte State { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime InsertTime { get; set; }

    public virtual ICollection<RoadSection> RoadSection { get; set; } = new List<RoadSection>();

    public virtual ICollection<RoadSideOrder> RoadSideOrder { get; set; } = new List<RoadSideOrder>();
}
