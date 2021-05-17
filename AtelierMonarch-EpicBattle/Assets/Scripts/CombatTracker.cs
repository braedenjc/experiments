using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTracker : MonoBehaviour
{
    // enumerate our phases for easy tracking
    public enum Phases{
        COMBAT,
        REST,
        GAMEOVER
    }

    public enum Actions{
        ATTACK,
        DEFEND
    }

    //Setup proper MVC behavior. 
    public UI ui;
    public Phases currentPhase = Phases.COMBAT;
    public Actions enemyAction;
    public Actions playerAction;
    
    public Unit[] unitsPallet; //This is a hard code list of units. For the VS, we just will create a standard player then monster set.
    public Unit[] unitTurnOrder = new Unit[2];
    public Unit activeHero;
    public Unit backupHero;
    public Unit activeEnemy;
    public Unit backupEnemy;

    
    void Start()
    {
        //instantiate the heroes and enemies

        activeHero = Instantiate(unitsPallet[0]);
        backupHero = Instantiate(unitsPallet[1]);

        //Demonstrate enemy behavior;
        activeEnemy = Instantiate(unitsPallet[2]);
        backupEnemy = Instantiate(unitsPallet[3]);

        unitTurnOrder[0] = activeHero;
        unitTurnOrder[1] = activeEnemy;

        backupHero.gameObject.SetActive(false);
        backupEnemy.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(currentPhase == Phases.COMBAT){
            ui.UpdatePhaseText("COMBAT PHASE!");
            ui.EnableAttackButton();
            ui.EnableDefendButton();
            ui.DisableSwapButton();
            ui.DisableNextRoundButton();
        }
        
        if(currentPhase == Phases.REST){
            ui.DisableAttackButton();
            ui.DisableDefendButton();
            ui.EnableSwapButton();
            ui.EnableNextRoundButton();
            Debug.Log("Time to Heal Up!");
            ui.UpdatePhaseText("REST PHASE!");
            RestPhaseActions();
        }

        if(currentPhase == Phases.GAMEOVER){
            ui.DisableAttackButton();
            ui.DisableDefendButton();
            ui.DisableNextRoundButton();
            ui.DisableSwapButton();
            ui.UpdatePhaseText("GAME OVER");
        }

    }

    //During the Rest Phase, heal up.
    void RestPhaseActions(){
        if(!activeHero.hasHealedAtRest){
            activeHero.HealAtRest();
        }

        if(!backupHero.hasHealedAtRest){
            backupHero.HealAtRest();
        }
    }

    public void Combat(Actions action){

        playerAction = action;
        if(activeEnemy.name.Contains("Attacker")){
            enemyAction = Actions.ATTACK;
        }
        else{
            enemyAction = Actions.DEFEND;
        }

        if(playerAction == Actions.ATTACK){
            if(enemyAction == Actions.DEFEND){
                activeEnemy.healthPoints -= (activeHero.Attack() - activeEnemy.defenseAmount);
            }
            else{
                activeEnemy.healthPoints -= activeHero.Attack();
            }
        }

        else if(playerAction == Actions.DEFEND && enemyAction == Actions.ATTACK){
            activeHero.healthPoints -= (activeEnemy.Attack() - activeHero.defenseAmount);
        }

        else{

        }

        if(activeEnemy.healthPoints <= 0){
            if(backupEnemy.healthPoints <= 0){
                GoToGameOver();
                ui.ShowPlayerWon();
                return;
            }
            
            else{
                activeEnemy.gameObject.SetActive(false);
                Unit active = activeEnemy;
                Unit backup = backupEnemy;
                activeEnemy = backup;
                backupEnemy = active;
                backup.gameObject.SetActive(true);
            }
        }

        if(activeHero.healthPoints <= 0 && backupHero.healthPoints <= 0){ //Technically makes phyrric deaths possible.
            GoToGameOver();
            ui.ShowFoeWon();
        }
        
        GoToRestPhase();
    }

    public void SwapHeroes(){
        Unit active = activeHero;
        Unit backup = backupHero;
        active.gameObject.SetActive(false);
        backup.gameObject.SetActive(true);
        backupHero = active;
        activeHero = backup;
    }

    public void GoToCombatPhase(){
        currentPhase = Phases.COMBAT;
    }

    public void GoToRestPhase(){
        currentPhase = Phases.REST;
    }

    public void GoToGameOver(){
        currentPhase = Phases.GAMEOVER;
    }
}
