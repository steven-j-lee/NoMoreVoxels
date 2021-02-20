using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int enemyOnScreenNum;
    private int counter;
    [SerializeField] private EnemyFactory boxFactory;

    public int enemyCounter
    {
        get { return counter; }
        set { counter = value; }
    }
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
            Vector3 randomPosition = new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f,1000f), Random.Range(-1000f, 1000f));
            instance.transform.position = randomPosition;

            counter++;
        }
        
    }
}
