using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class RateDetail
{
    /// <summary>
    /// ID
    /// </summary>
    public long RateDetailId { get; set; }

    /// <summary>
    /// 費率ID
    /// </summary>
    public long RateInfoId { get; set; }

    /// <summary>
    /// 日期類型
    /// 1: 平日
    /// 2: 假日
    /// 3: 特殊日
    /// </summary>
    public byte DateType { get; set; }

    /// <summary>
    /// 循環時數(小時)
    /// </summary>
    public int CycleHour { get; set; }

    /// <summary>
    /// 上限金額
    /// </summary>
    public decimal LimitAmount { get; set; }

    /// <summary>
    /// 患日時間 (HH:mm)
    /// </summary>
    public string DayChangeTime { get; set; } = null!;

    /// <summary>
    /// 入場緩衝時間(分)
    /// </summary>
    public int ParkBuffer { get; set; }

    /// <summary>
    /// 繳費緩衝時間(分)
    /// </summary>
    public int PayBuffer { get; set; }

    /// <summary>
    /// 優惠設定
    ///  {
    ///     Time: int (分),
    ///     Count: int,
    ///     OffPercent: int (0-100)
    ///    }
    /// </summary>
    public string? SpecialOffer { get; set; }

    /// <summary>
    /// 時段設定
    /// [object]
    /// Bilings: [
    ///     {
    ///     Amount: int,
    ///     ChargeAmount: int,
    ///     Frequency: int (分鐘),
    ///     Count : int (次數) 
    ///     }
    /// ]
    /// </summary>
    public string TimePeriod { get; set; } = null!;

    /// <summary>
    /// 狀態
    /// 0: 無效
    /// 1: 有效
    /// 9: 刪除
    /// </summary>
    public byte State { get; set; }

    public virtual RateInfo RateInfo { get; set; } = null!;
}
