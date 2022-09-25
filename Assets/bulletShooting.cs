using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletShooting : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
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
}
