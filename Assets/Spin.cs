using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 90f; // 90 degrees per second
    
    void Update()
    {
        // This will spin the coin around its forward axis (like a wheel)
        //transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        
        // Alternatively, you could use the right axis:
         transform.Rotate(Vector3.right * spinSpeed * Time.deltaTime);
    }
}