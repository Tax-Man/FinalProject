using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject40S
{
    public class Type1 : Aircraft, Military
    {
        public void OverrideFCT()
        {
            throw new NotImplementedException();
        }
        public new string Code
        {
            get => Code;
            set => Code = value;
        }

    }
}