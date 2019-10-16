using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField]
    private GameObject fireBallPrefab;
    #pragma warning restore 0649
    private Camera _camera;
    private GameObject _fireBall;

    void Start () {
        _camera = GetComponent<Camera> ();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay (point);

            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                _fireBall = Instantiate (fireBallPrefab) as GameObject;
                _fireBall.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
                _fireBall.transform.rotation = transform.rotation;
            }
        }
    }

    private void OnGUI () {
        int size = 30;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float poxY = _camera.pixelHeight / 2 - size / 4;
        GUIStyle style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;

        GUI.Label (new Rect (posX, poxY, size, size), "*", style);
    }
}