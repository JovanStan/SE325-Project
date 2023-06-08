using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForPlayer : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioSource source4;
    public AudioSource source5;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W))
        {

            source1.enabled = true;

        }
        else
        {
            source1.enabled = false;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            source2.enabled = true;
        }

        else
        {
            source2.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            source3.PlayOneShot(clip1);
        }


    }
    public void playDeathSound()
    {
        source4.PlayOneShot(clip2);
    }
    public void playReloadSound()
    {
        source5.PlayOneShot(clip3);
    }
}
