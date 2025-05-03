﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Exceptions
{
    public sealed class BadRequestException(List<string> errors) : Exception("Validation Failed")
    {
        public List<string> Errors { get; } = errors;
    }
}
