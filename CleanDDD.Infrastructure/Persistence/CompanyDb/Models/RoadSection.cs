using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class RoadSection
{
    public long RoadSectionId { get; set; }

    /// <summary>
    /// 路段名稱
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// 外部編碼
    /// </summary>
    public string? ExtCode { get; set; }

    /// <summary>
    /// 行政區(場別)
    /// </summary>
    public string LocalCityArea { get; set; } = null!;

    /// <summary>
    /// 場地ID
    /// </summary>
    public long SiteInfoId { get; set; }

    /// <summary>
    /// 平日營業時間
    /// </summary>
    public string WeekdayStartTime { get; set; } = null!;

    /// <summary>
    /// 平日結束時間
    /// </summary>
    public string WeekdayEndTime { get; set; } = null!;

    /// <summary>
    /// 假日營業開始時間
    /// </summary>
    public string HolidayStartTime { get; set; } = null!;

    /// <summary>
    /// 假日營業結束時間
    /// </summary>
    public string HolidayEndTime { get; set; } = null!;

    /// <summary>
    /// 一般車格
    /// </summary>
    public string? CommonGrid { get; set; }

    /// <summary>
    /// 身障車格
    /// </summary>
    public string? DisabilityGrid { get; set; }

    /// <summary>
    /// 卸貨車格
    /// </summary>
    public string? UnloadGrid { get; set; }

    /// <summary>
    /// 平日一般費率
    /// </summary>
    public long? CommonRateId { get; set; }

    /// <summary>
    /// 平日身障費率
    /// </summary>
    public long? DisabilityRateId { get; set; }

    /// <summary>
    /// 平日卸貨費率
    /// </summary>
    public long? UnloadRateId { get; set; }

    public virtual ICollection<RoadSideOrder> RoadSideOrder { get; set; } = new List<RoadSideOrder>();

    public virtual SiteInfo SiteInfo { get; set; } = null!;
}
