using System.Diagnostics;

namespace Engine.TileMap
{
    internal class HexTile : Sprite
    {
        enum TileType
        {
            Grass = 0,
            Water = 1,
            Sand = 2
        }
        public int Q, R;
        Color color;
        public Vector2Int QRPosition { get { return new Vector2Int(Q, R); } }
        public HexTile(Texture2D texture, Vector2 position, Color color) : base(texture, position)
        {
            this.color = color;
        }
        public HexTile(Texture2D texture, Vector2 position, int q, int r) : base(texture, position)
        {
            Q = q;
            R = r;
            color = Color.White;
        }
        public void Update()
        {

        }
        public bool TestPointHexagon(Camera camera)
        {
            //This needs to be changed if tiles are in diffrent size
            //You just pass every corner of HexTile
            Vector2 leftCorner = new Vector2(-18, 0);
            Vector2 rightCorner = new Vector2(18, 0);
            Vector2 topLeftCorner = new Vector2(-9, -11);
            Vector2 topRightCorner = new Vector2(9, -11);
            Vector2 bottomLeftCorner = new Vector2(-9, 11);
            Vector2 bottomRightCorner = new Vector2(9, 11);
            Texture2D txt_Tile = GLOBALS.Content.Load<Texture2D>("Tile");
            Texture2D txt_DryTile = GLOBALS.Content.Load<Texture2D>("DryTile");

            Point cursor = (Point)Input.GetMousePositionToWorld(camera) - drawPosition;
            texture = txt_Tile;

            if (cursor.X > leftCorner.X && cursor.X < rightCorner.X &&
                cursor.Y < bottomLeftCorner.Y && cursor.Y > topLeftCorner.Y)
            {
                Vector2 rotTeto_topLeft = Rotate(topLeftCorner - leftCorner, 90);
                Vector2 dir_topLeft = new Vector2(cursor.X - topLeftCorner.X, cursor.Y - topLeftCorner.Y);

                Vector2 rotTeto_topRight = Rotate(topRightCorner - rightCorner, -90);
                Vector2 dir_topRight = new Vector2(cursor.X - topRightCorner.X, cursor.Y - topRightCorner.Y);

                Vector2 rotTeto_botLeft = Rotate(bottomLeftCorner - leftCorner, -90);
                Vector2 dir_botLeft = new Vector2(cursor.X - bottomLeftCorner.X, cursor.Y - bottomLeftCorner.Y);

                Vector2 rotTeto_botRight = Rotate(bottomRightCorner - rightCorner, 90);
                Vector2 dir_botRight = new Vector2(cursor.X - bottomRightCorner.X, cursor.Y - bottomRightCorner.Y);

                if (Vector2.Dot(Vector2.Normalize(rotTeto_topLeft), Vector2.Normalize(dir_topLeft)) > 0 &&
                    Vector2.Dot(Vector2.Normalize(rotTeto_topRight), Vector2.Normalize(dir_topRight)) > 0 &&
                    Vector2.Dot(Vector2.Normalize(rotTeto_botLeft), Vector2.Normalize(dir_botLeft)) > 0 &&
                    Vector2.Dot(Vector2.Normalize(rotTeto_botRight), Vector2.Normalize(dir_botRight)) > 0)
                {
                    return true;
                }
            }
            return false;

        }

        private const double DegToRad = Math.PI / 180;
        Vector2 Rotate(Vector2 v, double degrees)
        {
            return RotateRadians(v, degrees * DegToRad);
        }

        Vector2 RotateRadians(Vector2 v, double radians)
        {
            float ca = (float)Math.Cos(radians);
            float sa = (float)Math.Sin(radians);
            return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }
}
