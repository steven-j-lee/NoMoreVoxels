using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinGenerator : MonoBehaviour
{
    //global variables
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;
    public float offsetx = 50f;
    public float offsety = 50f;



    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateNoise(terrain.terrainData);
    }

    TerrainData GenerateNoise(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0,0,GenerateHeights());
        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                //proper conversipon
                float x = (float) i / width * scale + offsetx;
                float y = (float) j / height * scale + offsety;
                //generate perlinNoise
                heights[i, j] = Mathf.PerlinNoise(x, y);
            }
        }
        return heights;
    }

}
