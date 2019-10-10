using UnityEngine;
using System.Collections;

[AddComponentMenu("Control Script/Mouse Look")]
public class MouseLook : MonoBehaviour {
	public enum RotationAxes {
		MouseXAndY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public RotationAxes axes = RotationAxes.MouseXAndY;

	public float sensitivityHor = 9.0f;
	public float sensitivityVert = 9.0f;
	
	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationY = 0;
	
	void Start() {
		// Make the rigid body not change rotation
		Rigidbody body = GetComponent<Rigidbody>();
		if (body != null)
			body.freezeRotation = true;
	}

	void Update() {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
		}
		else if (axes == RotationAxes.MouseY) {
			_rotationY -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationY = Mathf.Clamp(_rotationY, minimumVert, maximumVert);
			
			float rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(_rotationY, rotationY, 0);
		}
		else {
			float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityHor;

			_rotationY -= Input.GetAxis("Mouse Y") * sensitivityVert;
			_rotationY = Mathf.Clamp(_rotationY, minimumVert, maximumVert);

			transform.localEulerAngles = new Vector3(rotationY, _rotationY, 0);
		}
	}
}