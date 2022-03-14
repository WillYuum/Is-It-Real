using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponCore
{
    public enum WeaponType { Melee, Pistol, Rifle };
    public class WeaponController : MonoBehaviour
    {

        [SerializeField] private Transform _shootPoint;
        private bool _canShoot;
        private WeaponConfig _weaponConfig;
        private int _currentAmmo;

        public WeaponConfig WeaponConfig { get { return _weaponConfig; } }


        public void Load(WeaponConfig weaponConfig)
        {
            _weaponConfig = weaponConfig;
            _currentAmmo = weaponConfig.MaxAmmo;

            ToggleCanShoot(true);
        }


        public GameLoopAction<GunValues> Shoot()
        {
            var gameLoopAction = new GameLoopAction<GunValues>();

            if (_canShoot == false)
            {
                return gameLoopAction;
            }

            if (_currentAmmo > 0)
            {
                ToggleCanShoot(false);

                _currentAmmo--;

                if (_weaponConfig.ShootSFX != null)
                {
                    AudioManager.instance.PlaySFX(_weaponConfig.ShootSFX);
                }

                if (_weaponConfig.ShootPFX != null)
                {
                    PFXManager.instance.PlayPfx(_weaponConfig.ShootPFX, _shootPoint.position);
                }


                Invoke(nameof(SwitchToCanShoot), _weaponConfig.ShootDelay);

                gameLoopAction.Value = new GunValues(_currentAmmo, _weaponConfig.MaxAmmo);
            }
            else
            {
                //TODO: Play weapon is empty sound
            }

            return gameLoopAction;
        }

        private void SwitchToCanShoot()
        {
            ToggleCanShoot(true);
        }


        private void ToggleCanShoot(bool canShoot)
        {
            _canShoot = canShoot;
        }




    }





    [System.Serializable]
    public struct WeaponConfig
    {
        [SerializeField] public WeaponType WeaponType;
        [SerializeField] public float ShootDelay;
        [SerializeField] public int MaxAmmo;
        [SerializeField] public string ShootSFX;
        [SerializeField] public string ShootPFX;
    }
}

