using System;
using UnityEngine;

public class BlockTypes {
    public static readonly BlockType AIR = new BlockType(0, "air", true);
    public static readonly BlockType GRASS_BLOCK = new BlockType(1, "grass_block", false);
}

public class BlockType {
    public int type { get; }
    public string name { get; }
    public bool transparent { get; }
    public bool customRender { get; }
    
    public Model model { get; set; }

    public BlockType(int type, string name, bool transparent) {
        this.type = type;
        this.name = name;
        this.transparent = transparent;
        this.customRender = false;
    }

    public BlockType(int type, string name, bool transparent, Model model) {
        this.type = type;
        this.name = name;
        this.transparent = transparent;
        this.customRender = true;
        this.model = model;
    }
}

public class Model {
    public Vector3[] vertices { get; set; }
    public int[] triangles { get; set; }

    public Model(Vector3[] vertices, int[] triangles) {
        this.vertices = vertices;
        this.triangles = triangles;
    }
}