using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public MeshFilter meshFilter;

    int VertexIndex = 0;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();
    List<Vector2> uvs = new List<Vector2>();

    bool[,,] voxelMap = new bool[VoxelData.ChunkWidth, VoxelData.ChunkHeight, VoxelData.ChunkWidth];
    void Start() {

        PopulateVoxelMap();
        CreateMeshData();
        createMesh();

    }

    void PopulateVoxelMap() { 
        for (int y = 0; y < VoxelData.ChunkHeight; y++) {
            for (int x = 0; x < VoxelData.ChunkWidth; x++) {
                for (int z = 0; z < VoxelData.ChunkWidth; z++) {

                    voxelMap[x, y, z] = true;

                }
            }
        }

    }

    void CreateMeshData() {
        for (int y = 0; y < VoxelData.ChunkHeight; y++)
        {
            for (int x = 0; x < VoxelData.ChunkWidth; x++)
            {
                for (int z = 0; z < VoxelData.ChunkWidth; z++)
                {
                    AddVoxelDataToChunk(new Vector3(x, y, z));
                }
            }
        }
    }

    bool CheckVoxel(Vector3 pos) {

        int x = Mathf.FloorToInt(pos.x);
        int y = Mathf.FloorToInt(pos.y);
        int z = Mathf.FloorToInt(pos.z);

        if (x < 0 || x > VoxelData.ChunkWidth - 1 || y < 0 || y > VoxelData.ChunkHeight - 1 || z < 0 || z > VoxelData.ChunkWidth - 1) {
            return false;
        }

        return voxelMap[x, y, z]; 

    }

    void AddVoxelDataToChunk (Vector3 pos) {
        for (int p = 0; p < 6; p++) {

            if (!CheckVoxel(pos + VoxelData.faceChecks[p])) {

                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 0]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 1]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 2]]);
                vertices.Add(pos + VoxelData.voxelVerts[VoxelData.voxelTris[p, 3]]);
                uvs.Add(VoxelData.voxelUvs[0]);
                uvs.Add(VoxelData.voxelUvs[1]);
                uvs.Add(VoxelData.voxelUvs[2]);
                uvs.Add(VoxelData.voxelUvs[3]);
                triangles.Add(VertexIndex);
                triangles.Add(VertexIndex + 1);
                triangles.Add(VertexIndex + 2);
                triangles.Add(VertexIndex + 2);
                triangles.Add(VertexIndex + 1);
                triangles.Add(VertexIndex + 3);

                VertexIndex += 4;
            }
        }
    }

    void createMesh (){
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();

        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

}
