using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class shooting : MonoBehaviour
{
    private Camera mainCam;

    private Vector3 mousePos;

    PlayerMovement playerMovement;
    [SerializeField] GameObject Player;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private float rotZ;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = Player.GetComponent<PlayerMovement>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerMovement.canMove && playerMovement.gotreward1)
        {
            this.gameObject.SetActive(false);
        }
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        if (playerMovement.isFacingRight)
        {
            rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        }
        else if (!playerMovement.isFacingRight)
        {
            rotZ = Mathf.Atan2(-rotation.y, -rotation.x) * Mathf.Rad2Deg;
        }
        transform.rotation=Quaternion.Euler(0,0,rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire && playerMovement.playerHealth>=1 && Time.timeScale == 1)
        {
            soundmanager.PlaySound("shoot");
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
