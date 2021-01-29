using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proceduralIslands : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < gameManager.count; i++)
        {
            //instantiate an instance of the mesh
            var instance = Instantiate(gameManager.island) as GameObject;
            instance.transform.position = randomPosition();
            instance.transform.rotation = Random.rotation;
        }
    }

    private Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-1000f, 1000f), Random.Range(-500f, 500f), Random.Range(-1000f, 1000f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
