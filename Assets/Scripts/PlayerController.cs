using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private SurfaceEffector2D surfaceEffector2D;
    private Rigidbody2D rb;
    [SerializeField] private float torqueAmount;
    [SerializeField] private float speedUp;
    [SerializeField] private float speedNormal;

    private bool isMove;

    private GameManager gameManager;
    private float rotateScore;
    

    void Start()
    {
        rotateScore = 0;
        gameManager = FindObjectOfType<GameManager>();
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
         
            surfaceEffector2D.speed = speedUp;
        }
        
        else
        {
            
            surfaceEffector2D.speed = speedNormal;
        }
    }

    private void PlayerRotate()
    {

        if (Input.GetKey(KeyCode.A))
        {

            rotateScore += (torqueAmount / 10000);
            gameManager.overallScore += rotateScore;
            

            rb.AddTorque(torqueAmount);

        }

        else if (Input.GetKey(KeyCode.D))
        {
            

            rotateScore += (torqueAmount/10000);
            
            gameManager.overallScore += rotateScore;
            
            rb.AddTorque(-torqueAmount);
        }

        else
            rotateScore = 0;


        

    }



    
}
