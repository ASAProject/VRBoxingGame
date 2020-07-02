using UnityEngine;
using UnityEngine.UI;
#if(UNITY_2018_3_OR_NEWER)
using UnityEngine.Android;
#endif
using agora_gaming_rtc;

public class HelloUnity3D : MonoBehaviour
{
    private IRtcEngine mRtcEngine = null;
    [SerializeField]
    private string appId = "YOUR APP ID";
    public Button mic,aud;
    bool isMuted = false;
    bool isAudiooff = false;
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }
    void Start()
    {
#if (UNITY_2018_3_OR_NEWER)
			if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
			{
			
			} 
			else 
			{
				Permission.RequestUserPermission(Permission.Microphone);
			}
#endif
       // muteButton.onClick.AddListener(MuteButtonTapped);

        mRtcEngine = IRtcEngine.GetEngine(appId);
        JoinChannel();
        mRtcEngine.OnJoinChannelSuccess += (string channelName, uint uid, int elapsed) =>
        {
           // muteButton.gameObject.SetActive(true);
        };

        mRtcEngine.OnLeaveChannel += (RtcStats stats) =>
        {
           // muteButton.gameObject.SetActive(false) ;
           /* if (isMuted)
            {
                MuteButtonTapped();
            }*/
        };
        mRtcEngine.OnUserMutedAudio += (uint uid, bool muted) =>
        {
            string userMutedMessage = string.Format("onUserMuted callback uid {0} {1}", uid, muted);
            Debug.Log(userMutedMessage);
        };
    }

    void Update()
    {

    }

    public void JoinChannel()
    {
        string channelName = SaveRoomString.roomname;
        Debug.Log(string.Format("tap joinChannel with channel name {0}", channelName));

        if (string.IsNullOrEmpty(channelName))
        {
            return;
        }
        mRtcEngine.JoinChannel(channelName, "extra", 0);
    }

    public void LeaveChannel()
    {
        mRtcEngine.LeaveChannel();
        string channelName = SaveRoomString.roomname;
    }

    void OnApplicationQuit()
    {
        if (mRtcEngine != null)
        {
            IRtcEngine.Destroy();
        }
    }


    public string getSdkVersion()
    {
        string ver = IRtcEngine.GetSdkVersion();
        if (ver == "2.9.1.45")
        {
            ver = "2.9.2";  // A conversion for the current internal version#
        }
        else
        {
            if (ver == "2.9.1.46")
            {
                ver = "2.9.2.1";  // A conversion for the current internal version#
            }
        }
        return ver;
    }


    
    void MuteButtonTapped()
    {
      //  string labeltext = isMuted ? "Mute" : "Unmute";
       // Text label = muteButton.GetComponentInChildren<Text>();
       /* if (label != null)
        {
            label.text = labeltext;
        }*/
       // isMuted = !isMuted;
        //mRtcEngine.EnableLocalAudio(!isMuted);
    }
    public void Mic(){
        string buttontext = isMuted ? "MicMute" : "MicUnmute";
        Text labeltext = mic.GetComponentInChildren<Text>();
        labeltext.text = buttontext;
        isMuted = !isMuted;
        mRtcEngine.EnableLocalAudio(!isMuted);
    }
    public void Audio(){
        string buttontext = isAudiooff ? "AudioMute" : "AudioUnmute";
        Text labeltext = aud.GetComponentInChildren<Text>();
        labeltext.text = buttontext;
        isAudiooff = !isAudiooff;
        mRtcEngine.MuteAllRemoteAudioStreams(isAudiooff);
        
    }
    
}
