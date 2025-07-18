using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class RateInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public long RateInfoId { get; set; }

    /// <summary>
    /// 生效日
    /// </summary>
    public DateTime EffectiveDay { get; set; }

    /// <summary>
    /// 身分別
    /// 1: 一般
    /// 2: 身障
    /// 3: 電動
    /// 4: 卸貨
    /// </summary>
    public int RateIdentity { get; set; }

    /// <summary>
    /// 費率名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 狀態
    /// 0: 無效
    /// 1: 有效
    /// 9: 刪除
    /// </summary>
    public byte State { get; set; }

    public virtual ICollection<RateDetail> RateDetail { get; set; } = new List<RateDetail>();
}
