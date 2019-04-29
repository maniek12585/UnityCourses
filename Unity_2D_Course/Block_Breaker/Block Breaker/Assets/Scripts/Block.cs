using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //config params
    [SerializeField] private AudioClip clipOnDestroy;
    [SerializeField] private GameObject blockSparklesVFX;
     private int maxHits;
    [SerializeField] private Sprite[] hitSprites;
    //cached reference
    Level level;
    AudioSource myAudioSource;
    //state variables
    [SerializeField] int timesHit; // serialized for debug purposes

    private void Start() 
    {
      maxHits = hitSprites.Length+1 ;
      CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
         level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
        level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        //int maxHits = hitSprites.Length+1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit -1;
        if(hitSprites[spriteIndex] != null)
        {
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" +" "+ gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        
        PlayBlockSFX();
        TriggerSparklesVFX();
        Destroy(gameObject);
        level.BlockDestroyed();    
        
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position ,transform.rotation);
        Destroy(sparkles,2f);
    }

    private void PlayBlockSFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(clipOnDestroy, Camera.main.transform.position);
    }
}
