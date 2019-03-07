using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {
    [SerializeField] AudioClip firstAudio;
    [SerializeField] AudioClip secondAudio;
    [SerializeField] AudioClip thirdAudio;
    [SerializeField] AudioClip forthAudio;
    List<AudioClip> music;
   

    int i = 0;
    float timer = 0;
    public static float musicPlayInterval=0.85f;
  
	// Use this for initialization

	void Start () {

        music = new List<AudioClip>();

        music.Add(firstAudio);
        music.Add(secondAudio);
        music.Add(thirdAudio);
        music.Add(forthAudio);
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time-timer>musicPlayInterval){
            AudioSource.PlayClipAtPoint(music[i], Camera.main.transform.position, 30f);
            i++;
            timer = Time.time;
            if (i==4){
                i = 0;
            }
          
        }

	}

}
