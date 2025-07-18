﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Application.Common
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken ct = default);
    }
}
