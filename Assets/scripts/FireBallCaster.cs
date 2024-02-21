using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCuster : MonoBehaviour
{
    public Transform FireBallSourceTransform;
    public FireBall fireballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, FireBallSourceTransform.position, FireBallSourceTransform.rotation);
        }
    }
}
