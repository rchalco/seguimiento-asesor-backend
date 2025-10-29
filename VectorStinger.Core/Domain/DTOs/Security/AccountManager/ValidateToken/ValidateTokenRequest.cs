﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorStinger.Core.Domain.DTOs.Security.AccountManager.ValidateToken
{
    public record ValidateTokenRequest
    {
        public string Token { get; set; } = string.Empty;
    }
}
