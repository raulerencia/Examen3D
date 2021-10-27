using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip steps1;
    public AudioClip steps2;
    public float stepDuration;
    private int stepCount;
    private bool isPlaying;

    private AudioSource audioSource;

    void Awake()    
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        stepCount = 0;
        isPlaying = false;
    }

    public void AudioSteps()
    { 
       if (isPlaying == false)
        {
            isPlaying = true;
            stepCount++;
            if (stepCount % 2 == 1)
            {
                audioSource.PlayOneShot(steps1, 1f);
            }
            else
            {
                audioSource.PlayOneShot(steps2, 1f);
            }
            StartCoroutine(WaitStepTime());
        }
    }

    IEnumerator WaitStepTime()
    {
        yield return new WaitForSeconds(stepDuration);
        isPlaying = false;
    }
    
}

