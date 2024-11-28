using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RenderHandler
{    
    // public static void RenderChunk(ChunkRenderer chunkRenderer, Chunk chunk) 
    // {
    //     var vertices = new List<Vector3>();
    //     var uvs = new List<Vector2>();
    //     var tris = new List<int>();

    //     // int b = 0;
    //     // for (int x = 0; x < World.GetChunkSize(); x++) {
    //     //     for (int z = 0; z < World.GetChunkSize(); z++) {
    //     //         BlockPos pos = new BlockPos(x, 0, z);
    //     //         vertices.AddRange(GenerateCubeVertices(pos));
    //     //         tris.AddRange(CalculateShownSides(b));
    //     //         b += 8;
    //     //     }
    //     // }

    //     vertices.AddRange(GenerateCubeVertices(new BlockPos(0, 0, 0)));
    //     tris.AddRange(CalculateShownSides(0));
    //     uvs.AddRange(GenerateCubeUVs(vertices));
    //     createMesh(chunkRenderer.gameObject, vertices.ToArray(), tris.ToArray(), uvs.ToArray(), World.instance.grassBlock);
    // }

    public static void RenderBlock(ChunkRenderer chunkRenderer, Vector3 offset) 
    {
        Mesh mesh = new Mesh();
        mesh.vertices = new Vector3[] 
        {
            new Vector3(0, 0, 0) + offset, new Vector3(0, 1, 0) + offset, new Vector3(1, 1, 0) + offset, new Vector3(1, 0, 0) + offset, // Z-
            new Vector3(0, 0, 1) + offset, new Vector3(0, 1, 1) + offset, new Vector3(1, 1, 1) + offset, new Vector3(1, 0, 1) + offset, // Z+
            new Vector3(0, 0, 1) + offset, new Vector3(0, 0, 0) + offset, new Vector3(1, 0, 1) + offset, new Vector3(1, 0, 0) + offset, // Y-
            new Vector3(0, 1, 1) + offset, new Vector3(0, 1, 0) + offset, new Vector3(1, 1, 1) + offset, new Vector3(1, 1, 0) + offset, // Y+
            new Vector3(0, 0, 0) + offset, new Vector3(0, 1, 0) + offset, new Vector3(0, 1, 1) + offset, new Vector3(0, 0, 1) + offset, // X-
            new Vector3(1, 0, 0) + offset, new Vector3(1, 1, 0) + offset, new Vector3(1, 1, 1) + offset, new Vector3(1, 0, 1) + offset, // X+
        };
        mesh.triangles = new int[] 
        {
            0, 1, 2, 0, 2, 3,
            5, 4, 6, 6, 4, 7,
            8, 9, 10, 11, 10, 9,
            14, 13, 12, 13, 14, 15,
            16, 19, 18, 16, 18, 17,
            22, 23, 20, 21, 22, 20,
        };
        mesh.uv = new Vector2[] 
        {
            new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f),
            new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f),
            new Vector2(0f, 0.5f), new Vector2(0f, 0f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f),
            new Vector2(0f, 0.5f), new Vector2(0f, 0f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f),
            new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f),
            new Vector2(0f, 0f), new Vector2(0f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0f)
        };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();
        chunkRenderer.AddComponent<MeshFilter>().mesh = mesh;
        chunkRenderer.GetComponent<MeshRenderer>().material = World.instance.grassBlock;
    }
}
