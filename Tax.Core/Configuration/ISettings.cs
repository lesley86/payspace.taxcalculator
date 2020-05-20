using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Core.Configuration
{
    public interface ISettings
    {
        SqlServer SqlServer { get; }
    }
}
