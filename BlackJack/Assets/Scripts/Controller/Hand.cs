using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] private float cardSpacing = 0.5f;
    [SerializeField] private float moveDuration = 0.4f;

    private List<Transform> cards = new();

    public void AddCard(Transform card)
    {
        cards.Add(card);

        int index = cards.Count - 1;

        Vector3 targetPos =
            transform.position +
            transform.right * (cardSpacing * index);

        card.DOMove(targetPos, moveDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                card.SetParent(transform);
            });

        card.DORotateQuaternion(
            transform.rotation,
            moveDuration);
    }
}