using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelView : MonoBehaviour
{
    [SerializeField] private Tilemap _tileMapGround;
    [SerializeField] private Tile _tileGround;
    [SerializeField] private int _widthtMap; 
    [SerializeField] private int _heightMap;
    [SerializeField] private int _factorSmooth;
    [SerializeField][Range(0,100)] private int _randomFillPercent;  
    
    public Tilemap TileMapGround => _tileMapGround;

    public Tile TileGround => _tileGround;

    public int WidthtMap => _widthtMap;
    
    public int HeightMap => _heightMap;
    
    public int FactorSmooth => _factorSmooth;
    
    public int RandomFillPercent  => _randomFillPercent;
}
