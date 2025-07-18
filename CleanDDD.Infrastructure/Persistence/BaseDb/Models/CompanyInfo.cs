using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Models;

public partial class CompanyInfo
{
    /// <summary>
    /// 企業自增長識別
    /// </summary>
    public long CompanyInfoId { get; set; }

    /// <summary>
    /// 企業名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 類型
    /// 1: 企業
    /// 2: 廠商
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 簡稱
    /// </summary>
    public string ShortName { get; set; } = null!;

    /// <summary>
    /// 英文名稱
    /// </summary>
    public string? EnName { get; set; }

    /// <summary>
    /// 自定義編碼
    /// </summary>
    public string SerialNo { get; set; } = null!;

    /// <summary>
    /// 完整地址
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// 統編
    /// </summary>
    public string RegisterNo { get; set; } = null!;

    /// <summary>
    /// 連絡電話
    /// </summary>
    public string? Tel { get; set; }

    /// <summary>
    /// 稅籍編碼
    /// </summary>
    public string? TaxIDNo { get; set; }

    /// <summary>
    /// 狀態
    /// 0: 失效
    /// 1: 生效
    /// 9: 刪除
    /// </summary>
    public byte State { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 新增時間
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
