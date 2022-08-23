
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

public int BigMic
{
    set
    {
        if (_PrevBigMic != value) {
            if (_PrevBigMic != -2) {
                if (VRCPlayerApi.GetPlayerById(_PrevBigMic) != null) {
                    VRCPlayerApi player = VRCPlayerApi.GetPlayerById(_PrevBigMic);
                    player.SetVoiceDistanceNear(0.5F);
                    player.SetVoiceDistanceFar(25);
                }
            }
            if (VRCPlayerApi.GetPlayerById(value) != null) {
                VRCPlayerApi player = VRCPlayerApi.GetPlayerById(value);
                player.SetVoiceDistanceNear(10000);
                player.SetVoiceDistanceFar(10000);
            }
            _PrevBigMic = value;
        } else {
            if (VRCPlayerApi.GetPlayerById(value) != null) {
                VRCPlayerApi player = VRCPlayerApi.GetPlayerById(value);
                player.SetVoiceDistanceNear(0.5F);
                player.SetVoiceDistanceFar(25);
            }
        }
    }
    get => _BigMic;
}

public override void Interact()
{
    Networking.SetOwner(Networking.LocalPlayer, gameObject);
    BigMic = Networking.LocalPlayer.playerId;
    RequestSerialization();
}
}