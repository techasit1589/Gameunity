using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    // Start is called before the first frame update
    
    public enum KeyType
    {
        Red,
        Green,
        Blue,
    }
}
