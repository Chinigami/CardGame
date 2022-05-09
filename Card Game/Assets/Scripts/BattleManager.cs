using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public Enemy enemy;
    private List<Effect> enemyActions = new List<Effect>();
    private Effect enemyNextAtk;

    public Player player;
    
    public int mana;
    public Text manaText;
    public Color manaColorIsPlayable;
    public Color manaColorNotPlayable;

    public static BattleManager instance;

    public List<Card> deck = new List<Card>();
    public List<Card> discard = new List<Card>();
    public List<Card> hand = new List<Card>();
    public GameObject handLer;
    public int begginningHand = 4;

    public GameObject cantPlayText;
    public int idCard = 0;

    public Text deck_text;
    public Text discard_text;

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    
    void Start(){
        CardRemainingCheck();
        
        ManaUpdate();

        enemy.healthBar.SetMaxHealth(enemy.baseHealth);
        EnemyPrep();
        
        SetMana(player.mana);
        player.healthBar.SetMaxHealth(player.baseHealth);
    }

    #region Hand
    public void CardRemainingCheck(){
        deck_text.text = deck.Count.ToString();
        discard_text.text = discard.Count.ToString();
    }

    public void DrawCard(){
        if(deck.Count >= 1){
            Card randCard = deck[Random.Range(0, deck.Count)];
            if(randCard.id == -1){
                randCard.id = idCard;
                idCard++;
            }
            hand.Add(randCard);
            Card c = Instantiate(randCard, handLer.transform);
            UpdateColorPlayable(c);
            deck.Remove(randCard);
            CardRemainingCheck();
        } else if(deck.Count == 0){
            Shuffle();
            DrawCard();
        }
    }

    public void DrawHand(){
        for(int i = 0; i < begginningHand; i++){
            DrawCard();
        }
    }

    public void DiscardCard(Card c){
        Draggable d = c.gameObject.GetComponent<Draggable>();
        if(d != null) {
            Destroy(d);
        }
        Animator anim = c.gameObject.GetComponent<Animator>();
        anim.SetTrigger("isDiscarded");
        Card cardInHand = hand.Find(item => item.id == c.id);
        discard.Add(cardInHand);
        hand.Remove(cardInHand);
        Destroy(c.gameObject, 1);
        CardRemainingCheck();
    }

    public void DiscardHand(){
        int nbCardInHand = hand.Count;
        for(int i = nbCardInHand-1; i > -1; i--){
            Card c = handLer.transform.GetChild(i).GetComponent<Card>();
            DiscardCard(c);
        }
    }

    public void Shuffle(){
        foreach(Card c in discard){
            deck.Add(c);
        }
        discard.Clear();
        CardRemainingCheck();
    }

    public void CantPlayCardAnim(){
        cantPlayText.SetActive(false);
        cantPlayText.SetActive(true);
    }
    #endregion

    #region Mana
    public void SetMana(int amount){
        mana = amount;
        ManaUpdate();
    }
    public void AddMana(int amount){
        mana += amount;
        ManaUpdate();
    }

    public void ManaUpdate(){
        manaText.text = mana.ToString();
        for(int i = 0; i < handLer.transform.childCount; i++){
            Card c = handLer.transform.GetChild(i).GetComponent<Card>();
            UpdateColorPlayable(c);
        }
    }

    public void UpdateColorPlayable(Card c){
        if(c.cardCost > mana){
            c.costText.color = manaColorNotPlayable;
        } else {
            c.costText.color = manaColorIsPlayable;
        }
    }
    #endregion

    #region Enemy
    public void EnemyPrep(){
        if(enemyActions.Count == 0){
            foreach(Effect e_a in enemy.actions){
                enemyActions.Add(e_a);
            }
        }
        Effect e = enemyActions[Random.Range(0, enemyActions.Count)];
        enemyNextAtk = e;
        if(e.icons.Count != 0){
            enemy.SetIcon(e.icons, e.values);
        } else {
            Debug.Log("Pas d'icon");
        }
        
        enemyActions.Remove(e);
    }

    public void EnemyAtk(){
        enemyNextAtk.Activation();
        EnemyPrep();
    }
    #endregion
}
