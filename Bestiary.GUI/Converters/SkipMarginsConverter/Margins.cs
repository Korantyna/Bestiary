﻿using System;

namespace Bestiary.GUI.Converters
{
    [Flags]
    public enum Margins
    {
        None = 0,
        Left = 1,
        Top = 2,
        Right = 4,
        Bottom = 8,
        All = Left | Top | Right | Bottom
    }
}
