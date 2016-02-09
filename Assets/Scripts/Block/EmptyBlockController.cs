using UnityEngine;
using System.Collections;

public class EmptyBlockController : MonoBehaviour {

    public int speed;

    private SpriteRenderer spriteRenderer;
    private Vector3 startPos;

	private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
	}

    private void Update() {
        Debug.Log(transform.position.y);
        if (transform.position.y < -5.5) {
            transform.position = startPos;
        }

        // On mouse down
        if (Input.GetMouseButtonDown(0)) {
            Block.Color blockColor;
            switch (Random.Range(0, 4)) {
                case 0:
                    blockColor = Block.Color.Blue;
                    break;
                case 1:
                    blockColor = Block.Color.Green;
                    break;
                case 2:
                    blockColor = Block.Color.Red;
                    break;
                case 3:
                    blockColor = Block.Color.Yellow;
                    break;
                default:
                    throw new System.Exception("Invalid block color");
            }

            spriteRenderer.sprite = Block.GetSprite(blockColor);
        }
    }

	private void FixedUpdate() {
        Vector3 unit = new Vector3(0, -1);
        transform.position += unit * speed * Time.deltaTime;
	}
}
