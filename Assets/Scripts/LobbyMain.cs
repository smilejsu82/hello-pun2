using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMain : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomNameInputField;
    public Button btnCreateRoom;
    public Button btnQuickJoinRoom;
    private void Awake()
    {
        Debug.Log("[LobbyMain] Awake");
    }

    public void Init()
    {
        Debug.Log("[LobbyMain] Init");
    }

    void Start()
    {
        Debug.Log("[LobbyMain] Start");
        btnCreateRoom.onClick.AddListener(() =>
        {   
            if (string.IsNullOrEmpty(roomNameInputField.text))
            {
                Debug.Log("방제를 입력 해주세요.");
            }
            else
            {
                Debug.Log($"방이름: {roomNameInputField.text}");
                string roomName = roomNameInputField.text;
                RoomOptions options = new RoomOptions { MaxPlayers = 2 };
                PhotonNetwork.CreateRoom(roomName, options);
            }
        });
        
        btnQuickJoinRoom.onClick.AddListener(() =>
        {
            PhotonNetwork.JoinRandomRoom();
        });
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"LobbyMain] 룸 생성 실패!!!  : {returnCode}, {message}");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("[LobbyMain] 룸이 생성 되었습니다.");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"[LobbyMain] 룸 입장에 실패!!! : {returnCode}, {message}");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"[LobbyMain] 룸에 입장했습니다.");
        var asyncOperation = SceneManager.LoadSceneAsync("RoomScene");
        asyncOperation.completed += operation =>
        {
            GameObject.FindObjectOfType<RoomMain>().Init();
        };
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"[LobbyMain] OnRoomListUpdate : {roomList.Count}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"[LobbyMain] 빠른 입장에 실패 했습니다.  : {returnCode}, {message}");
    }
}
