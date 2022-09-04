using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamage : MonoBehaviour
{
    [SerializeField] private int zoneDamage;

    [SerializeField] PlayerMovement _healcontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Damage();
        }
    }

    void Damage()
    {
        _healcontroller.playerHealth = _healcontroller.playerHealth - zoneDamage;
        _healcontroller.UpdateHealth();
        gameObject.SetActive(false);
    }
}
