using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HUDCore.Screen
{
    public enum ScreenType { PauseMenu, GameOver, GameScreen }
    public class ScreenController : MonoBehaviour
    {
        private ScreenType _screenType;

        public ScreenType ScreenType { get { return _screenType; } }

        public void ToggleScreen(bool active)
        {
            gameObject.SetActive(active);
        }

        protected void SetScreenType(ScreenType screenType)
        {
            _screenType = screenType;
        }
    }

}
