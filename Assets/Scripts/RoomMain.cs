using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomMain : MonoBehaviourPunCallbacks
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
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //무조건 손님임 
        player2NicknameText.text = newPlayer.NickName;
        Debug.Log($"[RoomMain] 다른 플레이어가 룸에 입장 했습니다. : {newPlayer}");
    }

    public override void OnJoinedRoom()
    {
        //무조건 나임 
        Debug.Log($"[RoomMain] 방에 입장했습니다.");
        Debug.Log($"방이름 : {PhotonNetwork.CurrentRoom.Name}");
        Debug.Log($"방에있는 사람들 : {PhotonNetwork.PlayerList.Length}");
        Debug.Log($"내가({PhotonNetwork.LocalPlayer.NickName}) 방장인가? {PhotonNetwork.IsMasterClient}");

        player1NicknameText.text = PhotonNetwork.MasterClient.NickName;
        player2NicknameText.text = PhotonNetwork.LocalPlayer.NickName;
        
    }
}
