using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tiltAmount; //The amount of tilt that should be applied to the ship when it moves from side to side.
    public float maxX, minX, maxY, minY, maxZ, minZ; //The maximum and minimum x and y positions that the ship can move to
    
    public GameObject bullet;
    public Transform bulletSp;

    public float fireRate;
    private float timeRate;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > timeRate)   
        {
            timeRate = Time.time + fireRate;
            Instantiate(bullet, bulletSp.position, bulletSp.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()   
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 
        rb.velocity = movement * speed;

        // Clamp the position to the game area
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(rb.position.x, minX, maxX),
            Mathf.Clamp(rb.position.y, minY, maxY),
            Mathf.Clamp(rb.position.z, minZ, maxZ)
            
        );
        rb.position = clampedPosition;

        // Calculate the tilt amount based on the ship's velocity
        float tilt = Mathf.Clamp(rb.velocity.x, -1f, 1f) * tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -tilt * 10f);
        rb.rotation = targetRotation;
    }
}

