using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicEvents
{

    public static class TimerEvents
    {
        public static readonly string ADD_REMAINING_TIME = typeof(TimerEvents) + "ADD_REMAINING_TIME";

        public class AddRemainingTimeEventArgs: BasicEventArgs
        {
            public int TimeBonus { get; private set; }

            public AddRemainingTimeEventArgs(int timeBonus)
            {
                TimeBonus = timeBonus;
            }
        }
    }
}
