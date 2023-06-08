using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForPlayer : MonoBehaviour
{
    public static AudioForPlayer instance;

    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;
    public AudioSource source4;
    public AudioSource source5;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    private bool hasJumped = false;
    private bool isReloading = false;


	private void Awake()
	{
        instance = this;
	}

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

        if (Input.GetKey(KeyCode.Mouse0) && !isReloading)
        {
            source2.enabled = true;
        }

        else
        {
            source2.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped)
        {
            source3.PlayOneShot(clip1);

            hasJumped = true;
            StartCoroutine(ResetJumpAudio());
        }


    }
    public void playDeathSound()
    {
        source4.PlayOneShot(clip2);
    }
    public void playReloadSound()
    {
        source5.PlayOneShot(clip3);

        isReloading = true;
        StartCoroutine(EndOfReloadAudio());
    }

    private IEnumerator ResetJumpAudio()
    {
        yield return new WaitForSeconds(1);

        hasJumped = false;
    }

    private IEnumerator EndOfReloadAudio()
    {
        yield return new WaitForSeconds(2);

        isReloading = false;
    }
}
