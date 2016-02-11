using System;
using UnityEngine;

public class Block : MonoBehaviour {

    public enum Color { Clear, Blue, Green, Red, Yellow };

    public int speed = 1;

    private SpriteRenderer spriteRenderer;
    private Color color;

    public static Sprite GetSprite(Color color) {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/SpriteSheet");
        string[] spriteNames = new string[sprites.Length];

        for (int i = 0; i < spriteNames.Length; i++) {
            spriteNames[i] = sprites[i].name;
        }

        return sprites[Array.IndexOf(spriteNames, GetSpriteName(color))];
    }

    public static string GetSpriteName(Color color) {
        switch (color) {
            case Color.Clear:
                return "ClearBlock";
            case Color.Blue:
                return "BlueBlock";
            case Color.Green:
                return "GreenBlock";
            case Color.Red:
                return "RedBlock";
            case Color.Yellow:
                return "YellowBlock";
            default:
                throw new Exception("Invalid block color");
        }
    }

    public void SetSprite(Color color) {
        this.color = color;
        spriteRenderer.sprite = GetSprite(color);
    }

    protected virtual void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update() {
        // Check if reached bottom of screen
        if (transform.position.y < -5.5) {
            Remove();
        }
    }

    protected virtual void FixedUpdate() {
        Vector3 unit = new Vector3(0, -1);
        transform.position += unit * speed * Time.deltaTime;
    }

    public void Remove() {
        GameManager.instance.RemoveBlock(gameObject);
        Destroy(gameObject);
    }

}
