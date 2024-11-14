using System;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    protected MeshFilter meshFilter;
    protected Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTris();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    private Vector3[] GenerateVertices()
    {
        return new Vector3[] 
        {
            // // Bottom
            // new Vector3(-1, 0, 1),
            // new Vector3(1, 0, 1),
            // new Vector3(1, 0, -1),
            // new Vector3(-1, 0, -1),

            // // Top
            // new Vector3(-1, 2, 1),
            // new Vector3(1, 2, 1),
            // new Vector3(1, 2, -1),
            // new Vector3(-1, 2, -1)

            // Front Face
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(0, 1, 0)
        };
    }

    private int[] GenerateTris()
    {
        return new int[] 
        {
            // // Bottom
            // 1, 0, 2,
            // 2, 0, 3,

            // // Top
            // 4, 5, 6,
            // 4, 6, 7

            // North Face
            0, 1, 2,
            // 2, 3, 0
        };
    }

    void Update()
    {
        
    }
}
