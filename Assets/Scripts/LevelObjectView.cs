using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectView : MonoBehaviour
{
    //public SpriteRenderer SpriteRenderer;
   // public Transform Transform;
    //public Collider2D Collider2D;
    //public Rigidbody2D Rigidbody2D;
    public Action<LevelObjectView> OnLevelObjectContact { get; set; }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<CharacterView>();
        //OnLevelObjectContact?.Invoke(levelObject);
        if (levelObject != null)
        {
            OnLevelObjectContact?.Invoke(this);

            Debug.Log("YOU WIN!");
            Time.timeScale = 0;

        }


    }
}
