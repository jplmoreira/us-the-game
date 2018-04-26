using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;




//https://www.youtube.com/watch?v=6OT43pvUyfY      TUTORIAL

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    
    
    public Sound[] sounds;
    
    public Sound[] musics;
    
    
      
	// Use this for initialization
	void Awake () {
		        
        foreach(Sound s in sounds){
            
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
        
        foreach(Sound m in musics){
            
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;

        }
	}
	
	public void Play (string name) {
		
        
        Sound s;
        
        if(Array.Find(sounds, sound => sound.name == name) != null){
            
            s = Array.Find(sounds, sound => sound.name == name);

        }else if (Array.Find(musics, sound => sound.name == name) != null){
    
            s = Array.Find(musics, sound => sound.name == name);
        
        }else{
            return;
        }
           
            
        s.source.Play();
	}
    
    
    public void VolumeSounds (float value){
        
        foreach(Sound s in sounds){
            
            s.source.volume = value;
        }
    }
    
    public void VolumeMusics (float value){
        
        foreach(Sound s in musics){
            
            s.source.volume = value;
        }
    }
    
    
        
    void Start(){
                
        Play("BackgroundMusic");
    }
}
