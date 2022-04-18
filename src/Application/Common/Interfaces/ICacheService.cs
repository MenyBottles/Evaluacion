﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICacheService<T> where T : class
    {
        Task<IEnumerable<T>> GetFromCache();
    }
}
