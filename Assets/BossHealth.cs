using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject area;

    public int health = 500;

    public GameObject deathEffect;

    public Vector2 bosspos;

    private void Start()
    {
        //bosspos = 
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
        Destroy(gameObject);
        soundmanager.PlaySound("bossdie");
        musicBG.PlaySound("BG");
        GameObject effectt =  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(area);
        Destroy(effectt, 0.4f);
    }

}

