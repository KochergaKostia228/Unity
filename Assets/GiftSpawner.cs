using UnityEngine;

public class GiftSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] gifts; // Массив с префабами подарков (медицина, амуниция)
    
    public float spawnInterval = 20f; // Интервал между появлениями подарков

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        // Считаем время и если оно прошло, создаем новый подарок
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnGift();
            timer = spawnInterval; // Сбрасываем таймер
        }
    }

    void SpawnGift()
    {
        int random = Random.Range(0, 2);
        
        GameObject gift;
        
        if (random == 0)
        {
            gift = gifts[0];
        }
        else
        {
            gift = gifts[1];
        }
        
        // Случайное место для появления подарка
        Vector3 spawnPosition = new Vector3(Random.Range(-23.0F, 23.0F), 1.0F, Random.Range(-23.0F, 23.0F));

        // Создаем подарок
        Instantiate(gift, spawnPosition, Quaternion.identity);
    }
}