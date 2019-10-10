﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
    public float speed = 10.0f;
    public int damage = 1;

    // Update is called once per frame
    void Update () {
        transform.Translate (0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        EnemyCharacter enemy = other.GetComponent<EnemyCharacter>();
        if (player != null) {
            player.Hurt(damage);
        } else if(enemy != null) {
            enemy.ReactToHit();
        }
        Destroy(gameObject);
    }
}