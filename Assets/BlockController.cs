using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

    public int speed;

	void Start () {
	
	}
	
	void FixedUpdate () {
        Vector3 unit = new Vector3(0, -1, 0);
        transform.position += unit * speed * Time.deltaTime;
	}
}
