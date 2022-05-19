using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource owcaDying;
    [SerializeField]
    private AudioSource explosion;
    [SerializeField]
    private AudioSource collect;
    [SerializeField]
    private AudioSource unicornDying;
    [SerializeField]
    private AudioSource burn;
    [SerializeField]
    private AudioSource avocado;
    [SerializeField]
    private AudioSource happyBirthday;

    public void PlayOwcaDying()
    {
        owcaDying.Play();
    }
    public void PlayExplosion()
    {
        explosion.Play();
    }
    public void PlayCollect()
    {
        collect.Play();
    }
    public void PlayUnicornDying()
    {
        unicornDying.Play();
    }
    public void PlayBurn()
    {
        burn.Play();
    }
    public void PlayAvocado()
    {
        avocado.Play();
    }
    public void PlayHappyBirthday()
    {
        happyBirthday.Play();
    }

}
