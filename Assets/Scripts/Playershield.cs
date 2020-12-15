using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playershield : MonoBehaviour
{

    private Health health;
    
    // Start is called before the first frame update
    void Awake()
    {
        health = GetComponent<Health>();
    }

    public void ActivateShield(bool shield_active)
    {
        health.shieldActivated = shield_active;
    }


}//class
