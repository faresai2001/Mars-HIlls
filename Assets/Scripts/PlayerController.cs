using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotateSpeed;
    public float verticalInput;
    public float horizontalInput;
    public Rigidbody2D tire1;
    public Rigidbody2D tire2;
    public Rigidbody2D car;
    private Vector3 startPos;
    public GameObject player;
    private float boundary = -12f;
    private float leftRotation = 180.0f;
    private float rightRotation = 230.0f;
    private GameManager gameManager;
    public bool hasPowerup;
    private float boost = 65f;
    private float normalSpeed = 40f;
    public GameObject boostEffect;
    private float timer = 0.0f;
    private float maxFlipTime = 5.0f;
    private float winBound = 653.0f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {

            MoveCar();
            
        }

        Debug.Log(player.transform.localEulerAngles.z);

        if (player.transform.localEulerAngles.z > leftRotation && player.transform.localEulerAngles.z < rightRotation)
        {
            if (timer >= maxFlipTime)
            {
                gameManager.GameOver();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

        else
        {
            timer = 0.0f;
            
        }

        if ( player.transform.position.y < boundary)
        {
            gameManager.GameOver();
            Destroy(gameObject);
            
        }

        if(player.transform.position.x > winBound)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

    }

    private void MoveCar()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        car.AddForce(Vector3.right * speed * verticalInput);
        car.AddTorque(-verticalInput * rotateSpeed * Time.deltaTime);
        tire1.AddTorque(-verticalInput * speed * Time.deltaTime);
        tire2.AddTorque(-verticalInput * speed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        speed = boost;
        StartCoroutine(PowerupCountdownRoutine());
        boostEffect.SetActive(true);

    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        speed = normalSpeed;
        hasPowerup = false;
        boostEffect.SetActive(false);
    }
}


