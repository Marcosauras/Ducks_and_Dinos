using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VoxelData {

    public static readonly int ChunkWidth = 8;
    public static readonly int ChunkHeight = 16;

    public static readonly int TextureAtlasSizeInBlocks = 4;
    public static float NormalizedBlockTextureSize {

        get { return 1f / (float)TextureAtlasSizeInBlocks; }
    }

    public static readonly Vector3[] voxelVerts = new Vector3[]
    {
        new Vector3(0.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f),
    };

    public static readonly Vector3[] faceChecks = new Vector3[6] {

        new Vector3(0.0f, 0.0f, -1.0f), // checks: back Face
        new Vector3(0.0f, 0.0f, 1.0f),  // front Face
        new Vector3(0.0f, 1.0f, 0.0f),  // top Face
        new Vector3(0.0f, -1.0f, 0.0f), // bottom Face
        new Vector3(-1.0f, 0.0f, 0.0f), // left Face
        new Vector3(1.0f, 0.0f, 0.0f)   // right Face

    };

    public static readonly int[,] voxelTris = new int[6, 4] {

        {0, 3, 1, 2}, //back face
        {5, 6, 4, 7},  // Front Face
        {3, 7, 2, 6},  // Top Face
        {1, 5, 0, 4}, // Bottom Face
        {4, 7, 0, 3}, // Left Face
        {1, 2, 5, 6}  // Right Face

    };

    public static readonly Vector2[] voxelUvs = new Vector2[4] {

        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),

    };



}
