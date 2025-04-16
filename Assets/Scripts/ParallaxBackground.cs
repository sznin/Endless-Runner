using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLooper : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform[] tiles;   // Two tiles for seamless looping
        public float speed;         // Scrolling speed
        public float tileWidth;     // Width of one tile
    }

    public ParallaxLayer[] layers;

    void Update()
    {
        foreach (ParallaxLayer layer in layers)
        {
            foreach (Transform tile in layer.tiles)
            {
                // Move the tile left
                tile.position += Vector3.left * layer.speed * Time.deltaTime;

                // If it's moved off-screen (left), reposition to the right
                if (tile.position.x <= -layer.tileWidth)
                {
                    float rightMostX = GetRightmostTileX(layer.tiles);
                    tile.position = new Vector3(rightMostX + layer.tileWidth, tile.position.y, tile.position.z);
                }
            }
        }
    }

    private float GetRightmostTileX(Transform[] tiles)
    {
        float maxX = float.MinValue;
        foreach (Transform tile in tiles)
        {
            if (tile.position.x > maxX)
                maxX = tile.position.x;
        }
        return maxX;
    }
}
