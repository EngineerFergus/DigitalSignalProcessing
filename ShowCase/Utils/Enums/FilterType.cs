using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ShowCase.Utils.Enums
{
    public enum FilterType
    {
        [Description("Low Pass Filter")]
        LowPass = 0,
        [Description("High Pass Filter")]
        HighPass = 1,
        [Description("Band Pass Filter")]
        BandPass = 2,
        [Description("Band Reject Filter")]
        BandReject = 3
    }
}
