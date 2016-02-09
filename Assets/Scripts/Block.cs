using System;
using UnityEngine;

public class Block {
    public enum Color { Clear, Blue, Green, Red, Yellow };

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
}
