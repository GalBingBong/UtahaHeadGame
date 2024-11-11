using UnityEngine;
using UnityEngine.Audio;

public class AudioManger : MonoBehaviour
{
    public static AudioManger instance;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVol;
    public int channals;
    AudioSource[] sfxPlayers;
    int channalsIndex;
    void Awake()
    {
        instance = this;
        Init();
    }
    public enum Sfx {Shoot, Hit};

    void Init()
    {
        //효과음 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channals];

        for(int i = 0; i < channals; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVol;
        }
    }
    public void PlaySfx(Sfx sfx)
    {

        for(int i = 0;i < channals; i++)
        {
            int LoopIndex = (i + channalsIndex) % sfxPlayers.Length;
            if (sfxPlayers[LoopIndex].isPlaying)
                continue;

            channalsIndex = LoopIndex;
            sfxPlayers[LoopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[LoopIndex].Play();

            break;
        }
        
    }
}
