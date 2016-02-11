using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    public float startDelay = 0;
    public float blockSpawnInterval = 1;

	private void Start() {
        Invoke("BlockSpawnTick", startDelay);
	}

    // This method exists so that blockSpawnInterval can be changed during runtime and work properly
    private void BlockSpawnTick() {
        if (GameManager.instance.GetBlockCount() < 5) {
            SpawnEmptyBlock();
            Invoke("BlockSpawnTick", blockSpawnInterval);
        } else {
            Invoke("BlockSpawnTick", 0);
        }
    }

    private void SpawnEmptyBlock() {
        GameObject emptyBlock = (GameObject)Instantiate(Resources.Load("Prefabs/EmptyBlock"));
        emptyBlock.transform.position = new Vector3(0.8f, 5.5f);
        GameManager.instance.AddBlock(emptyBlock);
    }

}
