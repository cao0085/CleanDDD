using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class RoadSideOrder
{
    /// <summary>
    /// ID
    /// </summary>
    public long RoadSideOrderId { get; set; }

    /// <summary>
    /// 唯一編碼
    /// </summary>
    public Guid? GUID { get; set; }

    /// <summary>
    /// 場地ID
    /// </summary>
    public long SiteInfoId { get; set; }

    /// <summary>
    /// 外部單號
    /// </summary>
    public string? ExtNo { get; set; }

    /// <summary>
    /// 條碼資料
    /// </summary>
    public string? BarCode { get; set; }

    /// <summary>
    /// 繳費單金額
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// 路段ID
    /// </summary>
    public long RoadSectionId { get; set; }

    /// <summary>
    /// 車格號碼
    /// </summary>
    public string RoadGridNo { get; set; } = null!;

    /// <summary>
    /// 設備類型
    /// 10:路邊PDA
    /// 11:路邊車辨柱
    /// </summary>
    public byte ChargesType { get; set; }

    /// <summary>
    /// 車號
    /// </summary>
    public string CarNo { get; set; } = null!;

    /// <summary>
    /// 車輛顏色
    /// </summary>
    public string? CarColor { get; set; }

    /// <summary>
    /// 車輛類型
    /// 1: 汽車
    /// 2: 機車
    /// 3: 貨車
    /// </summary>
    public byte CarType { get; set; }

    /// <summary>
    /// 計算費率ID
    /// </summary>
    public long RateDetailId { get; set; }

    /// <summary>
    /// 機台ID
    /// </summary>
    public long MachineInfoId { get; set; }

    /// <summary>
    /// 交易類型
    /// 1:自營
    /// 2:代開
    /// </summary>
    public byte TransactionType { get; set; }

    /// <summary>
    /// 狀態
    /// 1:正常
    /// 3:作廢
    /// 9:刪除
    /// 10:待辨識
    /// 
    /// </summary>
    public byte State { get; set; }

    /// <summary>
    /// 繳費狀態
    /// 0:未繳費
    /// 1:無須繳費/已繳費
    /// 2:免費
    /// </summary>
    public byte PayState { get; set; }

    /// <summary>
    /// 自動代繳
    /// 0:否
    /// 1:是
    /// </summary>
    public byte IsAutoPayment { get; set; }

    /// <summary>
    /// 上傳狀態
    /// 0:未上傳
    /// 1:已匯總上傳 (每日匯總)
    /// 2:資料異常未上傳
    /// 3:已開單上傳 (智慧柱即時)
    /// 4:已結單上傳 (智慧柱即時)
    /// </summary>
    public byte UploadState { get; set; }

    /// <summary>
    /// 上傳時間
    /// </summary>
    public DateTime? UploadDate { get; set; }

    /// <summary>
    /// 繳費截止日期
    /// </summary>
    public DateTime? PayDeadLine { get; set; }

    /// <summary>
    /// 繳費時間
    /// </summary>
    public DateTime? PayDate { get; set; }

    /// <summary>
    /// 廢單原因
    /// 1: 車號錯誤
    /// 2: 路段錯誤
    /// 3: 車格錯誤
    /// 4: 車種錯誤
    /// 5: 未按SOP作業誤開
    /// 6: 重複開單
    /// G: 誤開身障單
    /// O: 其他
    /// </summary>
    public string? VoidReason { get; set; }

    /// <summary>
    /// 廢單人員ID
    /// </summary>
    public long? VoidUserInfoId { get; set; }

    /// <summary>
    /// 開單時間
    /// </summary>
    public DateTime InsertTime { get; set; }

    /// <summary>
    /// 開單人員ID
    /// </summary>
    public long InsertUserInfoId { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 車辨柱用,判斷是否為新開
    /// </summary>
    public string? TempCarNo { get; set; }

    /// <summary>
    /// 暫存開單時間
    /// </summary>
    public DateTime? TempOpenTime { get; set; }

    /// <summary>
    /// 優先層級
    /// 1開始,由小到大,代表車辨柱辨識圖片的優先層級
    /// </summary>
    public int? HighLevel { get; set; }

    /// <summary>
    /// 廢單時間
    /// </summary>
    public DateTime? VoidTime { get; set; }

    public virtual RoadSection RoadSection { get; set; } = null!;

    public virtual ICollection<RoadSideOrderDetail> RoadSideOrderDetail { get; set; } = new List<RoadSideOrderDetail>();

    public virtual SiteInfo SiteInfo { get; set; } = null!;
}
