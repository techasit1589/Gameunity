using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject area;

    public int health = 500;

    public GameObject deathEffect;

    public Vector2 bosspos;

    GameManager gameManager;
    [SerializeField] GameObject manager;

    volumTest volumTestt;
    [SerializeField] GameObject volumm;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("pushable");
        gameManager = manager.GetComponent<GameManager>();

        volumm = GameObject.FindGameObjectWithTag("Cmusic");
        volumTestt = volumm.GetComponent<volumTest>();
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
        gameManager.bossnotdie=false;
        Destroy(gameObject);
        volumTestt.scene = 11;
        soundmanager.PlaySound("bossdie");
        GameObject effectt =  Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(area);
        Destroy(effectt, 0.4f);
    }

}

