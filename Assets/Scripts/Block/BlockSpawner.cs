using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

    public float startDelay = 0;
    public float spawnInterval = 1;

	private void Start() {
        Invoke("SpawnBlockInterval", startDelay);
	}

    // This method exists so that spawnInterval can be changed during runtime and work properly
    private void SpawnBlockInterval() {
        SpawnEmptyBlock();
        Invoke("SpawnBlockInterval", spawnInterval);
    }

    private void SpawnEmptyBlock() {
        GameObject emptyBlock = (GameObject)Instantiate(Resources.Load("Prefabs/EmptyBlock"));
        emptyBlock.transform.position = new Vector3(0.8f, 5.5f);
    }

}
