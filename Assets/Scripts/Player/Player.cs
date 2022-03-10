using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainCharacter.Controls;
using DG.Tweening;

namespace MainCharacter
{
    [RequireComponent(typeof(PlayerControls))]
    public class Player : MonoBehaviour
    {

        private PlayerControls _playerControls;

        [SerializeField] private LayerMask _shootableLayer;



        [SerializeField] private Transform _shootPoint;

        private void Awake()
        {
            _playerControls = GetComponent<PlayerControls>();
        }


        private void Start()
        {
            _playerControls.OnClickShootButton += HandlePlayerShoot;
            _playerControls.OnClickDashButton += HandlePlayerDash;
        }

        private void HandlePlayerShoot()
        {
            print("Player shoot");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 100f, _shootableLayer);

            if (hit.collider != null)
            {
                IShootable shootable = hit.collider.GetComponent<IShootable>();

                if (shootable != null)
                {
                    shootable.ShootTarget();
                }
            }

            PFXManager.instance.PlayPfx("GunShot", _shootPoint.position);
            AudioManager.instance.PlaySFX("GunShot");
        }


        private void HandlePlayerDash(Vector2 dir)
        {
            print("Player dash");

            Vector3 newPos = transform.position + (Vector3)dir * 2f;
            transform.DOMove(newPos, 0.5f);
        }
    }
}