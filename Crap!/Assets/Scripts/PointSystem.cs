using UnityEngine;

public class PointSystem : MonoBehaviour
{
    public int counter = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Something to make the counter go up (+1 heaven point)
            counter++;

        } else if(Input.GetKeyDown(KeyCode.Q))
        {
            // Something to make the counter go down (+1 hell point)
            counter--;
        }
    }
}
