using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{

    private CharacterAnimation playerAnimation;
    public GameObject AttackPoint;
    private Playershield shield;

    private CharacterSoundFX soundFX;


    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimation>();
        shield = GetComponent<Playershield>();

        soundFX = GetComponentInChildren<CharacterSoundFX>();
    }

 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);

            shield.ActivateShield(true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
            shield.ActivateShield(false);
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            if(Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack1();
                soundFX.Attack_1();
            }
            else
            {
                playerAnimation.Attack2();
                soundFX.Attack_2();
            }
        }
    }//update

    void Activate_Attackpoint()
    {
        AttackPoint.SetActive(true);
    }


    void Deactivate_Attackpoint()
    {
        if(AttackPoint.activeInHierarchy)
        {
            AttackPoint.SetActive(false);
        }
    }

}//class
