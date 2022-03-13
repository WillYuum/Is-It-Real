using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HUDCore.Utils;


namespace HUDCore.Screen
{
    public class GameScreen : ScreenController
    {
        [SerializeField] private CounterUI _counterUI;
        private void Awake()
        {
            SetScreenType(ScreenType.GameScreen);

            GameloopManager.instance.OnPlayerShoot += (v) =>
            {
                UpdateBulletCounter(v.CurrentCount, v.MaxCount);
            };

            GameloopManager.instance.OnLevelStart += (v) =>
            {
                UpdateBulletCounter(v.GunValues.CurrentCount, v.GunValues.MaxCount);
            };
        }


        private void UpdateBulletCounter(int currentCount, int maxCount)
        {
            _counterUI.UpdateCounter(currentCount, maxCount);
        }
    }
}