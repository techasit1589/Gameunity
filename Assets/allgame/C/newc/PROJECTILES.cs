using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PROJECTILES : MonoBehaviour
{
    public float projectilesSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.velocity=transform.right*projectilesSpeed;
        StartCoroutine(ExampleCoroutine());
    }
    void Update(){
        ExampleCoroutine();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag=="Player"){
            Destroy(this.gameObject);
        }
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
