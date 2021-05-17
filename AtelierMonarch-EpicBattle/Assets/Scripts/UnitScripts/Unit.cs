using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    /*
        This is a master class from which all Units inherit.
        All units have health, an amount of health they recover during rest,
        an amount of damage they deal, and when defending, how much damage is prevented.
    */

    public int healthPoints;
    public int maxHealth;
    public int healthRecoveryRate;
    public int attackDamage;
    public int defenseAmount;
    public bool isDefending = false;
    public bool hasHealedAtRest = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //All classes heal on the rest screen. This will be called during the rest phase for each player unit.
    public void HealAtRest(){
        bool hashealthOverflowed = (healthPoints + healthRecoveryRate) >= maxHealth;
        if(hashealthOverflowed){
            healthPoints = maxHealth;
        }
        else{
            healthPoints += healthRecoveryRate;
        }
        hasHealedAtRest = true;
    }

    public void ResetHealedAtRestStatus(){
        hasHealedAtRest = false;
    }

    //Provide attack damage to be used against another unit.
    public int Attack(){
        return attackDamage;
    }

   public void Defend(){
        isDefending = true;
    }

    public void ResetDefendStatus(){
        isDefending = false;
    }
    
}
