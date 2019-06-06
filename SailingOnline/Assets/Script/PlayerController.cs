﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks {

    //[SerializeField]
    //private TextMesh namePlate;
    [SerializeField]
    private GameObject mainPlayerMark;
    private Camera playerCamera;
    private bool isPlayerMove;

    [System.Obsolete]
    private void Start()
    {
        //namePlate.text = "プレイヤー";
        isPlayerMove = true;
        
        if (photonView.IsMine)
        {
            mainPlayerMark.active = true;
            playerCamera = Camera.main;
            playerCamera.GetComponent<CameraController>().playerShip = this.gameObject;
            Debug.Log("カメラを取得しました");
        }
    }

	// Update is called once per frame
	void Update () {

        //自身かどうかの判断
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            isPlayerMove = !isPlayerMove;
        }

        //ベクトルを正規化
        var direction = new Vector3(0.0f, 0.0f, -(isPlayerMove ? 3.0f : 0.0f)).normalized;
        //移動速度を時間依存にし、移動量を求める
        var dv = 5.0f * Time.deltaTime * direction;

        transform.Translate(dv.x, 0.0f, dv.z);
        transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);
    }

}
