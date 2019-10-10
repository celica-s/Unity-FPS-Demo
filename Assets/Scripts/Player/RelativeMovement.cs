using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMovement : MonoBehaviour {

    // [SerializeField]
    // private GameObject player;
    [SerializeField]
    private Transform target;

    private CharacterController _characterController;
    private float _vertSpeed;

    private void Start () {
        _characterController = GetComponent<CharacterController> ();
        _vertSpeed = PlayerConst.minFall;
    }

    void Update () {
        Vector3 movement = Vector3.zero;

        float horInput = Input.GetAxis ("Horizontal");
        float VerInput = Input.GetAxis ("Vertical");

        if (horInput != 0 || VerInput != 0) {
            movement.x = horInput * PlayerConst.moveSpeed;
            movement.z = VerInput * PlayerConst.moveSpeed;
            movement = Vector3.ClampMagnitude (movement, PlayerConst.moveSpeed);

            movement = transform.TransformDirection (movement);
        }

        if (_characterController.isGrounded) {
            if (Input.GetButtonDown ("Jump")) {
                _vertSpeed = PlayerConst.jumpSpeed;
            } else {
                _vertSpeed = PlayerConst.minFall;
            }
        } else {
            _vertSpeed += PlayerConst.gravity * 5 * Time.deltaTime;
            if (_vertSpeed < PlayerConst.terminalVelocity) {
                _vertSpeed = PlayerConst.terminalVelocity;
            }
        }

        movement.y = _vertSpeed;

        movement *= Time.deltaTime;
        _characterController.Move (movement);
    }
}