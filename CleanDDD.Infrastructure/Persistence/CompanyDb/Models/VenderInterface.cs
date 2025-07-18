using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class VenderInterface
{
    /// <summary>
    /// ID
    /// </summary>
    public long VenderInterfaceId { get; set; }

    /// <summary>
    /// 廠商ID (CompanyID)
    /// </summary>
    public long VenderId { get; set; }

    /// <summary>
    /// 名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 類型
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 參數資料
    /// </summary>
    public string JsonData { get; set; } = null!;

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime InsertTime { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? UpdateTime { get; set; }
}
