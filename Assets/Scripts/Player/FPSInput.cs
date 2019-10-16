using System.Collections;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;

	private CharacterController _charController;
	private float _vertSpeed;

	void Start () {
		_charController = GetComponent<CharacterController> ();
		_vertSpeed = PlayerConst.minFall;
	}

	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);

		movement.y = _vertSpeed;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);

		_charController.Move (movement);

		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical"))
			Time.timeScale = 1;
		else
			Time.timeScale = 0.1f;
	}
}