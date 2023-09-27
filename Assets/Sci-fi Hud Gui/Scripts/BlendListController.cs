using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BlendListController : MonoBehaviour
{
    private CinemachineBlendListCamera _blendListCam;
    private bool _blendIsActive = true;

    private void Start()
    {
        _blendListCam = GetComponent<CinemachineBlendListCamera>();
    }

    public void ToggleBlendList()
    {
        if (_blendIsActive)
        {
            // If it's the last camera in the list, turn off blending.
            if (_blendListCam.LiveChild == _blendListCam.m_Instructions[_blendListCam.m_Instructions.Length - 1].m_VirtualCamera)
            {
                _blendIsActive = false;
                // Possibly deactivate the blend list cam or do other things as needed.
            }
        }
        else
        {
            // Reactivate or restart the blend list.
            _blendIsActive = true;
            // You might need to force the blendListCam to switch to its first camera or other logic to restart the blend.
            _blendListCam.m_Instructions[0].m_VirtualCamera.Priority = 11;  // Assuming other cameras have priority 10.
            StartCoroutine(ResetPriority(_blendListCam.m_Instructions[0].m_VirtualCamera));
        }
    }

    private IEnumerator ResetPriority(CinemachineVirtualCameraBase vcam)
    {
        yield return new WaitForSeconds(0.1f);
        vcam.Priority = 10;
    }
}
