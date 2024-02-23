using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Gamemanager gamemanagerScript;
    public PoopBar poopBarScript;

    private float speedDecreaseRate = 3.0f;
    private float minMoveSpeed = 15.0f;
    private float turnSpeed = 80.0f; 
    public float speedIncrease = 5f;
    private float currentSpeed;
    private float initialMoveSpeed = 5.0f;
    private float liftForceMultiplier = 0.001f;
    private float maxSpeed = 50.0f;

    private float rotationToNormalSpeed = 20.0f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();
        currentSpeed = initialMoveSpeed;
    }

    // Update is called once per frame
   
    private void Update()
    {
        if (!gamemanagerScript.gameOver)
        {

        
       //get inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        bool speedUp = Input.GetKey(KeyCode.Space);
        float verticalTurn = verticalInput * turnSpeed * Time.deltaTime;
        float horizontalTurn = horizontalInput * turnSpeed * Time.deltaTime;
        //rotate
        transform.Rotate(verticalTurn, horizontalTurn, 0);
       
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 0f, rotationToNormalSpeed * Time.deltaTime);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
       
        //adjust speed
        if (speedUp && currentSpeed < maxSpeed)
        {
            currentSpeed += speedIncrease * Time.deltaTime;
        }
        else
        {
            currentSpeed = Mathf.Max(currentSpeed - speedDecreaseRate * Time.deltaTime, minMoveSpeed);
        }
        //apply up force and move forward
        float liftForce = currentSpeed * liftForceMultiplier;
       rb.AddForce(Vector3.up * liftForce);
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Treat"))
        {
           
            poopBarScript.UpdatePoopBar(20);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Guardian"))
        {
            gamemanagerScript.gameOver = true;
            Debug.Log("Gameover");
        }
    

    }

}
