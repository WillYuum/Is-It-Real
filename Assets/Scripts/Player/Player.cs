using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainCharacter.Controls;
using DG.Tweening;
using WeaponCore;
namespace MainCharacter
{
    [RequireComponent(typeof(PlayerControls))]
    public class Player : MonoBehaviour
    {

        private PlayerControls _playerControls;

        [SerializeField] private WeaponController _holdingWeapon;
        [SerializeField] private LayerMask _shootableLayer;


        private void Awake()
        {
            _playerControls = GetComponent<PlayerControls>();

            _holdingWeapon.Load(GameVariables.instance.GetWeaponConfig(WeaponType.Pistol));
        }


        private void Start()
        {
            _playerControls.OnClickShootButton += HandlePlayerShoot;
            _playerControls.OnClickDashButton += HandlePlayerDash;
        }

        private void HandlePlayerShoot()
        {
            _holdingWeapon.Shoot();

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f, _shootableLayer);

            if (hit.collider != null)
            {
                IShootable shootable = hit.collider.GetComponent<IShootable>();

                if (shootable != null)
                {
                    shootable.ShootTarget();
                }
            }
        }


        private void HandlePlayerDash(Vector2 dir)
        {
            Vector3 newPos = transform.position + (Vector3)dir * 2f;
            transform.DOMove(newPos, 0.5f);
        }
    }
}