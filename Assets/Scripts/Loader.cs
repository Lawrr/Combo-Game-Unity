using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

    private void Awake() {
        if (GameManager.instance == null) {
            Instantiate(Resources.Load("Prefabs/GameManager"));
        }
    }

}
