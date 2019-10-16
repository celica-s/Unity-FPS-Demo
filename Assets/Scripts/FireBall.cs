using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    [@HideInInspector]
    public float range = 100;
    [@HideInInspector]
    public int damage = 10;
    [@HideInInspector]
    public GameObject gun;
    public float speed = 10.0f;
    private Vector3 initPos;

    void Update () {
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter (Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter> ();
        EnemyCharacter enemy = other.GetComponent<EnemyCharacter> ();
        if (player != null) {
            player.Hurt (damage);
        } else if (enemy != null) {
            enemy.ReactToHit ();
        }
        Destroy (gameObject);
    }
}