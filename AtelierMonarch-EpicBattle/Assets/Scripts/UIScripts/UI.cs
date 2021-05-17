using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public Button NextRoundButton;
    public Button AttackButton;
    public Button DefendButton;
    public Button SwapButton;
    public Text PhaseText;
    public CombatTracker tracker;

    public GameObject playerWins;
    public GameObject foeWins;
    // Start is called before the first frame update
    void Start()
    {
        NextRoundButton.onClick.AddListener(tracker.GoToCombatPhase);
        SwapButton.onClick.AddListener(tracker.SwapHeroes);
        AttackButton.onClick.AddListener(()=> tracker.Combat(CombatTracker.Actions.ATTACK));
        DefendButton.onClick.AddListener(()=> tracker.Combat((CombatTracker.Actions.DEFEND)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableNextRoundButton(){
        NextRoundButton.gameObject.SetActive(false);
    }

    public void DisableAttackButton(){
        AttackButton.gameObject.SetActive(false);
    }

    public void DisableDefendButton(){
        DefendButton.gameObject.SetActive(false);
    }

    public void DisableSwapButton(){
        SwapButton.gameObject.SetActive(false);
    }

    public void EnableNextRoundButton(){
        NextRoundButton.gameObject.SetActive(true);
    }

    public void EnableAttackButton(){
        AttackButton.gameObject.SetActive(true);
    }

    public void EnableDefendButton(){
        DefendButton.gameObject.SetActive(true);
    }

    public void EnableSwapButton(){
        SwapButton.gameObject.SetActive(true);
    }

    public void UpdatePhaseText(string phaseText){
        PhaseText.text = phaseText;
    }

    public void ShowPlayerWon(){
        playerWins.gameObject.SetActive(true);
    }

    public void ShowFoeWon(){
        foeWins.gameObject.SetActive(true);
    }
}
