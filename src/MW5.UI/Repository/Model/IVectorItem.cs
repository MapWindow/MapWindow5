﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Repository.Model
{
    public interface IVectorItem : IRepositoryItem
    {
        string GetFilename();
    }
}
