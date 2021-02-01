using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int enemyOnScreenNum;
    private int counter;
    [SerializeField] private EnemyFactory boxFactory;

    private void Awake()
    {
        counter = 0;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        while(enemyOnScreenNum > counter)
        {
            var instance = boxFactory.Spawn();
            Vector3 randomPosition = new Vector3(Random.Range(-300f, 300f), Random.Range(-200f,200f), Random.Range(-500f, 500f));
            instance.transform.position = randomPosition;

            counter++;
        }
        
    }
}
