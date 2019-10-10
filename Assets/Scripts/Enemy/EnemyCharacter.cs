using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField]
    private GameObject fireBallPrefab;
    #pragma warning restore 0649
    private GameObject _fireBall;
    public void ReactToHit () {
        Enemy ai = GetComponent<Enemy> ();
        if (ai != null) {
            ai.alive = false;
        }

        StartCoroutine (Die ());
    }

    private IEnumerator Die () {
        Vector3 movement = new Vector3(-90,0,0);
        movement = transform.TransformDirection(movement);
        Quaternion rotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 15 * Time.deltaTime);

        yield return new WaitForSeconds (1.5f);

        Destroy (gameObject);
    }

    public void Fire () {
        if (_fireBall == null) {
            _fireBall = GameObject.Instantiate (fireBallPrefab) as GameObject;
            _fireBall.transform.position = transform.TransformPoint (Vector3.forward * 1.5f);
            _fireBall.transform.rotation = transform.rotation;
        }
    }
}