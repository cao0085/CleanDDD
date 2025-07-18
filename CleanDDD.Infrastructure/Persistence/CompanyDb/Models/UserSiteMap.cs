using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

public partial class UserSiteMap
{
    /// <summary>
    /// 使用者ID
    /// </summary>
    public long UserInfoId { get; set; }

    /// <summary>
    /// 場地ID
    /// </summary>
    public long SiteInfoId { get; set; }
}
