using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class BackgroundTileFactory : MonoBehaviour
    {
        [SerializeField] private Transform backgroundParents;

        private readonly Dictionary<BackgroundTile, List<BackgroundTile>> _tilePool =
            new Dictionary<BackgroundTile, List<BackgroundTile>>();

        public List<BackgroundTile> GetTiles(LevelBackground level,float levelHeight, float startHeightOffset)
        {
            return SetupTiles(level.GetTilePrefabs(levelHeight), startHeightOffset);
        }

        public List<BackgroundTile> GetNewLevel(LevelBackground level, float levelHeight, float startHeightOffset)
        {
            BackgroundTile startTilePrefab = level.GetStartTile();
            List<BackgroundTile> tilePrefabs = level.GetTilePrefabs(levelHeight - startTilePrefab.Height);

            tilePrefabs.Insert(0, startTilePrefab);

            return SetupTiles(tilePrefabs, startHeightOffset);
        }

        public BackgroundTile GetTransition(LevelBackground level, float startHeight)
        {
            return SetupTile(level.GetTransitionTile(), startHeight);
        }

        public void ReturnTile(BackgroundTile tile)
        {
            tile.gameObject.SetActive(false);
        }

        private List<BackgroundTile> SetupTiles(List<BackgroundTile> tilePrefabs, float startHeight)
        {
            var instances = new List<BackgroundTile>();
            float height = startHeight;

            foreach (BackgroundTile tile in tilePrefabs)
            {
                instances.Add(SetupTile(tile, height));
                height += tile.Height;
            }

            return instances;
        }

        private BackgroundTile SetupTile(BackgroundTile prefab, float height)
        {
            BackgroundTile tileInstance = GetTileFromPool(prefab);

            tileInstance.SetActive(true);
            tileInstance.transform.localPosition = Vector3.up * height;

            return tileInstance;
        }

        private BackgroundTile GetTileFromPool(BackgroundTile start)
        {
            if (_tilePool.ContainsKey(start) == false)
                _tilePool.Add(start, new List<BackgroundTile>());

            if (_tilePool[start].All(tile => tile.gameObject.activeSelf))
            {
                BackgroundTile tile = CreateTile(start);
                _tilePool[start].Add(tile);
            }

            return _tilePool[start].First(tile => tile.IsActive == false);
        }

        private BackgroundTile CreateTile(BackgroundTile prefab)
        {
            BackgroundTile tile = Instantiate(prefab, backgroundParents);
            tile.SetActive(false);
            return tile;
        }
    }
}