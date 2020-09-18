using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroys a game object.
/// </summary>
public class DestroyGameObject : MonoBehaviour
{
    public float timer = 3;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = timer;
            gameObject.SetActive(false);
            
        }
       // Destroy(gameObject, 2f);
    }
}
