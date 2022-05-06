using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BasicEvents {
    public static class CoinsEvents
    {
        public static readonly string COIN_COLLECTED = typeof(CoinsEvents) + "COIN_COLLECTED";

        public class CoinCollectedEventArgs : BasicEventArgs
        {

        }
    }
}
