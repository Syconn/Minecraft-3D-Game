using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private GameObject worldChunk;

    [SerializeField] private int chunkSize = 16;
    [SerializeField] private int worldHeight = 200;

    private static World world;
    

    void Start()
    {
        if (world == null) world = this;
    
        Instantiate(worldChunk, new Vector3(0, 0, 0), Quaternion.identity);
        
        // for (int x = 0; x < chunkSize; x++) {
        //     for (int z = 0; z < chunkSize; z++) {
        //         Instantiate(block, new Vector3(x, generateNoise(x, z, 8.0f), z), Quaternion.identity);
        //     }
        // }
    }

    void Update()
    {
        
    }

    private float generateNoise(int x, int z, float scale) {
        float xNoise = x / scale;
        float zNoise = z / scale;
        return Mathf.PerlinNoise(xNoise, zNoise); 
    }

    public static int getChunkSize() {
        return world.chunkSize;
    } 

    public static int getWorldHeight() {
        return world.worldHeight;
    } 
}
