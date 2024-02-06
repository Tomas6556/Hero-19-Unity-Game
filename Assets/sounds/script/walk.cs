using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    [SerializeField] private AudioSource Steap;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.A))
            Steap.Stop();
        if (Input.GetKeyDown(KeyCode.D))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.D))
            Steap.Stop();
        if (Input.GetKeyDown(KeyCode.S))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.S))
            Steap.Stop();
        if (Input.GetKeyDown(KeyCode.W))
            Steap.Play();
        else if (Input.GetKeyUp(KeyCode.W))
            Steap.Stop();
    }
}
