using System;
using UnityEngine;
using BlurredObjects.BlurEffect;

namespace BlurredObjects
{
    public class BlurredObject : MonoBehaviour, IShootable
    {
        public bool IsBlurred { get; private set; }

        protected event Action OnGotShot;


        [SerializeField] private BlurEffectController _blurrEffectController;


        private void EnableBlur()
        {
            IsBlurred = true;
            _blurrEffectController.ToggleBlur(true);
        }

        private void DisableBlur()
        {
            IsBlurred = false;
            _blurrEffectController.ToggleBlur(false);
        }


        public void ShootTarget()
        {
#if UNITY_EDITOR
            if (OnGotShot == null)
            {
                Debug.LogError("OnGotShot event is not set");
                return;
            }
#endif

            if (OnGotShot != null)
            {
                OnGotShot.Invoke();
                DisableBlur();
            }
        }


    }
}


public interface IShootable
{
    void ShootTarget();
}