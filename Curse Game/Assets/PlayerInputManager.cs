using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SG
{
    public class PlayerInputManager : MonoBehaviour
    {
        // Goals
        // 1. Find way to read inputs
        // 2. Move characters according to values
        PlayerControls PlayerControls;
         [SerializeField] Vector2 movement;

        private void OnEnable()
        {
            if (PlayerControls == null)
            {
                PlayerControls = new PlayerControls();

                PlayerControls.PlayerMovement.Movement.performed += i => i.ReadValue<Vector2>();
            }
            
            PlayerControls.Enable();
        }
    }
}

