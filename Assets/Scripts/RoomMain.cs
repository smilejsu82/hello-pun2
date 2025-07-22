using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviour
{
    public TMP_Text player1NicknameText;
    public TMP_Text player2NicknameText;
    
    private void Awake()
    {
        Debug.Log($"[RoomMain] Awake");
    }

    public void Init()
    {
        Debug.Log($"[RoomMain] Init");
        Debug.Log($"내({PhotonNetwork.LocalPlayer.NickName})가 방장인가? : {PhotonNetwork.IsMasterClient}");
        if (PhotonNetwork.IsMasterClient)
        {
            player1NicknameText.text = PhotonNetwork.LocalPlayer.NickName;
        }
    }

    void Start()
    {
        Debug.Log($"[RoomMain] Start");
    }
    
    

}
