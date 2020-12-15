using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

    public Animator Anim;
        
    
    void Awake()
    {
        Anim = GetComponent<Animator>();
    }

 public void Walk(bool walk)
    {
        Anim.SetBool(Animationtags.Walk_Para, walk);
    }

    public void Defend(bool defend)
    {
        Anim.SetBool(Animationtags.Defend_Para, defend);
    }

    public void Attack1()
    {
        Anim.SetTrigger(Animationtags.Attack1_Trigger);
    }

    public void Attack2()
    {
        Anim.SetTrigger(Animationtags.Attack2_Trigger);
    }


    public void FreezeAnimation()
    {
        Anim.speed = 0f;
    }


    public void UnFreezeAnimation()
    {
        Anim.speed = 1f;
    }


}//class