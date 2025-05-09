using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collisionObject)
    {
        switch (collisionObject.gameObject.tag)
        {
            case "StartingPoint":
                Debug.Log("Start the Rocket");
                break;
            case "EndingPoint":
                Debug.Log("You Reached");
                break;
            case "Destroyer":
                Debug.Log("You Lost");
                break;
        }
    }
}
