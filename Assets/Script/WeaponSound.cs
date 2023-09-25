using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip load;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

   public void PlayShootEffect()
    {
        audioSource.PlayOneShot(shoot);
    }

    public void PlayLoadEffect()
    {
        audioSource.PlayOneShot(load);
    }
}
