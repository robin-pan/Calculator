using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class State
    {
        public string _name;
        public bool _numbersLocked;
        public bool _decimalLocked;
        public bool _deleteLocked;

        public State(string name = "", bool decimalLocked = false)
        {
            _name = name;
            _decimalLocked = decimalLocked;
        }
    }
}
