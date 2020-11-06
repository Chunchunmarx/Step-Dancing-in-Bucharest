using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Dictionary<DIRECTION, Tile> m_Tiles = null;
    public AboveTileObject m_AboveTileObject = null;
    //BEAT_PARITY m_TileParity;
    //float m_LayerNumber;
    [SerializeField]
    public KeyValuePair<int, int> m_Coordinates;
    //bool m_IsSubscribedToBeat = false;
    public int m_TileID;
    public float m_Transparency = 0.5f;

    void Awake()
    {
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        m_Tiles = new Dictionary<DIRECTION, Tile>();
        m_Tiles.Add(DIRECTION.Up, null);
        m_Tiles.Add(DIRECTION.Down, null);
        m_Tiles.Add(DIRECTION.Left, null);
        m_Tiles.Add(DIRECTION.Right, null);
    }

    private void Update()
    {
    }

    public void AddToTile(AboveTileObject _objectToAdd)
    {
        m_AboveTileObject = _objectToAdd;
        _objectToAdd.SetTileReference(gameObject.GetComponent<Tile>());
    }

    public void RemoveFromTile(AboveTileObject _objectToRemove)
    {
        
            m_AboveTileObject.DestroyThis();
    }

    public void SetTile(DIRECTION _tileDirection, Tile _tile)
    {
        m_Tiles[_tileDirection] = _tile;
    }

    public Tile GetTile(DIRECTION _tileDirection)
    {
        return m_Tiles[_tileDirection];
    }
    /*
    public void SetParity(BEAT_PARITY _tileParity)
    {
        m_TileParity = _tileParity;
    }
    
    public void OnBeat()
    {
        BEAT_PARITY beatparity = BeatMaster.instance.GetBeatParity();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (beatparity == m_TileParity)
        {
            spriteRenderer.sprite = m_DarkSprite;
        }
        else
        {
            spriteRenderer.sprite = m_LightSprite;
        }
    }

    
    void SubscribeToBeat()
    {
        if (m_IsSubscribedToBeat == false)
        {
            BeatMaster.instance.SubscribeToBeat(gameObject.GetComponent<IBeat>());
            m_IsSubscribedToBeat = true;
        }
    }
    
    void UnsubscribeToBeat()
    {
        if (m_IsSubscribedToBeat == true)
        {
            BeatMaster.instance.UnsubscribeToBeat(gameObject.GetComponent<IBeat>());
            m_IsSubscribedToBeat = false;
        }
    }
    */
    public void SetCoordinates(int _x, int _y)
    {
        m_Coordinates = new KeyValuePair<int, int>(_x, _y);
    }

    public int GetX()
    {
        return m_Coordinates.Key;
    }

    public int GetY()
    {
        return m_Coordinates.Value;
    }
}
