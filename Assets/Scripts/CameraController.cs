using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    private CinemachineBrain _cmBrain;
    private ICinemachineCamera _icCamera;
    private CinemachineVirtualCamera _cmVirtual;
    private GameObject _mainCamera;
    private CinemachinePOV _cmPOV;
    // Start is called before the first frame update
    void Start()
    {
        _cmBrain = GetComponent<CinemachineBrain>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _icCamera = _cmBrain.ActiveVirtualCamera;
        _mainCamera = _icCamera.VirtualCameraGameObject;
     
        _cmVirtual = _mainCamera.GetComponent<CinemachineVirtualCamera>();
        _cmPOV = _cmVirtual.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();
        
        _cmPOV.m_HorizontalAxis.m_InvertInput = toggle.isOn;
        _cmPOV.m_VerticalAxis.m_InvertInput = toggle.isOn;
    }
}
