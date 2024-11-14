using UnityEngine;

public class World : MonoBehaviour
{
    public static int chunkSize = 16; 

    [SerializeField]
    private GameObject block;
    private int noiseHeight;

    void Start()
    {
        for (int x = 0; x < chunkSize; x++) {
            for (int z = 0; z < chunkSize; z++) {
                Debug.Log(generateNoise(x, z, 8.0f));
                Instantiate(block, new Vector3(x, generateNoise(x, z, 8.0f), z), Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }

    private float generateNoise(int x, int z, float scale) {
        float xNoise = x / scale;
        float zNoise = z / scale;
        return Mathf.PerlinNoise(xNoise, zNoise); 
    }
}
