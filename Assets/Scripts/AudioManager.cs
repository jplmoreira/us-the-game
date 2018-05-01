using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;



//https://www.youtube.com/watch?v=6OT43pvUyfY      TUTORIAL

public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    
    public Sound[] sounds;
    
    public Sound[] musics;
    
    public string currentScene;
    
    
    public void Play (string name) {
		
        Debug.Log("entrei no play " + name);
        
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
    
    
    public void Stop (string name) {
		
        Debug.Log("entrei no stop " + name);
        
        Sound s;
        
        if(Array.Find(sounds, sound => sound.name == name) != null){
            
            s = Array.Find(sounds, sound => sound.name == name);

        }else if (Array.Find(musics, sound => sound.name == name) != null){
    
            s = Array.Find(musics, sound => sound.name == name);
        
        }else{
            return;
        }
           
            
        s.source.Stop();
	}
    

      
	// Use this for initialization
	void Awake () {
        
        currentScene = SceneManager.GetActiveScene().name;
        
        Debug.Log("entrei no awake em "+ currentScene);
        
//        if(instance == null){
//            instance = this;
//        }else{
//            Destroy(gameObject);
//            Play("LevelBackgroundMusic");
//            Stop("BackgroundMusic");
//            return;
//        }
//        
//        DontDestroyOnLoad(gameObject);
		        
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
        
        if(String.Compare(currentScene, "Home Menu") == 0){
            Debug.Log("play o menu!!!");
            
            Play("BackgroundMusic");
            Stop("LevelBackgroundMusic");

        }else if(String.Compare(currentScene, "Demo") == 0){
            Debug.Log("play o level!!!");
            
            Play("LevelBackgroundMusic");
            Stop("BackgroundMusic");
        }
    
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
    
    public void Pause(){
        foreach(Sound s in musics){
            
            s.source.mute = true;
        }
    }
    
    public void Resume(){
        foreach(Sound s in musics){
            
            s.source.mute = false;
        }
    }
        
    void Start(){
                
        Debug.Log("entrei no start em "+ currentScene);
        
        if(String.Compare(currentScene, "Home Menu") == 0){
            
            Debug.Log("play o menu!!!");
            Play("BackgroundMusic");
            Stop("LevelBackgroundMusic");
        }else if(String.Compare(currentScene, "Demo") == 0){
            
            Debug.Log("play o level!!!");
            Play("LevelBackgroundMusic");
            Stop("BackgroundMusic");
        }
    }
}
