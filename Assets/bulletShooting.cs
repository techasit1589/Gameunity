using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooting : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public int damage = 40;
    public GameObject impactEffect;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 roration = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized*force;
        float rot = Mathf.Atan2(roration.y, roration.x)*Mathf.Rad2Deg;
        transform.rotation=Quaternion.Euler(0 ,0,rot+180);
        StartCoroutine(ExampleCoroutine());
    }
    void Update()
    {
        ExampleCoroutine();
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Boss")
        {
            BossHealth enemy = hitInfo.GetComponent<BossHealth>();
            if (enemy != null)
            {
                soundmanager.PlaySound("hit");
                enemy.TakeDamage(damage);
            }

            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(effect,0.4f);
        }
        else if(hitInfo.gameObject.tag == "ground")
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(effect, 0.4f);
        }
        else if (hitInfo.gameObject.tag == "bluebutton")
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(effect, 0.4f);
        }
        else if (hitInfo.gameObject.tag == "redbutton")
        {
            GameObject effect = Instantiate(impactEffect, transform.position, transform.rotation);

            Destroy(gameObject);
            Destroy(effect, 0.4f);
        }

    }
}
