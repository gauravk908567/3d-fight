using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundFX : MonoBehaviour
{

    private AudioSource soundFX;
   
    public AudioClip attack_sound_1, die, attack_sound_2;
    void Awake()
    {
        soundFX = GetComponent<AudioSource>();
    }

    public void Attack_1()
    {
        soundFX.clip = attack_sound_1;
        soundFX.Play();
    }

    public void Attack_2()
    {
        soundFX.clip = attack_sound_2;
        soundFX.Play();
    }


    public void Die()
    {
        soundFX.clip = die;
        soundFX.Play();
    }

}//class
