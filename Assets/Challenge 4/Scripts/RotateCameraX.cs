using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 200;
    public GameObject player;
    public ParticleSystem smokeParticles;
    private Vector3 particlePosOffset = new Vector3(0, 0.68f, 0);

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        //Set particle position
        smokeParticles.GetComponent<ParticleSystem>();
        smokeParticles.transform.position = transform.position - particlePosOffset;

        transform.position = player.transform.position; // Move focal point with player

        //Play particle effect
        if (Input.GetKeyDown(KeyCode.Space))
        {
            smokeParticles.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            smokeParticles.Stop();
        }
    }
}
