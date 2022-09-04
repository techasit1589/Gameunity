using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour
{
    [SerializeField] private int zoneheal;

    [SerializeField] PlayerMovement _heal;

    private void OnTriggerEnter2D(Collider2D heal)
    {
        if (heal.CompareTag("Player"))
        {
            if (_heal.playerHealth < 3)
            {
                Heal();
            }
        }

        void Heal()
        {
            _heal.playerHealth = _heal.playerHealth + zoneheal;
            _heal.UpdateHealth();
            gameObject.SetActive(false);
        }
    }
}

