using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BlurredObject.BlurEffect;

namespace BlurredObject
{
    public enum BlurredObjectType { Dangerous, Safe };
    public class BlurredObject : MonoBehaviour
    {
        public bool IsBlurred { get; private set; }

        [SerializeField] private BlurEffectController _blurrEffectController;


        public void EnableBlur()
        {
            IsBlurred = true;
            _blurrEffectController.ToggleBlur(true);
        }

        public void DisableBlur()
        {
            IsBlurred = false;
            _blurrEffectController.ToggleBlur(false);
        }
    }
}
