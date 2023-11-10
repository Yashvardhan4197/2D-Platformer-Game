using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public static SoundManager Instance{get {return instance;} }
    
    [SerializeField] AudioSource SoundBg;
    [SerializeField] AudioSource SoundSFX;
    [SerializeField] AudioSource SoundFootsteps;
    [SerializeField] SoundType[] types;

    void Awake()
    {
        if(instance==null){
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start(){
        PlayBgMusic(Sound.Music);
    }

    public void PlaySound(Sound sound){
        AudioClip item=GetSoundClip(sound);
        if(item!=null){
            SoundSFX.PlayOneShot(item);
        }
    }

    public void PlayBgMusic(Sound sound){
        AudioClip item=GetSoundClip(sound);
        if(item!=null){
            SoundBg.clip=item;
            SoundBg.Play();
        }
    }

    public void PlayWalkSound(Sound sound){
        AudioClip item=GetSoundClip(sound);
        if(item!=null){
            if(SoundFootsteps.isPlaying!=true){
            SoundFootsteps.PlayOneShot(item);
            }
        }
    }

    private AudioClip GetSoundClip(Sound sound){
        SoundType item=Array.Find(types,i=>i.soundtype==sound);
        if(item!=null){
            return item.Audios;
        }
        return null;
    }
}


[Serializable]
class SoundType{
    public Sound soundtype;
    public AudioClip Audios;
} 

public enum Sound{
ButtonClick,
PlayerWalk,
Music,
keyPick,
ChangeLevel
}
