﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomianLayer.Exceptions
{
    public class UnauthorizedException(string Message = "Invalid Email Or Password") : Exception(Message)
    {
    }
}
