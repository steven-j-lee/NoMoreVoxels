using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFactory<Enemy> : MonoBehaviour where Enemy : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    public MonoBehaviour Spawn()
    {
        return Instantiate(enemy);
    }

    public void recall()
    {
        Destroy(enemy.gameObject);
    }


}
