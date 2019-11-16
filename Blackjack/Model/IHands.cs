﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface IHands
    {
        IReadOnlyList<ICard> PlayerCards {get; }
    }
}
