using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.GenericSingletons;
using HUDCore.Screen;

namespace HUDCore
{
    public class HUD : MonoBehaviourSingleton<HUD>
    {

        [SerializeField] private ScreenController[] allScreen;
        private ScreenController _currentActiveScreen;


        public void SwitchToScreen(ScreenType screenType)
        {
            if (_currentActiveScreen != null)
            {
                _currentActiveScreen.ToggleScreen(false);
            }

            _currentActiveScreen = GetScreen(screenType);
            _currentActiveScreen.ToggleScreen(true);
        }


        private ScreenController GetScreen(ScreenType screenType)
        {
            for (int i = 0; i < allScreen.Length; i++)
            {
                if (allScreen[i].ScreenType == screenType)
                {
                    return allScreen[i];
                }
            }

#if UNITY_EDITOR
            Debug.LogError("No screen is active");
#endif

            return allScreen[0];
        }
    }
}