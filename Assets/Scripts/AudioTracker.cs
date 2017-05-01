using UnityEngine;
using System;
using System.Collections;


public class AudioTracker : MonoBehaviour
{




    int roomnumberint = 0;
    int currentroom = 0;
    int puzzlenumberint = 0;
    int currentpuzzle = 0;
    int SFXnumberint = 0;


    //string[] Roommlist = { "00", "01", "02", "03", "04", "05", "06", "07", "08" };
    //string[] Puzzlelist = { "00", "01", "02", "03", "04", "05", "06", "07" };
    //string[] SFXlist = { "00", "Candle On", "Candle Off", "Door", "Menuing", "Cadran", "Stone Steps", "Wood Steps", "Puzzle Fail", "Reward", "LightYear" };


    public AudioSource Room01;
    public AudioSource Room02;
    public AudioSource Room03;
    public AudioSource Room04;
    public AudioSource Room05;
    public AudioSource Room06;
    public AudioSource Room07;
    public AudioSource Room08;

    public AudioSource puzzle01;
    public AudioSource puzzle02;
    public AudioSource puzzle03;
    public AudioSource puzzle04;
    public AudioSource puzzle05;
    public AudioSource puzzle06;
    public AudioSource puzzle07;

    public AudioSource weather01;
    public AudioSource weather02;

    public AudioSource weather03;

    public AudioSource sfx01;
    public AudioSource sfx02;
    public AudioSource sfx03;
    public AudioSource sfx04;
    public AudioSource sfx05;
    public AudioSource sfx06;
    public AudioSource sfx07;
    public AudioSource sfx08;
    public AudioSource sfx09;


    // Use this for initialization
    void Start()
    {

        puzzle01.volume = 1;
        puzzle01.Play();
        puzzle02.volume = 0;
        puzzle02.Play();
        puzzle02.volume = 0;
        puzzle02.Play();
        puzzle03.volume = 0;
        puzzle03.Play();
        puzzle04.volume = 0;
        puzzle04.Play();
        puzzle05.volume = 0;
        puzzle05.Play();
        puzzle06.volume = 0;
        puzzle06.Play();
        puzzle07.volume = 0;
        puzzle07.Play();

        weather01.volume = 0;
        weather01.Play();

        weather02.volume = 0;
        weather02.Play();


        Room01.volume = 0;
        Room01.Play();
        Room02.volume = 0;
        Room02.Play();
        Room03.volume = 0;
        Room03.Play();
        Room04.volume = 0;
        Room04.Play();
        Room05.volume = 0;
        Room05.Play();
        Room06.volume = 0;
        Room06.Play();
        Room07.volume = 0;
        Room07.Play();
        Room08.volume = 0;
        Room08.Play();



        weather03.volume = 1;

    }
    
    public void SfxBoard(int Sfx)
    {
        SFXnumberint = Sfx;
        SoundBoard();
        SFXnumberint = 99;
    }

    public void RoomBoard(int Room)
    {
        Debug.Log("RoomBoard " + Room);
        roomnumberint = Room;
        SFXnumberint = 98;
        SoundBoard();

    }

    public void PuzzleBoard(int Puzzle)
    {
        Debug.Log("PuzzleBoard " + Puzzle);
        puzzlenumberint = Puzzle;
        SFXnumberint = 98;
        SoundBoard();

    }




    void SoundBoard()
    {



        if (SFXnumberint == 10)
        {
            weather03.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 1)
        {
            sfx01.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 2)
        {
            sfx02.volume = UnityEngine.Random.Range(0.6f, 1f);
            sfx02.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            sfx01.Stop();
            sfx02.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 3)
        {
            sfx03.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 4)
        {
            sfx04.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 5)
        {
            sfx05.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 6)
        {
            sfx06.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 7)
        {
            sfx07.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 8)
        {
            sfx08.Play();
            SFXnumberint = 0;
        }
        if (SFXnumberint == 9)
        {
            sfx09.volume = 0.25f;
            sfx09.Play();
            SFXnumberint = 0;
        }

        if (SFXnumberint != 99 && roomnumberint != currentroom)
        {
            StopAllCoroutines();
            currentroom = roomnumberint;
            RoomChange(currentroom);

        }

        if (SFXnumberint != 99 && puzzlenumberint != currentpuzzle)
        {
            StopAllCoroutines();
            currentpuzzle = puzzlenumberint;
            PuzzleChange(currentpuzzle);

        }
    }





    void RoomChange(int room)
    {
        if (room == 0)
        {

            AmbianceStop(Room01);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }

        if (room == 1)
        {

            AmbiancePlay(Room01);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }

        if (room == 2)
        {

            AmbiancePlay(Room02);
            AmbianceStop(Room01);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }
        if (room == 3)
        {

            AmbiancePlay(Room03);
            AmbianceStop(Room02);
            AmbianceStop(Room01);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }
        if (room == 4)
        {

            AmbiancePlay(Room04);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room01);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }
        if (room == 5)
        {

            AmbiancePlay(Room05);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room01);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }
        if (room == 6)
        {

            AmbiancePlay(Room06);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room01);
            AmbianceStop(Room07);
            AmbianceStop(Room08);

        }
        if (room == 7)
        {

            AmbiancePlay(Room07);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room01);
            AmbianceStop(Room08);

        }
        if (room == 8)
        {

            AmbiancePlay(Room08);
            AmbianceStop(Room02);
            AmbianceStop(Room03);
            AmbianceStop(Room04);
            AmbianceStop(Room05);
            AmbianceStop(Room06);
            AmbianceStop(Room07);
            AmbianceStop(Room01);

        }


    }



    void PuzzleChange(int puzzle)

    {
        if (puzzle == 0)
        {

            SoundPlay(puzzle01);
            SoundStop(puzzle02);
            SoundStop(puzzle03);
            SoundStop(puzzle04);
            SoundStop(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);

            SoundStop(weather01);
            SoundStop(weather02);
        }

        if (puzzle == 1)
        {

            SoundPlay(puzzle01);
            SoundStop(puzzle02);
            SoundStop(puzzle03);
            SoundStop(puzzle04);
            SoundStop(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);

            AmbiancePlay(weather01);
            AmbiancePlay(weather02);




        }

        if (puzzle == 2)
        {

            SoundPlay(puzzle01);
            SoundPlay(puzzle02);
            SoundStop(puzzle03);
            SoundStop(puzzle04);
            SoundStop(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);

        }

        if (puzzle == 3)
        {

            SoundPlay(puzzle01);
            SoundPlay(puzzle02);
            SoundPlay(puzzle03);
            SoundStop(puzzle04);
            SoundStop(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);

        }

        if (puzzle == 4)
        {

            SoundPlay(puzzle01);
            SoundPlay(puzzle02);
            SoundPlay(puzzle03);
            SoundPlay(puzzle04);
            SoundStop(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);

        }
        if (puzzle == 5)
        {

            SoundStop(puzzle01);
            SoundPlay(puzzle02);
            SoundPlay(puzzle03);
            SoundPlay(puzzle04);
            SoundPlay(puzzle05);
            SoundStop(puzzle06);
            SoundStop(puzzle07);
        }

        if (puzzle == 6)
        {

            SoundStop(puzzle01);
            SoundStop(puzzle02);
            SoundPlay(puzzle03);
            SoundPlay(puzzle04);
            SoundPlay(puzzle05);
            SoundPlay(puzzle06);
            SoundStop(puzzle07);

        }

        if (puzzle == 7)
        {

            SoundStop(puzzle01);
            SoundStop(puzzle02);
            SoundStop(puzzle03);
            SoundPlay(puzzle04);
            SoundPlay(puzzle05);
            SoundPlay(puzzle06);
            SoundPlay(puzzle07);

        }



    }
    void SoundPlayFX(AudioSource AudioCurrent)
    {

        AudioCurrent.Play();




    }
    void AmbiancePlay(AudioSource AudioCurrent)
    {


        if (AudioCurrent.volume < 1) StartCoroutine(FadeInAmbiance(AudioCurrent, 5.0f));



    }
    void AmbianceStop(AudioSource AudioCurrent)
    {

        if (AudioCurrent.volume > 0) StartCoroutine(FadeOut(AudioCurrent, 30.0f));


    }

    void SoundPlay(AudioSource AudioCurrent)
    {


        if (AudioCurrent.volume < 1) StartCoroutine(FadeIn(AudioCurrent, 30.0f));



    }

    void SoundStop(AudioSource AudioCurrent)
    {

        if (AudioCurrent.volume > 0) StartCoroutine(FadeOut(AudioCurrent, 5.0f));


    }

    IEnumerator FadeInAmbiance(AudioSource AudioCurrent, float aTime)
    {

        float step = 0.01f;
        for (float t = 0.0f; t < 1.0f; t += step)
        {
            AudioCurrent.volume = Mathf.Lerp(AudioCurrent.volume, 1f, t);
            yield return new WaitForSeconds(aTime * step);
            //print("IN" + AudioCurrent.volume);
        }
        AudioCurrent.volume = 1.0f;
        //print("IN ok" + AudioCurrent.volume);
    }


    IEnumerator FadeIn(AudioSource AudioCurrent, float aTime)
    {

        float step = 0.01f;
        for (float t = 0.0f; t < 1.0f; t += step)
        {
            AudioCurrent.volume = Mathf.Lerp(AudioCurrent.volume, 1f, t);
            yield return new WaitForSeconds(aTime * step);

        }
        AudioCurrent.volume = 1.0f;

    }

    IEnumerator FadeOut(AudioSource AudioCurrent, float aTime)
    {



        float step = 0.01f;
        for (float t = 0.0f; t < 1.0f; t += step)
        {
            AudioCurrent.volume = Mathf.Lerp(AudioCurrent.volume, 0f, t);
            yield return new WaitForSeconds(aTime * step);

            //print("OUT" + AudioCurrent.volume);
        }
        AudioCurrent.volume = 0.0f;


    }

}
