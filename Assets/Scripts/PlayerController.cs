using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    [SerializeField] private float torqueAmount;

    private bool isMove;
    

    void Start()
    {
        
        isMove = true;
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            PlayerRotate();
            BoostControl();
    
        }
        
    }

    public void changeMove()
    {
        isMove = false;
    }

    private void BoostControl()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AudioManager.instance.PlaySpeedUpSFX();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
         
            surfaceEffector2D.speed = 25;
        }
        
        else
        {
            
            surfaceEffector2D.speed = 15;
        }
    }

    private void PlayerRotate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            
            AudioManager.instance.PlayClappingBackgroundAudio();
            rb.AddTorque(torqueAmount);

        }

        else if (Input.GetKey(KeyCode.D))
        {
            
            AudioManager.instance.PlayClappingBackgroundAudio();
            rb.AddTorque(-torqueAmount);
        }

    }



    
}
