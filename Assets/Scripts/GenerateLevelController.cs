using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelController
{
    private const int CountWall = 4;

    private Tilemap _tileMapGround;
    private Tile _tileGround;
    private int _widthtMap;
    private int _heightMap;
    private int _factorSmooth;
    private int _randomFillPercent;

    private int[,] _map;

    public GenerateLevelController(GenerateLevelView generateLevelView)
    {
        _tileMapGround = generateLevelView.TileMapGround;

        _tileGround = generateLevelView.TileGround;
        _widthtMap = generateLevelView.WidthtMap;
        _heightMap = generateLevelView.HeightMap;
        _factorSmooth = generateLevelView.FactorSmooth;
        _randomFillPercent = generateLevelView.RandomFillPercent;

        _map = new int[_widthtMap, _heightMap];
    }

    public void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        RandomFillLevel();
        for (var i = 0; i < _factorSmooth; i++)
        {
            SmoothMap();
        }

        DrawTileOnMap();
    }

    private void RandomFillLevel()
    {
        var seed = Time.time.GetHashCode();
        var random = new System.Random(seed);

        for (var x = 0; x < _widthtMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                if (x == 0 || x == _widthtMap - 1 || y == 0 || y == _heightMap - 1)
                {
                    _map[x, y] = 1;
                }
                else
                {
                    _map[x, y] = random.Next(0, 100) < _randomFillPercent ? 1 : 0;
                }
            }
        }
    }

    private void SmoothMap()
    {
        for (var x = 0; x < _widthtMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var neigbourGroundTile = GetSurroundingGroundCount(x, y);
                
                if (neigbourGroundTile > CountWall)
                {
                    _map[x, y] = 1;
                }
                else if(neigbourGroundTile < CountWall)
                {
                    _map[x, y] = 0;
                }
            }
        }
    }

    private int GetSurroundingGroundCount(int x, int y)
    {
        var wallCount= 0;

        for (var neighbourX = x - 1; neighbourX <= x +1 ; neighbourX++)
        {
            for (var neighbourY = x - 1; neighbourY <= x + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < _widthtMap && neighbourY >= 0 && neighbourY < _heightMap)
                {
                    if (neighbourX != x || neighbourY != y)
                    {
                        wallCount += _map[x, y];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;

    }


    private void DrawTileOnMap()
    {
        if (_map == null)
        {
            return;
        }

        for (var x = 0; x < _widthtMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var positionTile = new Vector3Int(-_widthtMap / 2 + x, -_heightMap / 2 + y, 0);
               if (_map[x, y] == 1)
               {
                   _tileMapGround.SetTile(positionTile, _tileGround);
               }
            }
        }
    }
}

