using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class TestOb : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    private void Update()
    {
        if (photonView.IsMine)
        {
            print("is mine");
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
        else
            print("is not mine");
           
    }
}
