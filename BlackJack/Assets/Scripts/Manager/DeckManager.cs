using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("덱 위치")]
    [SerializeField] private Transform deckPos;

    [Header("카드 간격")]
    [SerializeField] private float stackOffset = 0.01f;

    private List<Transform> cards = new();

    private void Awake()
    {
        cards.Clear();

        foreach (Transform card in transform)
        {
            cards.Add(card);
        }

        Shuffle();
    }

    /// <summary>
    /// 카드 섞기
    /// </summary>
    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            Transform temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        UpdateCardPositions();
    }

    /// <summary>
    /// 덱 위치 갱신
    /// </summary>
    private void UpdateCardPositions()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].position =
                deckPos.position + Vector3.up * (stackOffset * i);

            cards[i].rotation = deckPos.rotation;

            cards[i].SetSiblingIndex(i);
        }
    }

    /// <summary>
    /// 맨 위 카드 뽑기
    /// </summary>
    public Transform DrawCard()
    {
        if (cards.Count == 0)
        {
            Debug.Log("덱이 비었습니다.");
            return null;
        }

        Transform card = cards[cards.Count - 1];

        cards.RemoveAt(cards.Count - 1);

        UpdateCardPositions();

        return card;
    }
}