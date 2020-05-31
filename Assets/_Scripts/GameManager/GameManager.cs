using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;

    void Start()
    {
        Vector3 playerPosition = new Vector3(GridManager.Instance.CubeSize / 2f, 0f, GridManager.Instance.CubeSize / 2f);
        Instantiate(player, playerPosition, Quaternion.identity);
    }
}
