using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField]
    private GameObject fireBallPrefab;
    #pragma warning restore 0649

    private GameObject _fireBall;
    private bool _alive;

    public bool alive {
        set { _alive = value; }
    }
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private void Start () {
        _alive = true;
    }
    void Update () {
        if (_alive) {
            transform.Translate (0, 0, speed * Time.deltaTime);

            Ray ray = new Ray (transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast (ray, 0.75f, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter> ()) {
                    if (_fireBall == null) {
                        _fireBall = Instantiate (fireBallPrefab) as GameObject;
                        _fireBall.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
                        _fireBall.transform.rotation = transform.rotation;
                    }
                } else if (hit.distance < obstacleRange) {
                    float angle = Random.Range (-110, 110);
                    transform.Rotate (0, angle, 0);
                }
            }
        }

    }

}