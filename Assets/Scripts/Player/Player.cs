using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainCharacter.Controls;
using System;

namespace MainCharacter
{
    [RequireComponent(typeof(PlayerControls))]
    public class Player : MonoBehaviour
    {

        private PlayerControls _playerControls;

        [SerializeField] private LayerMask _shootableLayer;

        private void Awake()
        {
            _playerControls = GetComponent<PlayerControls>();
        }


        private void Start()
        {
            _playerControls.onClickShootButton += HandlePlayerShoot;
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
        }



    }
}