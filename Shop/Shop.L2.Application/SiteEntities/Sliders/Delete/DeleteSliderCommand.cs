﻿using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.SiteEntities.Sliders.Delete
{
    public record DeleteSliderCommand(long Id) : IBaseCommand;
}
