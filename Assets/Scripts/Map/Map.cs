using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public static Map instance = null;
    Tile[,] m_TileMatrix;
    public Tile m_TileInstance;
    int m_TileID=0;
    float m_TileSize = 2.5f;// Nu este final. Trebuie ca sizeul sa fie fix si sa apartina Tileului, nu Mapului

    int m_MatrixLength = 10;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("BeatMaster instantiat de doua ori");
            Destroy(gameObject);
        }
        instance = gameObject.GetComponent<Map>();
        m_TileMatrix = new Tile[m_MatrixLength, m_MatrixLength];
        for(int i = 0 ; i < m_MatrixLength; i++)
        {
            for (int j = 0 ; j < m_MatrixLength; j++)
            {
                Vector3 position = new Vector3((float)((j + 0.5) * m_TileSize - instance.transform.localScale.x / 2), (float)((i + 0.5) * m_TileSize - instance.transform.localScale.y / 2), 0);
                Tile tile_instance = Object.Instantiate(m_TileInstance, position, Quaternion.identity);
                tile_instance.m_TileID = m_TileID;
                m_TileID++;
                tile_instance.transform.localScale = new Vector3(m_TileSize, m_TileSize, 0);
                tile_instance.transform.parent = instance.transform;
                if ((i + j) % 2 == 0)// Muta if ul in Tile
                {
                    tile_instance.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                }
                else
                {
                    tile_instance.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
                }
                m_TileMatrix[i, j] = tile_instance;
                tile_instance.SetTile(DIRECTION.Up, tile_instance);
                tile_instance.SetTile(DIRECTION.Down, tile_instance);
                tile_instance.SetTile(DIRECTION.Left, tile_instance);
                tile_instance.SetTile(DIRECTION.Right, tile_instance);
            }
        }
        //Set neighbour
        for (int i = 0; i < m_MatrixLength; i++)
        {
            for (int j = 0; j < m_MatrixLength; j++)
            {
                if (m_TileMatrix[i, j] == null)
                {
                    Debug.Log("Skipped tile "+ m_TileMatrix[i, j].m_TileID);
                    continue;
                }
                if (i > 0)
                {
                    m_TileMatrix[i, j].SetTile(DIRECTION.Down, m_TileMatrix[i - 1, j]);
                }
                if (j > 0)
                {
                    m_TileMatrix[i, j].SetTile(DIRECTION.Left, m_TileMatrix[i, j - 1]);
                }
                if (i < m_MatrixLength - 1)
                {
                    m_TileMatrix[i, j].SetTile(DIRECTION.Up, m_TileMatrix[i + 1, j]);
                }
                if (j < m_MatrixLength - 1)
                {
                    m_TileMatrix[i, j].SetTile(DIRECTION.Right, m_TileMatrix[i, j + 1]);
                }
            }
        }

    }

    public Tile GetTile(Vector3 _position)
    {
        return m_TileMatrix[0,0];
    }

}
