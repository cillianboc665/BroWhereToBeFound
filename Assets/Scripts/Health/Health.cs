using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth { get; private set; }

    private bool dead;

    private void Start()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {

        }
        else
        {
            if (GetComponent<PlayerMovement>() != null)
                GetComponent<PlayerMovement>().enabled = false;

            if (GetComponentInParent<EnemyPatrol>() != null)
                GetComponentInParent<EnemyPatrol>().enabled = false;

            //if (GetComponent<Enemy>() != null)
                //GetComponent<Enemy>().enabled = false;

            dead = true;
        }
    }
}
