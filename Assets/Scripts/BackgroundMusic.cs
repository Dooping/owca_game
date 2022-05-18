using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;

    [SerializeField]
    private Value difficulty;

    [SerializeField]
    private List<AudioClip> clips;

    private IEnumerator musicRoutine;
    private AudioSource audioSource;

    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
            audioSource = GetComponent<AudioSource>();
            difficulty.value = 0;
            musicRoutine = MusicRoutine();
            StartCoroutine(musicRoutine);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private IEnumerator MusicRoutine()
    {
        int clipIndex = 0;
        int loopCount = 0;
        while (true)
        {
            if (difficulty.value == 0)
            {
                clipIndex = loopCount / clips.Count;
                loopCount = (loopCount + 1) % (4 * clips.Count);
            } else if (difficulty.value < 100)
            {
                clipIndex = difficulty.value / 25;
            }
            audioSource.clip = clips[clipIndex];
            audioSource.Play();
            yield return new WaitForSecondsRealtime(audioSource.clip.length);
        }
    }
}
