using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum DIRECTION
{
    Invalid,
    None,
    Up,
    Down,
    Left,
    Right
}

public enum MOVEMENT
{
    Invalid,
    Free,
    Grid
}

public class Player : AboveTileObject
{
    Rigidbody2D rb2d;
    public float speed;
    Tile m_OldTile;
    DIRECTION m_MovementDirection = DIRECTION.None;
    Vector3 m_NewPosition;
    MOVEMENT m_Movement = MOVEMENT.Free;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2( moveHorizontal, moveVertical);
        if(m_Movement == MOVEMENT.Free)
        {
            rb2d.velocity = movement * speed;
        }

        if (m_Movement == MOVEMENT.Grid)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                m_MovementDirection = DIRECTION.Down;
                Debug.Log("Grid Down from " + m_CurrentTile.m_TileID + " to " + m_CurrentTile.GetTile(DIRECTION.Down).m_TileID);
                Moving(m_CurrentTile.GetTile(DIRECTION.Down));
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                m_MovementDirection = DIRECTION.Up;
                Debug.Log("Grid Up from " + m_CurrentTile.m_TileID + " to " + m_CurrentTile.GetTile(DIRECTION.Up).m_TileID);
                Moving(m_CurrentTile.GetTile(DIRECTION.Up));
                
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                m_MovementDirection = DIRECTION.Left;
                Debug.Log("Grid Left from " + m_CurrentTile.m_TileID + " to " + m_CurrentTile.GetTile(DIRECTION.Left).m_TileID);
                Moving(m_CurrentTile.GetTile(DIRECTION.Left));
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                m_MovementDirection = DIRECTION.Right;
                Debug.Log("Grid Right from " + m_CurrentTile.m_TileID + " to " + m_CurrentTile.GetTile(DIRECTION.Right).m_TileID);
                Moving(m_CurrentTile.GetTile(DIRECTION.Right));
            }
        }

        if (Input.GetKeyDown("1") && m_Movement == MOVEMENT.Free)
        {
            m_CurrentTile = Map.instance.GetTile(transform.position);
            m_Movement = MOVEMENT.Grid;
            m_OldTile = m_CurrentTile;
            Vector3 new_position = m_CurrentTile.transform.position;
            transform.position = new Vector3(new_position.x, new_position.y, 0);
            m_CurrentTile.AddToTile(GetComponent<AboveTileObject>());
        }

        if (Input.GetKeyDown("2") && m_Movement == MOVEMENT.Grid)
        {
            m_Movement = MOVEMENT.Free;
        }

    }

    void Moving(Tile _nextTile)
    {
        m_OldTile = m_CurrentTile;
        //m_CurrentTile.RemoveFromTile(GetComponent<AboveTileObject>());
        m_CurrentTile.m_AboveTileObject = null;
        m_CurrentTile = _nextTile;
        m_CurrentTile.AddToTile(GetComponent<AboveTileObject>());
        Vector3 new_position = m_CurrentTile.transform.position;
        m_NewPosition = new Vector3(new_position.x, new_position.y, 0);
        transform.position = m_CurrentTile.transform.position;

    }
}
