using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private int lifeLevel = 100;

    public int ReactToHit(int damage)
    {
        lifeLevel -= damage;
        Debug.Log("Current Life Level: " + lifeLevel);  // Логирование состояния здоровья после попадания
        if (lifeLevel <= 0)
        {
            StartCoroutine(Die());
        }
        return lifeLevel;
    }

    public bool isAlive()
    {
        return lifeLevel > 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Die()
    {
        if (!isAlive())
        {
            this.transform.Rotate(-90.0F,0,0);
            this.transform.Translate(0, 0, -1.4F);
        }
        yield return new WaitForSeconds(1.5F);
        Destroy(gameObject);
    }
}
