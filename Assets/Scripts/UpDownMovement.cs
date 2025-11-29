using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2f;       // Hareket hýzý
    public float amplitude = 1f;   // Yukarý-aþaðý ne kadar hareket edecek

    private float startY;

    void Start()
    {
        startY = transform.position.y;  // Baþlangýç yüksekliðini kaydet
    }

    void Update()
    {
        float newY = startY + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
