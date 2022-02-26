using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BlurredObject.BlurEffect
{
    public class BlurEffectController : MonoBehaviour
    {
        public void ToggleBlur(bool isBlured)
        {
            gameObject.SetActive(isBlured);
        }
    }
}