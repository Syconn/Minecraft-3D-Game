using UnityEngine;

public class ChunkRenderer : MonoBehaviour
{
    public ChunkPos chunkPos;
    private Chunk chunk;
    private bool dirty;

    void Start() {
        chunk ??= World.GetChunk(chunkPos);
        dirty = true;
    }

    void Update() {
        if (dirty) {
            dirty = false;

            RenderHandler.RenderBlock(this);
        }
    }

    public void MarkDirty() {
        dirty = true;
    }

    public void SetChunkPos(ChunkPos chunkPos) {
        this.chunkPos = chunkPos;
    }
}
