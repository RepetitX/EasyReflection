﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EasyReflection.Cloning
{
    public interface IClonerProvider
    {
        IObjectCloner GetCloner(PropertyInfo PropertyInfo);
        IObjectCloner GetCloner(Type Type);
    }
}
