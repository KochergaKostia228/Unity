using System;
using Unity.VisualScripting;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public enum GiftType { Medkit, Ammunition }

    [SerializeField] public GiftType giftType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Убедитесь, что у игрока есть тег "Player"
        {
            // Реализуем логику для каждого типа подарка
            switch (giftType)
            {
                case GiftType.Medkit:
                    // Например, добавить здоровье
                    Debug.Log("Player picked up a Medkit!");
                    break;
                case GiftType.Ammunition:
                    // Например, добавить патроны
                    Debug.Log("Player picked up Ammunition!");
                    break;
            }

            // Уничтожаем подарок после того, как его забрали
            Destroy(gameObject);
        }
    }
}