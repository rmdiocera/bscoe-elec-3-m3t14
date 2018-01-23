using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour {

    public float degreesPerSecond = 30f;
    public float amplitude = 3f;
    public float frequency = 0.1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start () {
        posOffset = transform.position;
        
    }

	
	// Update is called once per frame
	void Update () {
    tempPos = posOffset;
    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

    transform.position = tempPos;
}

    




}
