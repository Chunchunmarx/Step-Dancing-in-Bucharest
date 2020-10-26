using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Player m_Player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - m_Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = m_Player.transform.position + offset;
    }

    public void SetPlayerReference ( Player _player )
    {
        m_Player = _player;
    }
}
