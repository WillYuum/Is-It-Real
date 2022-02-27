using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayeUtils;

namespace MainCharacter.Controls
{
    [System.Serializable]
    public class DashController
    {
        [SerializeField] public float DashSpeed = 5;
        [HideInInspector] public bool CanDash = true;
        [SerializeField] public float DashCooldown = 5;
    }

    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 5f;


        [SerializeField] DashController _dashController;


        //------Player input events
        public event Action OnClickShootButton;
        public event Action<Vector2> OnClickDashButton;


        private DelayController _delayController;


        void Update()
        {
            RotateTowardsPointer();

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            if (hor != 0 || ver != 0)
            {
                if (_dashController.CanDash && Input.GetKeyDown(KeyCode.Space))
                {
                    PlayerClickedDashButton(hor, ver);
                }
                else
                {
                    HandleMovement(hor, ver);
                }

            }



            //shoot
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PlayerClickedShootButton();
            }



        }

        private void HandleMovement(float horizontal, float vertical)
        {
            Vector3 move = new Vector3(horizontal, vertical, 0);
            transform.position += move * _playerSpeed * Time.deltaTime;
        }

        private void RotateTowardsPointer()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector2 direction = mousePos - playerPos;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        }


        private void PlayerClickedShootButton()
        {
            if (OnClickShootButton == null) return;

            OnClickShootButton.Invoke();
        }


        private void PlayerClickedDashButton(float horizontal, float vertical)
        {
            if (OnClickDashButton == null) return;

            if (vertical < 0)
            {
                vertical = -1;
            }
            else if (vertical > 0)
            {
                vertical = 1;
            }

            if (horizontal < 0)
            {
                horizontal = -1;
            }
            else if (horizontal > 0)
            {
                horizontal = 1;
            }

            Vector2 dir = new Vector2(horizontal, vertical) * _dashController.DashSpeed;
            OnClickDashButton.Invoke(dir);

            _dashController.CanDash = false;

            Invoke(nameof(EnableDash), _dashController.DashCooldown);
        }

        private void EnableDash()
        {
            _dashController.CanDash = true;
        }
    }
}