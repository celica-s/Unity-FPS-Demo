using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField]
    private Transform target;
    #pragma warning restore 0649

    public float rotSpeed = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotY;
    private float _rotX = 0;
    private Vector3 _offSet;

    void Start () {
        _rotY = transform.eulerAngles.y;
        _offSet = target.position - transform.position;
    }

    private void LateUpdate () {
        _rotY += Input.GetAxis ("Mouse X") * rotSpeed * 6;
        _rotX -= Input.GetAxis ("Mouse Y") * rotSpeed;
        _rotX = Mathf.Clamp (_rotX, minimumVert, maximumVert);
        Quaternion rotation = Quaternion.Euler (_rotX, _rotY, 0);

        transform.position = target.position - (rotation * _offSet);
        transform.LookAt (target);
    }
}