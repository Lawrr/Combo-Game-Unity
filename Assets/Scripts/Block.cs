using System;
using UnityEngine;

public class Block {
    public enum Color {Clear, Blue, Green, Red, Yellow };

    public static Sprite GetSprite(Color color) {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/sprite-sheet");
        string[] spriteNames = new string[sprites.Length];

        for (int i = 0; i < spriteNames.Length; i++) {
            spriteNames[i] = sprites[i].name;
        }

        return sprites[Array.IndexOf(spriteNames, GetSpriteName(color))];
    }

    public static string GetSpriteName(Color color) {
        switch (color) {
            case Color.Clear:
                return "clear-block";
            case Color.Blue:
                return "blue-block";
            case Color.Green:
                return "green-block";
            case Color.Red:
                return "red-block";
            case Color.Yellow:
                return "yellow-block";
            default:
                throw new Exception("Invalid block color");
        }
    }
}
