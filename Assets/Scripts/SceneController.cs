using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
#pragma warning disable 0649
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private int number = 1;
#pragma warning restore 0649
    private GameObject _enemy;

    // Update is called once per frame
    void Update () {
        if (_enemy == null) {
            for (int i = 0; i < number; i++) {
                _enemy = Instantiate (enemyPrefab) as GameObject;
                float randomX = Random.Range (-24, 24);
                float randomZ = Random.Range (-24, 24);
                // Debug.Log(randomX + randomX);
                _enemy.transform.position = new Vector3 (randomX, 1, randomZ);
                float angle = Random.Range (0, 360);
                _enemy.transform.Rotate (0, angle, 0);
            }

        }
    }
}