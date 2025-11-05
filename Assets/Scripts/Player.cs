using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 screenBounds;

    //how to define a variable
    //1. access modifier: public or private
    //2. data type: int, float, bool, string
    //3. variable name: camelCase
    //4. value: optional

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject bulletPrefab;

    public float Xmin { get; private set; }
    public float Xmax { get; private set; }
    public float Ymin { get; private set; }
    public float Ymax { get; private set; }
    public static object Transform { get; internal set; }

    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    
        playerSpeed = 6f;
        //This function is called at the start of the game
        
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();

    }
    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * 0, transform.position.y, 0);
        }
        //Player leaves the screen vertically
        if(transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    public void PlayerXRange()
    {

        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -7, 7);
        transform.position = pos;
    }
}
