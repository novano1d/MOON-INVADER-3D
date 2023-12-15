using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public int depth = 20;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3 (width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] = CalculateHeight(i, j);
            }
        }
        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xcoord = (float)x / width * scale + offsetX;
        float ycoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xcoord, ycoord);
    }
}
