using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsComing : MonoBehaviour
{
    public AudioClip[] monstercoming;
    public AudioSource monstercomeSource;
    private float iscomingRate;
    private float iscomingTime;
    private float startTime;

    void Start()
    {
        monstercomeSource = GetComponent<AudioSource>();
        startTime = Time.time;
        iscomingRate = 60f;
    }

    void Update()
    {
        if (monstercomeSource == null || monstercoming.Length == 0)
            return;

        float elapsedTime = Time.time - startTime;

        if (elapsedTime < 60f)
        {
            iscomingRate = 60f;
        }
        else if (elapsedTime < 90f)
        {
            iscomingRate = 55f;
        }
        else if (elapsedTime < 100f)
        {
            iscomingRate = 50f;
        }
        else if (elapsedTime < 105f)
        {
            iscomingRate = 45f;
        }
        else if (elapsedTime < 106f)
        {
            iscomingRate = 30f;
        }
        else if (elapsedTime < 1200f)
        {
            iscomingRate = Mathf.Lerp(1f, 0.3f, (elapsedTime - 106f) / (1200f - 106f));
        }
        else
        {
            iscomingRate = 0.3f;
        }

        if (Time.time - iscomingTime > iscomingRate)
        {
            iscomingTime = Time.time;
            monstercomeSource.PlayOneShot(monstercoming[Random.Range(0, monstercoming.Length)]);
        }
    }
}
