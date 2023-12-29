using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class BossTimeline : MonoBehaviour
{
    public PlayableDirector pD;

    void Start()
    {
        pD = GetComponent<PlayableDirector>();
        if (pD == null)
        {
            Debug.LogError("PlayableDirector not assigned. Please assign it in the Inspector.");
            return;
        }

        // pD.playableAsset���� TimelineAsset�� ���������� ����
        TimelineAsset timelineAsset = pD.playableAsset as TimelineAsset;

        if (timelineAsset == null)
        {
            Debug.LogError("No Timeline Asset found in the PlayableDirector.");
            return;
        }

        CinemachineTrack cinemachineTrack = FindCinemachineTrack(timelineAsset);

        if (cinemachineTrack != null)
        {
            // MainCamera�� ã�� �� ��ҹ��� ��Ȯ�ϰ� Ȯ��
            GameObject mainCamera = GameObject.Find("Main Camera");

            if (mainCamera != null)
            {
                CinemachineBrain cinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();

                if (cinemachineBrain != null)
                {
                    pD.SetGenericBinding(cinemachineTrack, cinemachineBrain);
                    Debug.Log("CinemachineBrain bound to Cinemachine Track");
                }
                else
                {
                    Debug.LogError("CinemachineBrain not found on the MainCamera.");
                }
            }
            else
            {
                Debug.LogError("MainCamera not found.");
            }
        }
        else
        {
            Debug.LogError("Cinemachine Track not found in the Timeline Asset.");
        }
    }

    // ������ �ڵ�� �״�� ����

    CinemachineTrack FindCinemachineTrack(TimelineAsset timelineAsset)
    {
        foreach (var track in timelineAsset.GetOutputTracks())
        {
            if (track is CinemachineTrack)
            {
                return (CinemachineTrack)track;
            }
        }
        return null;
    }
}
