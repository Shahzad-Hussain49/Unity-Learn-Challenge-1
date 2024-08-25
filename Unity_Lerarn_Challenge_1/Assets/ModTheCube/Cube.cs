using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float rotationSpeed = 5f;
    public float colorChangeSpeed = 2f; // Speed of color change

    private Material material;
    private Color targetColor;
    private float colorChangeTime = 0f;
    private Vector3 initialPosition;
    private Vector3 initialScale;

    void Start()
    {
        // Randomize position
        transform.position = Vector3.one * Random.Range(-10f, 10f);
        // Randomize scale
        transform.localScale = Vector3.one * Random.Range(1f, 5f);
        // Initialize material and randomize color
        material = Renderer.material;
        material.color = new Color(Random.value, Random.value, Random.value, 1f);

        // Set a new random target color for the transition
        SetNewTargetColor();
    }

    void Update()
    {
        // Rotate the cube
        transform.Rotate(
            15.0f * Time.deltaTime * rotationSpeed,
            30.0f * Time.deltaTime * rotationSpeed,
            45.0f * Time.deltaTime * rotationSpeed
        );

        // Smoothly transition the color
        colorChangeTime += Time.deltaTime * colorChangeSpeed;
        material.color = Color.Lerp(material.color, targetColor, colorChangeTime);

        // Check if the color transition is complete
        if (colorChangeTime >= 1f)
        {
            SetNewTargetColor(); // Set a new target color when the transition is complete
            colorChangeTime = 0f; // Reset the timer
        }
    }

    void SetNewTargetColor()
    {
        targetColor = new Color(Random.value,Random.value,Random.value,1f);
    }
}
