using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralPerlin : MonoBehaviour
{
    public static ProceduralPerlin instance;
    private Texture2D texture;

    //global variables for our spawner
    public int perlinTextureX;
    public int perlinTextureY;
    public int stepSize;
    public bool offset;
    public Vector2 noiseOffset;
    public float scale = 10f;

    //visual values
    public bool isInstanciated = false;
    public GameObject visualizationCube;
    public float visualizationHeightScale = 5f;
    public RawImage visualizationUI;


    void Awake()
    {
        //use instance as a singleton
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Generate()
    {
        Noise();
        if (isInstanciated)
        {

        }
    }

    private void Noise()
    {
        if (offset)
        {
            //create offset if we randomize
            noiseOffset = new Vector2(Random.Range(0, 10000), Random.Range(0, 10000));
        }
        texture = new Texture2D(perlinTextureX, perlinTextureY);
        Color color = new Color(50f,50f,50f);
        //set pixel for each coords on the grid
        for(int i = 0; i < perlinTextureX; i++)
        {
            for (int j = 0; j < perlinTextureY; j++){
                texture.SetPixel(i, j, color);
            }
        }
        //apply texture
        texture.Apply();
        visualizationUI.texture = texture;
    }

    //get sample step
    public float SampleStep(int i, int j)
    {
        int gridX = perlinTextureX / stepSize;
        int gridY = perlinTextureY / stepSize;
        float sample = texture.GetPixel
                   ((Mathf.FloorToInt(i * stepSize)), (Mathf.FloorToInt(j * stepSize))).grayscale;

        //return sampled float 
        return sample;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
