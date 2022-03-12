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


        public void Load(WeaponConfig weaponConfig)
        {
            _weaponConfig = weaponConfig;

            ToggleCanShoot(true);
        }


        public void Shoot()
        {
            if (_canShoot == false) return;

            if (_weaponConfig.Ammo > 0)
            {
                _weaponConfig.Ammo--;
                ToggleCanShoot(false);

                AudioManager.instance.PlaySFX(_weaponConfig.ShootSFX);
                PFXManager.instance.PlayPfx(_weaponConfig.ShootPFX, _shootPoint.position);

                Invoke(nameof(SwitchToCanShoot), _weaponConfig.ShootDelay);
            }
            else
            {
                //TODO: Play weapon is empty sound
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
        [SerializeField] public int Ammo;
        [SerializeField] public string ShootSFX;
        [SerializeField] public string ShootPFX;
    }
}