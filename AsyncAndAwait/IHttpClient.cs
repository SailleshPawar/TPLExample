﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndAwait
{
    public interface IHttpClient
    {

        Task<string> GetStringAsync(string Url);
    }
}
