using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public int health = 500;

    public GameObject deathEffect;

    public Vector2 bosspos;

    private void Start()
    {
        bosspos = this.transform.position;
    }
    public void TakeDamage(int damage)
    {
       

        health -= damage;

        if (health <= 200)
        {
            //GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        soundmanager.PlaySound("bossdie");
        musicBG.PlaySound("BG");
        GameObject effectt =  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effectt, 0.4f);
    }

}

