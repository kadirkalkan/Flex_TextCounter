﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Api.Application.Interfaces;

public interface IHttpService
{
    Task<string> SendGetAsync(string url);
}
