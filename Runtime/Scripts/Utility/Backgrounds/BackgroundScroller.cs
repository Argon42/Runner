using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace YodeGroup.Runner
{
    public class BackgroundScroller : GameService
    {
        [SerializeField] private GameTime gameTime;
        [SerializeField] private Camera gameCamera;
        [SerializeField] private float scrollingSpeed;
        [SerializeField] private BackgroundTileFactory factory;

        private readonly List<BackgroundTile> _instances = new List<BackgroundTile>();

        private LevelBackground _level;

        private float ScreenHeight => gameCamera.orthographicSize * 2;

        private void Update()
        {
            if (ServiceEnabled == false)
                return;
            if (_level == false)
                return;

            MoveDown();
            DisableTileOutBelowFieldOfView();
            _instances.RemoveAll(tile => tile.IsActive == false);
            AddTilesIfItsNeeded();
        }

        protected override void OnStopService() => _level = null;

        public void StartLevel(LevelBackground level)
        {
            if (_level)
            {
                TransitToLevel(level);
            }
            else
            {
                _instances.ForEach(tile => factory.ReturnTile(tile));
                _instances.Clear();
                CreateLevel(level);
            }

            _level = level;
        }

        private void TransitToLevel(LevelBackground level)
        {
            if (_level == false)
                throw new InvalidOperationException($"{nameof(_level)} is null");

            bool ExtraTilePredicate(BackgroundTile tile) => tile.transform.localPosition.y > ScreenHeight;
            List<BackgroundTile> extraTiles = _instances.Where(ExtraTilePredicate).ToList();

            extraTiles.ForEach(tile => factory.ReturnTile(tile));

            float startHeight = extraTiles.Min(tile => tile.transform.position.y);

            _instances.Add(factory.GetTransition(_level, startHeight));
            CreateLevel(level, startHeight);
        }


        private void CreateLevel(LevelBackground level, float startHeight = 0)
        {
            _instances.AddRange(factory.GetNewLevel(level, ScreenHeight, startHeight));
        }

        private void AddTilesIfItsNeeded()
        {
            float GetTileHeight(BackgroundTile tile) => tile.transform.localPosition.y + tile.Height;

            BackgroundTile maxHeightTile = _instances.OrderByDescending(GetTileHeight).First();
            float maxHeightPosition = maxHeightTile.transform.localPosition.y;

            float higherPosition = maxHeightPosition + maxHeightTile.Height;
            if (higherPosition < ScreenHeight + maxHeightTile.Height)
            {
                _instances.AddRange(factory.GetTiles(_level, ScreenHeight, higherPosition));
            }
        }

        private void MoveDown()
        {
            foreach (BackgroundTile tile in _instances)
            {
                Transform tileTransform = tile.transform;
                Vector3 localPosition = tileTransform.localPosition;

                localPosition += Vector3.down * (scrollingSpeed * gameTime.GameSpeed * Time.deltaTime);
                tileTransform.localPosition = localPosition;
            }
        }

        private void DisableTileOutBelowFieldOfView()
        {
            foreach (BackgroundTile tile in _instances)
            {
                if (tile.transform.localPosition.y + tile.Height < 0)
                    factory.ReturnTile(tile);
            }
        }
    }
}