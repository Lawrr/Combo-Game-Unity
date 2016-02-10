using UnityEngine;
using System.Collections;

public class EmptyBlockController : Block {

    protected override void Update() {
        base.Update();

        // On mouse down
        if (Input.GetMouseButtonDown(0)) {
            // Check for mouse click on the block
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider == GetComponent<Collider2D>()) {
                Color blockColor;
                switch (Random.Range(0, 4)) {
                    case 0:
                        blockColor = Color.Blue;
                        break;
                    case 1:
                        blockColor = Color.Green;
                        break;
                    case 2:
                        blockColor = Color.Red;
                        break;
                    case 3:
                        blockColor = Color.Yellow;
                        break;
                    default:
                        throw new System.Exception("Invalid block color");
                }

                GameObject coloredBlock = (GameObject)Instantiate(Resources.Load("Prefabs/ColoredBlock"));
                coloredBlock.GetComponent<SpriteRenderer>().sprite = GetSprite(blockColor);
                coloredBlock.transform.position = transform.position;
                Destroy(gameObject);
            }
        }
    }
}
