using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ennemy : MonoBehaviour {
    public GameObject deathEffect;
    public float health = 7f;
    public static int EnemiesAlive = 0;

     void Start()
    {
        EnemiesAlive++;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.relativeVelocity.magnitude);

        if (col.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }
   void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;
        if (EnemiesAlive <= 0)
            Debug.Log("LEVEL WON");
        Destroy(gameObject);
    }
}
