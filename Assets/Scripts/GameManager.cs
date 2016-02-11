using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public float startDelay = 0;
    public float blockSpawnInterval = 1;

    private List<GameObject> blocks;
    private BlockSpawner blockSpawner;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        blocks = new List<GameObject>();
        blockSpawner = GetComponent<BlockSpawner>();
    }

    public void AddBlock(GameObject block) {
        blocks.Add(block);
    }

    public void RemoveBlock(GameObject block) {
        Debug.Log("Remove");
        blocks.Remove(block);
    }

    public int GetBlockCount() {
        return blocks.Count;
    }

}
