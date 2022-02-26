using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainCharacter.Controls
{

    public class PlayerControls : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 5f;


        public event Action onClickShootButton;


        void Update()
        {
            RotateTowardsPointer();

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            if (hor != 0 || ver != 0)
            {
                HandleMovement(hor, ver);
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
            if (onClickShootButton == null) return;

            onClickShootButton.Invoke();
        }
    }
}