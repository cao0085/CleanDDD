using System;
using System.Collections.Generic;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Models;

public partial class UserComanyMap
{
    /// <summary>
    /// 使用者自增長識別
    /// </summary>
    public long UserInfoId { get; set; }

    /// <summary>
    /// 企業自增長識別
    /// </summary>
    public long CompanyInfoId { get; set; }
}
