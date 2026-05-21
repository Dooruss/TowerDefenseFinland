using UnityEngine;

public class mouseManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private Vector2 cursorHotspot;

    public bool useCustomCursor = false;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);

        SetCursor();
    }

    private void Update()
    {
        SetCursor();
    }

    void SetCursor()
    {
        if (useCustomCursor)
        {
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            // Reset to default cursor
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}