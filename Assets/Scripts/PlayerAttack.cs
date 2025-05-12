using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] beerBalls;
    private float cooldownTimer = Mathf.Infinity;
    private PlayerMovement PlayerMovement;

    private void Start()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        foreach (GameObject beerBall in beerBalls)
        {
            if (!beerBall.activeInHierarchy)
            {
                beerBall.transform.position = firePoint.position;
                beerBall.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
                return;
            }
        }
     
    }
}
