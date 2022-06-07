using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 25.0f;
    public float horizontalInput;
    public float forwardInput;
	private Rigidbody playerRb;
    //private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool isOnGround = true;
    public bool gameOver;
    public GameObject GameText;
	
    // Start is called before the first frame update
    void Start()
    { 
    
    }

    // Update is called once per frame
    void Update()
    {	
	    // THis is where we get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
	    
		if (gameOver)
		{
			// stop moving
		    transform.Translate(Vector3.forward * Time.deltaTime * 0 * forwardInput);
             // We turn the cehicle 
            transform.Rotate(Vector3.up, Time.deltaTime * 0 * horizontalInput);
		} else {	
            // We move the vehicle forward
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // We turn the cehicle 
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
	    }	

    }
	
	private void OnCollisionEnter(Collision collision)
    {		
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();

        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            // playerAnim.SetBool("Death_b", true);
            // playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            //playerAudio.PlayOneShot(crashSound, 1.0f);
			GameText.SetActive(true); // false to hide, true to show

        }
	}
}	