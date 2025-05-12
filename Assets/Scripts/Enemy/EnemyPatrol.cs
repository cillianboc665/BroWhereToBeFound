using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private float idleTime;
    private float idleTimer;

    private void Start()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveDir(-1);
            else
                ChangeDir();
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveDir(1);
            else
                ChangeDir();
        }

    }

    private void ChangeDir()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleTime)
            movingLeft = !movingLeft;
    }

    private void MoveDir(int _dir)
    {
        idleTimer = 0;

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _dir, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _dir * speed, enemy.position.y, enemy.position.z);

    }
}
