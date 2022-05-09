using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn { START, PLAYERTURN, ENEMYTURN, ENDBATTLE };
public class TurnSystem : MonoBehaviour
{
    public Turn phase;
    public float timeBetweenTurn = 2;
    void Start()
    {
        phase = Turn.START;

        // Il se passent des trucs

        BattleManager.instance.DrawHand();

        PlayerTurn();
    }

    private void PlayerTurn(){
        phase = Turn.PLAYERTURN;

        BattleManager.instance.SetMana(BattleManager.instance.player.mana);
        BattleManager.instance.player.healthBar.BreakShield();
    }

    public void EndPlayerTurn(){
        StartCoroutine(BetweenTurns());
    }

    IEnumerator BetweenTurns(){

        BattleManager.instance.DiscardHand();

        yield return new WaitForSeconds(timeBetweenTurn);

        EnemyTurn();
    }

    private void EnemyTurn(){
        phase = Turn.ENEMYTURN;

        BattleManager.instance.EnemyAtk();

        PlayerTurn();
        BattleManager.instance.DrawHand();
    }

    public void EndBattle(bool win){
        if(win){
            Debug.Log("You Won !");
        } else {
            Debug.Log("You lose !");
        }
    }
    
}
