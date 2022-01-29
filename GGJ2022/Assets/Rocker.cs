using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocker : MonoBehaviour
{
    public bool ShouldRock;
    private Rigidbody rb;
    public Vector3 force;
    public float timeToRock = 10;
    private float timer;

    [SerializeField] private AudioSource AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToRock)
        {
            ShouldRock = true;
            timer = 0;
        }
        
        if (ShouldRock)
        {
            ShouldRock = false;
            Rock();
        }
    }

    public void Rock()
    {
        rb.AddTorque(force, ForceMode.Force);
        AudioSource.Stop();
        AudioSource.Play();
    }
}