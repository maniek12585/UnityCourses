
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xStartVelocityValue;
    [SerializeField] float yStartVelocityValue;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor =0.2f;
    bool hasStarted = false;
    Vector2 paddleToBallVector; //distance beetween paddle and ball
    AudioSource myAudioSource;  // Cached component reference
    Rigidbody2D myRigidBody2d;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; // setting vector ball pos - paddle pos; 
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted){
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
   
    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
        hasStarted=true;
        myRigidBody2d.velocity = new Vector2 (xStartVelocityValue,yStartVelocityValue); 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak=new Vector2
        ( 
        Random.Range(0, randomFactor),
        Random.Range( 0, randomFactor) 
        );

        if(hasStarted)
        {
        AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
        myAudioSource.PlayOneShot(clip);
        myRigidBody2d.velocity += velocityTweak;
        }
    }




}
