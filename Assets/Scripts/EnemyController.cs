using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    CHASE,
    ATTACK
}



public class EnemyController : MonoBehaviour
{

    private CharacterAnimation enemy_anim;
    private NavMeshAgent navAgent;
    private Transform playerTarget;

    public float move_speed = 3.5f;

    public float attack_distance = 1.3f;
    public float chase_player_after_attack_distance = 1f;

    private float wait_before_attack_time = 3f;
    private float attack_timer;

    private EnemyState enemy_State;

    public GameObject AttackPoint;

    private CharacterSoundFX soundFX;
    
    
    void Awake()
    {
        enemy_anim = GetComponent<CharacterAnimation>();
        navAgent = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;

        soundFX = GetComponentInChildren<CharacterSoundFX>();

    }


    void Start()
    {
        enemy_State = EnemyState.CHASE;
        attack_timer = wait_before_attack_time;
    }


    // Update is called once per frame
    void Update()
    {
        if(enemy_State==EnemyState.CHASE)
        {
            Chaseplayer();
        }

        if(enemy_State==EnemyState.ATTACK)
        {
            Attackplayer();
        }
    }


    void Chaseplayer()
    {
        navAgent.SetDestination(playerTarget.position);
        navAgent.speed = move_speed;

        if(navAgent.velocity.sqrMagnitude==0)
        {
            enemy_anim.Walk(false);
        }
        else
        {
            enemy_anim.Walk(true);
        }
        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_distance)
        {
            enemy_State = EnemyState.ATTACK;
        }
    }

    void Attackplayer()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        enemy_anim.Walk(false);
        attack_timer += Time.deltaTime;
        if(attack_timer>wait_before_attack_time)
        {
            if(Random.Range(0,2)>0)
            {
                enemy_anim.Attack1();
                soundFX.Attack_1();
            }
            else
            {
                enemy_anim.Attack2();
                soundFX.Attack_2();
            }

            attack_timer = 0f;
        }//if we can attack

        if(Vector3.Distance(transform.position,playerTarget.position)   >   attack_distance + chase_player_after_attack_distance)
        {
            navAgent.isStopped = false;
            enemy_State = EnemyState.CHASE;
        }
    }


    void Activate_Attackpoint()
    {
        AttackPoint.SetActive(true);
    }

    void Deactivate_Attackpoint()
    {
        if (AttackPoint.activeInHierarchy)
        {
            AttackPoint.SetActive(false);
        }
    }

}//class
