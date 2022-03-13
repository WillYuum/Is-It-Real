using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace HUDCore.Utils
{
    public class CounterUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;

        public void UpdateCounter(int currentCount, int maxCount)
        {
            _counter.text = currentCount + "/" + maxCount;
        }
    }
}