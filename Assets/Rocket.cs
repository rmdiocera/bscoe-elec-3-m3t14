using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    Rigidbody rb;
    GameObject rocket1, target;
    [SerializeField] float upwardThrust = 50f;
    public float sideThrust = 100f;
    AudioSource _thrustAudio;
    bool _isSoundPlaying;
    bool denyCollision;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        _thrustAudio = GetComponent <AudioSource>(); 
        rocket1 = GameObject.Find("Rocketship - 1");
        target = GameObject.Find("Target Pod");
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void RestartLevel()
    {
        transform.position = new Vector3(27.71f, 4.65f, 5.45f);
        transform.rotation = Quaternion.identity;
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);
    }

    private void ProcessInput()
    {
        float rocketTurnSpeed = sideThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            _thrustAudio.Play();
            rb.AddRelativeForce(Vector3.up * upwardThrust);
            _isSoundPlaying = true;
            if (_isSoundPlaying)
            {
                _thrustAudio.Play();
                
            }

            else
            {
                _thrustAudio.Stop();
                _isSoundPlaying = false;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(Vector3.back * rocketTurnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.transform.Rotate(Vector3.forward * rocketTurnSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            denyCollision = !denyCollision;
        }

        if (Vector3.Distance(rocket1.transform.position, target.transform.position) < 10)
        {
            target.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (denyCollision == false)
        {


            if (collision.gameObject.name == "Obstacle" || collision.gameObject.name == "Sphere" ||
                collision.gameObject.name == "Obstacle - Asteroid" || collision.gameObject.name == "Obstacle - Rocketship" ||
                collision.gameObject.name == "Cylinder" || collision.gameObject.name == "Left Wall" ||
                collision.gameObject.name == "Right Wall" || collision.gameObject.name == "Top Wall")
            {
                RestartLevel();
            }

        }
        if (collision.gameObject.name == "Target Pod")
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);   
        }
        
        

    }

}
