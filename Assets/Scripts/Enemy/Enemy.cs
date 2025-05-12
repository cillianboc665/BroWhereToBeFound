using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] beerballs;

    [SerializeField] private float colliderDist;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer;

    private EnemyPatrol enemypatrol;

    private void Start()
    {
        enemypatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= cooldown)
            {
                cooldownTimer = 0;
            }
        }

        if (enemypatrol != null)
        {
            enemypatrol.enabled = PlayerInSight();
        }
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        beerballs[0].transform.position = firePoint.position;
        beerballs[0].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindBeerBall()
    {
        for (int i = 0; i < beerballs.Length; i++)
        {
            if (!beerballs[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDist, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDist, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
