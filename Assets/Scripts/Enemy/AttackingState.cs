using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : EnemyState {
    #pragma warning disable 0649
    [SerializeField]
    private GameObject fireBallPrefab;
    #pragma warning restore 0649
    private GameObject _fireBall;

    public override void Excute (Enemy enemy) {
        if (!enemy.alive) {
            enemy.ChangeState (new DieState ());
        }

        enemy.enemyCharacter.Fire ();
        Ray ray = new Ray (enemy.transform.position, enemy.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast (ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (!hitObject.GetComponent<CharacterController> ()) {
                enemy.ChangeState (new WanderingState ());
            }
        }

    }
}