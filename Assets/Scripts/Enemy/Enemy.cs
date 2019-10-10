using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private EnemyState _state;
    private bool _alive;
    public EnemyCharacter enemyCharacter { get; private set; }
    public bool alive { get { return _alive; } set { _alive = value; } }

    void Start () {
        enemyCharacter = GetComponent<EnemyCharacter>();
        _state = new WanderingState ();
        _alive = true;
    }

    void Update () {
        _state.Excute (this);
    }

    public void ChangeState (EnemyState state) {
        _state = state;
    }
}