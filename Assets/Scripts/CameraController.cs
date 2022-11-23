using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Header("移動中の仮想カメラ")] GameObject _isMoveCM;
    [SerializeField, Header("Set時の仮想カメラ")] GameObject _isSetCM;

    [SerializeField] PlayerMove _player;

    [SerializeField, Header("移動中の仮想カメラ")] CinemachineVirtualCamera _isMoveCVCM;
    [SerializeField, Header("Set時の仮想カメラ")] CinemachineVirtualCamera _isSetCVCM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (_player.IsSet)
        {
            _isMoveCVCM.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value
                = _isSetCVCM.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value;
            _isMoveCVCM.Priority = 10;
            _isSetCVCM.Priority = 20;
           
        }
        else
        {
            _isSetCVCM.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value
                = _isMoveCVCM.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>().m_HorizontalAxis.Value;
            _isMoveCVCM.Priority = 20;
            _isSetCVCM.Priority = 10;
        }
    }
}
