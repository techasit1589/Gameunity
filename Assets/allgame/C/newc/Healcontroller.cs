//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Healcontroller : MonoBehaviour
//{
//    public int playerHealth;

//    [SerializeField] private Image[] hearts;
//    private void Start()
//    {
//        UpdateHealth();
//    }

//    public void UpdateHealth()
//    {

//        if(playerHealth <= 0)
//        {
//            Debug.Log("ตาย");
//        }

//        for (int i = 0; i < hearts.Length; i++)
//        {
//            if (i < playerHealth) {
//                hearts[i].gameObject.SetActive(true);
//                //hearts[i].color = Color.red;
//            }
//            else
//            {
//                hearts[i].gameObject.SetActive(false);
//                //hearts[i].color = Color.black;
//            }
//        }
//    }
//}
