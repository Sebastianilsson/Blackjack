using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Model
{
    public interface ICard
    {
        public Color GetColor();
        public Value GetValue();
    }
}
