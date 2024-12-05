using UnityEngine;

public enum ColorBlindMode
{
    Normal = 0,
    Protanopia = 1,
    Deuteranopia = 2,
    Tritanopia = 3,
    Achromatopsia = 4,
}

[ExecuteInEditMode]
public class ColorBlindFilter : MonoBehaviour
{
    public ColorBlindMode mode = ColorBlindMode.Normal;
    private ColorBlindMode previousMode = ColorBlindMode.Normal;

    public bool showDifference = false;

    private Material material;

    private static Color[,] RGB =
    {
        { new Color(1f,0f,0f),   new Color(0f,1f,0f), new Color(0f,0f,1f) },    // Normal
        { new Color(.56667f, .43333f, 0f), new Color(.55833f, .44167f, 0f), new Color(0f, .24167f, .75833f) },    // Protanopia
        { new Color(.625f, .375f, 0f), new Color(.70f, .30f, 0f), new Color(0f, .30f, .70f)    },   // Deuteranopia
        { new Color(.95f, .05f, 0), new Color(0f, .43333f, .56667f), new Color(0f, .475f, .525f) }, // Tritanopia
        { new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f), new Color(.299f, .587f, .114f)  },   // Achromatopsia
    };


    void Awake()
    {
        material = new Material(Shader.Find("Hidden/ChannelMixer"));
        material.SetColor("_R", RGB[0, 0]);
        material.SetColor("_G", RGB[0, 1]);
        material.SetColor("_B", RGB[0, 2]);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // No effect
        if (mode == ColorBlindMode.Normal)
        {
            Graphics.Blit(source, destination);
            return;
        }

        // Change effect
        if (mode != previousMode)
        {
            material.SetColor("_R", RGB[(int)mode, 0]);
            material.SetColor("_G", RGB[(int)mode, 1]);
            material.SetColor("_B", RGB[(int)mode, 2]);
            previousMode = mode;
        }

        // Apply effect
        Graphics.Blit(source, destination, material, showDifference ? 1 : 0);
    }
}