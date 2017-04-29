﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public interface IScanResultFactory
    {
        IScanResult File(string file);

        void Refresh();
    }
}
