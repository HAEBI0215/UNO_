using System.Collections;
using UnityEngine;

public class BlackjackManager : MonoBehaviour
{
    [SerializeField] private DeckManager deckManager;

    [Header("손")]
    [SerializeField] private Hand playerHand;
    [SerializeField] private Hand dealerHand;

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return DealPlayer();
        yield return DealDealer();
        yield return DealPlayer();
        yield return DealDealer();
    }

    public IEnumerator DealPlayer()
    {
        Transform card = deckManager.DrawCard();

        if (card != null)
            playerHand.AddCard(card);

        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator DealDealer()
    {
        Transform card = deckManager.DrawCard();

        if (card != null)
            dealerHand.AddCard(card);

        yield return new WaitForSeconds(0.5f);
    }
}