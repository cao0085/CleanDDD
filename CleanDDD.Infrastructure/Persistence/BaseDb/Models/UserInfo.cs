using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Models;

public partial class UserInfo
{
    /// <summary>
    /// 使用者自增長識別
    /// </summary>
    public long UserInfoId { get; set; }

    /// <summary>
    /// 帳號
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string PasswordHash { get; set; } = null!;

    /// <summary>
    /// 類型
    /// 1: 系統管理員
    /// 2: 軟體人員
    /// 11: 企業帳號
    /// 21: 工程人員
    /// 31: 現場人員
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 人員名稱
    /// </summary>
    public string Nickname { get; set; } = null!;

    public string? Email { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpires { get; set; }

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
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
