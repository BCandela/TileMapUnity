using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]

public class TileMap : MonoBehaviour
{
    int size_x = 100;
    int size_z = 50;
    float tileSize = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        BuildMesh();
    }

    private void BuildMesh()
    {
        int numTiles = size_x * size_z;
        int numTris = numTiles * 2;

        int vsize_x = size_x + 1;
        int vsize_z = size_z + 1;
        int numVerts = vsize_x * vsize_z;



        // Generate the mesh data
        // 4 vertices because we wat a square
        Vector3[] vertices = new Vector3[numVerts];
        // We want to divide the square in 2 triangles, with each having 3 vertices
        Vector3[] normals = new Vector3[numVerts];
        Vector2[] uv = new Vector2[numVerts];

        int[] triangles = new int[numTris * 3];
        for (int z = 0; z < vsize_z; z++){
            for (int x = 0; x < vsize_x; x++){
                vertices[z * vsize_x + x] = new Vector3(x*tileSize, 0, z*tileSize);
                normals[z * vsize_x + x] = Vector3.up;

                // x=0, uv.x = 0
                // x=101, uv.x = 1
                // uv.x = (float)x / vsize_x
                uv[z * vsize_x + x] = new Vector2((float)x / vsize_x, (float)z / vsize_z);
            }
        }

        for (int z = 0; z < size_z; z++){
            for (int x = 0; x < size_x; x++){
                int squareIndex = z * size_x + x;
                int triIndex = squareIndex * 6;
                triangles[triIndex + 0] = z * vsize_x + x + 0;
                triangles[triIndex + 1] = z * vsize_x + x + vsize_x + 0;
                triangles[triIndex + 2] = z * vsize_x + x + vsize_x + 1;

                triangles[triIndex + 3] = z * vsize_x + x + 0;
                triangles[triIndex + 4] = z * vsize_x + x + vsize_x + 1;
                triangles[triIndex + 5] = z * vsize_x + x + 1;
            }
        }

        // Create a New Mesh and populate the data
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uv;

        // Assign the mesh to our/filter/render/collider
        MeshFilter mesh_filter = GetComponent<MeshFilter>();
        MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
        MeshCollider mesh_collider = GetComponent<MeshCollider>();

        mesh_filter.mesh = mesh;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}