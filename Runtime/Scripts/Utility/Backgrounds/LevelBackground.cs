using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YodeGroup.Runner
{
    [CreateAssetMenu(menuName = "Loyam/Games/Runner/LevelBackground", fileName = "LevelBackground", order = 0)]
    public class LevelBackground : ScriptableObject
    {
        [SerializeField] private BackgroundTile start;
        [SerializeField] private List<BackgroundTile> tiles;
        [SerializeField] private BackgroundTile transition;

        public BackgroundTile GetStartTile() => start;
        public BackgroundTile GetTransitionTile() => transition;

        public List<BackgroundTile> GetTilePrefabs(float height)
        {
            var list = new List<BackgroundTile>();
            float remainingHeight = height;

            while (remainingHeight > 0)
            {
                BackgroundTile tile = tiles[Random.Range(0, tiles.Count)];
                list.Add(tile);
                remainingHeight -= tile.Height;
            }

            return list;
        }
    }
}