﻿/*
 * 長嶋
 * 
 * Photonの機能で使いそうなものをまとめたクラス
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Online
{

    public class BaseNetworkObject : MonoBehaviourPunCallbacks
    {

        public void Start()
        {

            PhotonNetwork.GameVersion = "1.0.0";

        }

        /// <summary>
        /// @brief PhotonServerに接続する
        /// </summary>
        /// <param name="gameVer">使用するゲームのバージョン</param>
        public void Connected(string gameVer)
        {

            if (!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.GameVersion = gameVer;
                PhotonNetwork.ConnectUsingSettings();
            }

        }

        /// <summary>
        /// @brief PhotonServerに接続しているかどうかを返す
        /// </summary>
        /// <returns>Photonに接続している場合はtrueを返す。接続していない場合はfalseを返す。</returns>
        public bool CheckConnected()
        {

            if (!PhotonNetwork.IsConnected)
            {
                Debug.LogError("Photonに接続していません");

                return false;
            }

            return true;
        }

        /// <summary>
        /// @brief PhotonServerから切断する
        /// </summary>
        public void Disconnect()
        {
            PhotonNetwork.Disconnect();

            Debug.Log("PhotonServerから切断しました");
        }

        #region OutRoom

        /// <summary>
        /// @brief 部屋オプションを作成する
        /// </summary>
        /// /// <param name="mP">部屋に入れる最大人数</param>
        /// <param name="vis">部屋を公開するか</param>
        /// <param name="open">部屋に入れるかどうか</param>
        /// <returns>作成したオプション</returns>
        public RoomOptions CreateRoomOption(byte mP, bool vis = true, bool open = true)
        {
            RoomOptions option = new RoomOptions
            {
                MaxPlayers = mP,
                IsVisible = vis,
                IsOpen = open
            };

            return option;
        }

        /// <summary>
        /// @brief 新規の部屋を作成する
        /// </summary>
        /// <param name="roolName">部屋名（部屋番号）</param>
        /// <param name="options">部屋のカスタムオプション</param>
        /*public void CreateRoom(string roolName, RoomOptions options = null)
        {

            PhotonNetwork.CreateRoom(roolName, options);

        }

        /// <summary>
        /// @brief ランダムな部屋に参加する
        /// </summary>
        public void JoinRandomRoom()
        {

            PhotonNetwork.JoinRandomRoom();

        }

        /// <summary>
        /// @brief 部屋に参加する
        /// </summary>
        public bool JoinRoom(string roolName)
        {

            //部屋が見つからなかったときの処理
            if (!PhotonNetwork.JoinRoom(roolName))
            {
                Debug.LogWarning("部屋が見つかりませんでした");
                return false;
            }

            return true;
        }*/

        #endregion

        #region InRoom

        /// <summary>
        /// @brief ゲームルームを抜ける
        /// </summary>
        public void LeaveRoom()
        {
            if (!PhotonNetwork.InRoom)
            {
                return;
            }

            PhotonNetwork.LeaveRoom();

        }

        #endregion

    }

}