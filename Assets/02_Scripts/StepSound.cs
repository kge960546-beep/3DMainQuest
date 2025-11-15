using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private void Awake()
    {
        if (audio == null)
            audio = GetComponent<AudioSource>();

        if (audio != null)
            audio.playOnAwake = false;
    }
    public void PlayStep()
    {
        if (audio == null) return;
        audio.Stop();
        audio.Play();

    }
}
