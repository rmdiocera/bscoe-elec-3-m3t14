using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket2 : MonoBehaviour {

    Rigidbody rb;
    GameObject rocket1, target;
    [SerializeField] float upwardThrust = 5f;
    [SerializeField] float sideThrust = 100f;
    AudioSource _thrustAudio;
    bool _isSoundPlaying;
    bool denyCollision;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _thrustAudio = GetComponent<AudioSource>();
        rocket1 = GameObject.Find("Rocketship - 1");
        target = GameObject.Find("Target Pod");
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
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
            target.GetComponent<Renderer>().material.color = Color.magenta;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (denyCollision == false)
        { 
            if (collision.gameObject.name == "Level2LeftWall" || collision.gameObject.name == "Level2RightWall" ||
                collision.gameObject.name == "Obstacle Up" || collision.gameObject.name == "Obstacle Up" ||
                collision.gameObject.name == "Obstacle Up2" || collision.gameObject.name == "Obstacle Up3" ||
                collision.gameObject.name == "Obstacle Down" || collision.gameObject.name == "Obstacle Down2" ||
                collision.gameObject.name == "Obstacle Down3")
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
        }

        if (collision.gameObject.name == "Target Pod")
        {
            SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        }



    }
}
