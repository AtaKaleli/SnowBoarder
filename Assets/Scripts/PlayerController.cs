using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    [SerializeField] private float torqueAmount;
    
    
    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotate();
        BoostControl();
    }

    private void BoostControl()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            surfaceEffector2D.speed = 25;
        else
            surfaceEffector2D.speed = 15;
    }

    private void PlayerRotate()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddTorque(torqueAmount);
        else if (Input.GetKey(KeyCode.D))
            rb.AddTorque(-torqueAmount);
    }
}
