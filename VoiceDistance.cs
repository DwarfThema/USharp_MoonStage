
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class VoiceDistance : UdonSharpBehaviour
{
    [UdonSynced, FieldChangeCallback(nameof(BigMic))]
    private int _BigMic;

    private int _PrevBigMic = -2;
    private int interCount;

    public int BigMic
    {
        set
        {
            _BigMic = value;
            if (_PrevBigMic != value)
            {
                if (_PrevBigMic != -2)
                {
                    if (VRCPlayerApi.GetPlayerById(_PrevBigMic) != null)
                    {
                        VRCPlayerApi player = VRCPlayerApi.GetPlayerById(_PrevBigMic);
                        player.SetVoiceDistanceNear(0.5F);
                        player.SetVoiceDistanceFar(25);
                        //Debug.Log("마지막 플레이어 마이크 초기화");
                    }
                }
                if (VRCPlayerApi.GetPlayerById(value) != null)
                {
                    VRCPlayerApi player = VRCPlayerApi.GetPlayerById(value);
                    player.SetVoiceDistanceNear(10000);
                    player.SetVoiceDistanceFar(10000);
                    //Debug.Log("새 플레이어 마이크 증폭");
                }
                _PrevBigMic = value;
            }
        }
        get => _BigMic;
    }

    public void BigMicOff()
    {
        if (_PrevBigMic != BigMic)
        {
            if (_PrevBigMic != -2)
            {
                if (VRCPlayerApi.GetPlayerById(_PrevBigMic) != null)
                {
                    VRCPlayerApi player = VRCPlayerApi.GetPlayerById(_PrevBigMic);
                    player.SetVoiceDistanceNear(0.5F);
                    player.SetVoiceDistanceFar(25);
                    //Debug.Log("네트워크 마지막 플레이어 마이크 초기화");
                }
            }
            if (VRCPlayerApi.GetPlayerById(BigMic) != null)
            {
                VRCPlayerApi player = VRCPlayerApi.GetPlayerById(BigMic);
                player.SetVoiceDistanceNear(10000);
                player.SetVoiceDistanceFar(10000);
                //Debug.Log("네트워크 새 플레이어 마이크 증폭");
            }
            _PrevBigMic = BigMic;
        }
        else if (VRCPlayerApi.GetPlayerById(BigMic) != null)
        {
            VRCPlayerApi player = VRCPlayerApi.GetPlayerById(BigMic);
            player.SetVoiceDistanceNear(0.5F);
            player.SetVoiceDistanceFar(25);
            //Debug.Log("네트워크 새 플레이어 마이크 초기화");

            _PrevBigMic = -2;
        }
    }

    public override void Interact()
    {
        interCount++;
        //Debug.Log("인터렉트 횟수" + interCount);
        //Debug.Log("빅마우스 플레이어 아이디 값" + BigMic);

        if (BigMic != Networking.LocalPlayer.playerId)
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
            BigMic = Networking.LocalPlayer.playerId; //1
            RequestSerialization();
            //Debug.Log("버튼 눌림");
        }
        else
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "BigMicOff");
            //Debug.Log("엘스 버튼 눌림");
        }
    }
}