using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource song1;

    [SerializeField]
    private AudioSource song2;

    [SerializeField]
    private AudioSource song3;

    private float gameTime;

    [SerializeField]
    private float addSecondSong;

    [SerializeField]
    private float addThirdSong;

    [SerializeField]
    private float maxVolume;

    [SerializeField]
    private float fadeInSpeedDivider;





    // Start is called before the first frame update
    void Start()
    {
        song2.volume = 0;
        song3.volume = 0;


    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;


        if(gameTime > addSecondSong && gameTime < addThirdSong)
        {
            if(song2.volume < maxVolume)
            {
                song2.volume += Time.deltaTime/fadeInSpeedDivider;
                //song1.volume = 0;
            }
            
        }

        if (gameTime > addThirdSong)
        {
            if (song3.volume < maxVolume)
            {
                song3.volume += Time.deltaTime/fadeInSpeedDivider;
                //song2.volume = 0;
            }

        }

    }
}
