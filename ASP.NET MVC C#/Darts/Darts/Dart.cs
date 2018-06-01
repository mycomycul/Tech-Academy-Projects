using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darts
{
    public class Dart
    {
        Random random = new Random();

        public int ThrowValue { get; set; }
        public string InnerOrOuterRing { get; set; }


        public void Throw()
        {
            int RingValue = random.Next(1, 20);
            //int RingValue = 1;  //debug
            ThrowValue = random.Next(0, 20);
            //ThrowValue = 0; //debug
            if (RingValue == 2)
            {
                if (ThrowValue == 0) InnerOrOuterRing = "bullseye";
                else InnerOrOuterRing = "innerring";
            }
            else if ((RingValue == 3) && (ThrowValue > 0)) { 
                InnerOrOuterRing = "outerring";
            }
            else InnerOrOuterRing = "normalring";

        }

    }


}
