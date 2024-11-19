using System;
using UnityEngine;

public class RenderHandler
{
    protected MeshFilter meshFilter;
    protected Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        mesh.vertices = GenerateCubeVertices();
        mesh.triangles = CalculateShownSides();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // meshFilter = gameObject.AddComponent<MeshFilter>();
        // meshFilter.mesh = mesh;
    }

    private Vector3[] GenerateCubeVertices()
    {
        return new Vector3[] 
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1)
        };
    }

    private int[] CalculateShownSides()
    {
        return new int[] 
        {
            0, 4, 1, 1, 4, 5, // Down
            6, 2, 3, 6, 3, 7, // Up
            1, 5, 3, 3, 5, 7, // Z+
            4, 0, 2, 4, 2, 6, // Z-
            2, 0, 1, 2, 1, 3, // X-
            5, 4, 6, 7, 5, 6 // X+
        };
    }
}
