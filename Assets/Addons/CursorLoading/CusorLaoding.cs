using UnityEngine;

public class CusorLaoding : MonoBehaviour
{
    public Texture2D leftlidertatian;
    public Texture2D leftdemocratian;
    public Texture2D leftavtoriarian;
    public Texture2D mindlidertatian;
    public Texture2D minddemocratian;
    public Texture2D mindavtoriarian;
    public Texture2D rightlidertatian;
    public Texture2D rightdemocratian;
    public Texture2D rightavtoriarian;
    void Start()
    {
        if (PolitDate.IsVersionF() == politicfreedom.avtoritatian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(mindavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftavtoriarian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
        if (PolitDate.IsVersionF() == politicfreedom.democratian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightdemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(minddemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftdemocratian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
        if (PolitDate.IsVersionF() == politicfreedom.lidertatian)
        {
            if (PolitDate.IsVersionE() == politiceconomic.right)
            {
                Cursor.SetCursor(rightlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.mind)
            {
                Cursor.SetCursor(mindlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
            if (PolitDate.IsVersionE() == politiceconomic.left)
            {
                Cursor.SetCursor(leftlidertatian, new Vector2(1, 1), CursorMode.Auto);
            }
        }
    }
}
