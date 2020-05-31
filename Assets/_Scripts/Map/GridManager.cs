using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class GridManager : Singleton<GridManager>
{
    public GameObject referenceCube;
    public int rows = 5;
    public int cols = 8;

    public float CubeSize
    {
        get
        {
            return referenceCube.GetComponentInChildren<BoxCollider>().transform.lossyScale.x;
        }
    }

    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        FixRowsAndCols();

        float gridX = cols * CubeSize;
        float gridZ = rows * CubeSize;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                float posX = col * CubeSize - gridX / 2;
                float posZ = row * CubeSize - gridZ / 2;

                if (cols % 2 != 0)
                    posX += CubeSize / 2;
                if (rows % 2 != 0)
                    posZ += CubeSize / 2;

                Vector3 cubePosition = new Vector3(posX, -1, posZ);

                GameObject cube = Instantiate(referenceCube, cubePosition, Quaternion.identity, transform);
            }
        }
    }

    private void FixRowsAndCols()
    {
        if (rows < 1)
            rows = 1;
        if (cols < 1)
            cols = 1;
    }
}
