using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistMNG.Module.ControlStyle
{
    public static class TimerType
    {
        public static string VietnamTimeType(DateTime time)
        {
            return $"Ngày {time.Day} tháng {time.Month} năm {time.Year}";
        }
    }
}
