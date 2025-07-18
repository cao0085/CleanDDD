using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class MachineInfo
{
    /// <summary>
    /// ID
    /// </summary>
    public long MachineInfoId { get; set; }

    /// <summary>
    /// 場地ID
    /// </summary>
    public long SiteInfoId { get; set; }

    /// <summary>
    /// 自定義機號
    /// </summary>
    public string SerialNo { get; set; } = null!;

    /// <summary>
    /// PDA辨識碼
    /// </summary>
    public string? PDANo { get; set; }

    /// <summary>
    /// 設備類型
    /// 10:路邊PDA
    /// 11:路邊車辨柱
    /// </summary>
    public byte ChargesType { get; set; }

    /// <summary>
    /// 狀態
    /// 0：無效
    /// 1：生效
    /// 9：刪除
    /// </summary>
    public byte State { get; set; }
}
