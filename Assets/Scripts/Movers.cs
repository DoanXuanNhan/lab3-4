using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movers : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


  
}
