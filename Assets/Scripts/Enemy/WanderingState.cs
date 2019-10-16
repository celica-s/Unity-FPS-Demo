using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingState : EnemyState {
    public override void Excute (Enemy enemy) {
        if (!enemy.alive) {
            enemy.ChangeState (new DieState ());
            // return;
        }
        
        enemy.transform.Translate (0, 0, EnemyConst.speed * Time.deltaTime);

        Ray ray = new Ray (enemy.transform.position, enemy.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast (ray, 0.75f, out hit)) {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter> ()) {
                enemy.ChangeState (new AttackingState ());
            }

            if (hit.distance < EnemyConst.obstacleRange) {
                float angle = Random.Range (-110, 110);
                enemy.transform.Rotate (0, angle, 0);
            }
        }

    }
}