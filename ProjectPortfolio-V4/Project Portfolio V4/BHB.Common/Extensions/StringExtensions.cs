using System;
using System.Collections.Generic;
using System.Text;

namespace BHB.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this String value)
        {
            return String.IsNullOrEmpty(value);
        }
    }
}
