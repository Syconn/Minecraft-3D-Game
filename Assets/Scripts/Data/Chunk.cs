using UnityEngine;

public class Chunk 
{
    public ChunkPos chunkPos { get; }
    private GameObject chunkObj;
    private int[,,] blocks;

    public Chunk(ChunkPos chunkPos, GameObject chunkObj) {
        this.chunkPos = chunkPos;
        this.chunkObj = chunkObj;
        this.blocks = World.instance.GenOrCacheChunk(chunkPos);
    }

    public int GetBlock(BlockPos pos) {
        int x = pos.x % World.GetChunkSize();
        int z = pos.z % World.GetChunkSize();
        return blocks[x, pos.y, z];
    }

    public void SetBlock(BlockPos pos, BlockType block) {
        int x = pos.x % World.GetChunkSize();
        int z = pos.z % World.GetChunkSize();
        blocks[x, pos.y, z] = block.type;
    }
}