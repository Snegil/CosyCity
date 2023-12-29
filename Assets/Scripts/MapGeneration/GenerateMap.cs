using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateMap : MonoBehaviour
{
    MeshFilter meshFilter;

    [SerializeField]
    MapData mapData;

    [Space, SerializeField, Header("Size of each tile")]
    float tileSize;

    [Space, SerializeField, Header("Sea Level:")]
    int seaLevel;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
    }
    void OnEnable()
    {
        mapData.OnMapDataAdded += Generate3DMap;
    }
    private void OnDisable()
    {
        mapData.OnMapDataAdded -= Generate3DMap;
    }

    public void Generate3DMap(int[,] mapData, int xGridSize, int yGridSize)
    {
        Mesh mesh = new();

        List<Vector3> vertices = new();
        List<int> triangles = new();

        for (int x = 0; x < mapData.GetLength(0); x++)
        {
            for (int z = 0; z < mapData.GetLength(1); z++)
            {
                float height = 1;

                if (mapData[x, z] < 1)
                {
                    height = 0;
                }

                // TOP PLANE

                // TOP North-West Vertex
                Vector3 tNW = new(x - tileSize, height, z + tileSize);
                // TOP North-East Vertex
                Vector3 tNE = new(x + tileSize, height, z + tileSize);
                // TOP South-West Vertex
                Vector3 tSW = new(x - tileSize, height, z - tileSize);
                // TOP South-East Vertex
                Vector3 tSE = new(x + tileSize, height, z - tileSize);

                vertices.Add(tNW);
                vertices.Add(tNE);
                vertices.Add(tSW);
                vertices.Add(tSE);

                // Top plane

                triangles.Add(vertices.Count - 1);
                triangles.Add(vertices.Count - 2);
                triangles.Add(vertices.Count - 3);

                triangles.Add(vertices.Count - 2);
                triangles.Add(vertices.Count - 4);
                triangles.Add(vertices.Count - 3);
            }
        }
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        
        meshFilter.mesh = mesh;
    }
}
