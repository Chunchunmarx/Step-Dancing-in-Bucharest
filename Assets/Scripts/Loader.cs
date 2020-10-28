using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public Player m_Player;
    public CameraController m_Camera;
    public Map m_Map;
    // Start is called before the first frame update
    void Start()
    {
        m_Map = Instantiate(m_Map);
        m_Player = Instantiate(m_Player);
        m_Camera = Instantiate(m_Camera);

        m_Camera.SetPlayerReference(m_Player);
    }
}
