using UnityEngine;
using System.Collections;

public class EmptyBlockController : MonoBehaviour {

    public int speed = 1;

    private SpriteRenderer spriteRenderer;

	private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    private void Update() {
        // Check if reached bottom of screen
        if (transform.position.y < -5.5) {
            Destroy(gameObject);
        }

        // On mouse down
        if (Input.GetMouseButtonDown(0)) {
            // Check for mouse click on the block
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider) {
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
    }

	private void FixedUpdate() {
        Vector3 unit = new Vector3(0, -1);
        transform.position += unit * speed * Time.deltaTime;
	}
}
