using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] private int chunkSize = 16;
    [SerializeField] private int worldHeight = 200;
    public Material grassBlock;
    public static World instance;

    private Chunk[,] loadedChunks;
    
    void Start()
    {
        if (instance == null) instance = this;
        loadedChunks = new Chunk[1, 1] { { generateChunk(new ChunkPos(0, 0)) } };
    }

    private Chunk generateChunk(ChunkPos chunkPos) 
    {
        GameObject chunkObject = new GameObject("Chunk(" + chunkPos.chunkX + ", " + chunkPos.chunkZ + ")", typeof(MeshRenderer), typeof(ChunkRenderer), typeof(ChunkHandler));
        chunkObject.GetComponent<ChunkRenderer>().SetChunkPos(chunkPos);
        return new Chunk(chunkPos, chunkObject);
    }

    public int[,,] GenOrCacheChunk(ChunkPos chunkPos) 
    {
        int[,,] blocks = new int[chunkSize, worldHeight, chunkSize];
        for (int x = 0; x < chunkSize; x++) {
            for (int z = 0; z < chunkSize; z++) {
                blocks[x, 0, z] = BlockTypes.GRASS_BLOCK.type;
            }
        }
        return blocks;
    }

    public static int GetChunkSize() 
    {
        return instance.chunkSize;
    } 

    public static int GetWorldHeight() 
    {
        return instance.worldHeight;
    }

    public static Chunk GetChunk(ChunkPos chunkPos) 
    {
        return instance.loadedChunks[chunkPos.chunkX, chunkPos.chunkZ];
    }

    public static int GetBlock(BlockPos pos) 
    {
        int x = pos.x % World.GetChunkSize();
        int z = pos.z % World.GetChunkSize();
        return GetChunk(new ChunkPos(pos.x / GetChunkSize(), pos.x / GetChunkSize())).GetBlock(pos);
    }

    public static void SetBlock(BlockPos pos, BlockType block) 
    {
        int x = pos.x % World.GetChunkSize();
        int z = pos.z % World.GetChunkSize();
        GetChunk(new ChunkPos(pos.x / GetChunkSize(), pos.x / GetChunkSize())).SetBlock(pos, block);
    }

    private float generateNoise(int x, int z, float scale) {
        float xNoise = x / scale;
        float zNoise = z / scale;
        return Mathf.PerlinNoise(xNoise, zNoise); 
    }
}

public class ChunkPos 
{
    public int chunkX { get; }
    public int chunkZ { get; }

    public ChunkPos(int chunkX, int chunkZ) {
        this.chunkX = chunkX;
        this.chunkZ = chunkZ;
    }

    public BlockPos WorldPos(BlockPos blockPos) 
    {
        return new BlockPos(chunkX * World.GetChunkSize() + blockPos.x, blockPos.y, chunkZ * World.GetChunkSize() + blockPos.z);
    }
}

public class BlockPos
{
    public int x { get; }
    public int y { get; }
    public int z { get; }

    public BlockPos(int x, int y, int z) 
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 GetVector3() {
        return new Vector3(x, y, z);
    }

    public BlockPos WorldPos(ChunkPos chunkPos) 
    {
        return new BlockPos(chunkPos.chunkX * World.GetChunkSize() + x, y, chunkPos.chunkZ * World.GetChunkSize() + z);
    }

    public BlockPos translate(int x, int y, int z) 
    {
        return new BlockPos(this.x + x, this.y + y, this.z + z);
    }

    public BlockPos offset(Direction direction) 
    {
        int xO = direction == Direction.North ? 1 : direction == Direction.South ? -1 : 0;
        int yO = direction == Direction.East ? 1 : direction == Direction.West ? -1 : 0;
        int zO = direction == Direction.Up ? 1 : direction == Direction.Down ? -1 : 0;
        return new BlockPos(x + xO, y + yO, z + zO);
    }
}

public enum Direction 
{
    North, // X+
    South, // X-
    East, // Z+
    West, // Z-
    Up,
    Down
}