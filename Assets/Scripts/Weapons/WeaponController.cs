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


        public GunValues Shoot()
        {
            if (_canShoot == false)
            {
                return GunValues.DidntShoot(_currentAmmo, _weaponConfig.MaxAmmo);
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

                return new GunValues(_currentAmmo, _weaponConfig.MaxAmmo);
            }
            else
            {
                //TODO: Play weapon is empty sound
                return GunValues.DidntShoot(0, _weaponConfig.MaxAmmo);
            }
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