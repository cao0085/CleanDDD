using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class RoadSideOrderDetail
{
    /// <summary>
    /// ID
    /// </summary>
    public long RoadSideOrderDetailId { get; set; }

    /// <summary>
    /// 繳費單ID
    /// </summary>
    public long RoadSideOrderId { get; set; }

    /// <summary>
    /// 區間金額
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 起始計費區間
    /// HH:mm
    /// </summary>
    public string ParkingTimeStart { get; set; } = null!;

    /// <summary>
    /// 結束計費區間
    /// HH:mm
    /// </summary>
    public string ParkingTimeEnd { get; set; } = null!;

    /// <summary>
    /// 累計金額
    /// </summary>
    public decimal CumulativeAmount { get; set; }

    /// <summary>
    /// 累計時數(分)
    /// </summary>
    public int CumulativeTime { get; set; }

    /// <summary>
    /// 狀態
    /// 1:正常
    /// 3:作廢
    /// 9:刪除
    /// </summary>
    public byte State { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime InsertTime { get; set; }

    /// <summary>
    /// 開單人員ID
    /// </summary>
    public long InsertUserInfoId { get; set; }

    public virtual RoadSideOrder RoadSideOrder { get; set; } = null!;
}
