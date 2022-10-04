using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public GameComponent game;
    public Camera cam;

    private void OnEnable()
    {
        GameComponent.OnUnitShot += OnUnitShot;
        GameComponent.OnChangeLivesUnit += OnChangeLivesUnit;
        GameComponent.OnCardClick += OnCardClick;
        GameComponent.OnTimer += OnTimer;
    }

    private void OnDisable()
    {
        GameComponent.OnUnitShot -= OnUnitShot;
        GameComponent.OnChangeLivesUnit -= OnChangeLivesUnit;
        GameComponent.OnCardClick -= OnCardClick;
        GameComponent.OnTimer -= OnTimer;
    }

    private void OnTimer()
    {
        PlayPitch(game.timerSound);
    }

    private void OnCardClick(CardComponent card)
    {
        if(card.cardType == CardType.Heal)
        {
            PlayPitch(game.healSound);
        }
        if (card.cardType == CardType.LevelUp)
        {
            PlayPitch(game.levelUpSound);
        }
        if (card.cardType == CardType.Unit)
        {
            PlayPitch(game.unitUpSound);
        }
    }

    private void OnChangeLivesUnit(UnitComponent unit)
    {
        if (unit.lives == 0)
        {
            PlayPitch(game.deathSound);
        }
    }

    private AudioSource PlayPitch(AudioClip sound)
    {
        var clip = PlayClipAt(sound, cam.transform.position);
        clip.pitch = Random.Range(0.9f, 1.4f);
        return clip;
    }

    private void OnUnitShot(UnitComponent arg1, UnitComponent arg2)
    {
        PlayPitch(game.shotSound).volume = 0.33f;
    }

    AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio"); // create the temp object
        tempGO.transform.position = pos; // set its position
        AudioSource aSource = tempGO.AddComponent<AudioSource>(); // add an audio source
        aSource.clip = clip; // define the clip
                             // set other aSource properties here, if desired
        aSource.Play(); // start the sound
        Destroy(tempGO, clip.length); // destroy object after clip duration
        return aSource; // return the AudioSource reference
    }
}
