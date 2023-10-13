using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    GameObject player; //Reference to the player so we can track its positive
    Renderer rend; //Reference to the Renderer so we can modify its texture

    float playerStartPos; //Float used to track the starting position of the player
    public float speed = 0.5f; //How fast should we scroll? We change this for each layyer
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character"); //Find the Player
        rend = GetComponent<Renderer>(); //Find the renerer
        playerStartPos = player.transform.position.x; //Save our starting position
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - playerStartPos) * speed;
        //^^^^^^^^^^^^^^^^^^^This line finds out much to offset the texture by.
        //We do this by subtractingour starting X position from our current X position
        //We then multiply the offset by the speed, so that we can have different layers
        //moving at different speeds


        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
        //^^^^^^^^^^^^^^^^^^^This line ses our textures 'offset'. We use the 
        //SetTextureOffset method to do this, which takes 2 parameters.
        //The first parameter is a string that refers tothe texture we want to modify
        //The second parameter is a Vector2, with the first (X) variable shifting texture
        //left and right, and the second (Y) variable shifting the texture up and down
    }
}