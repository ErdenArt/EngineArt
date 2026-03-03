using System;
using EngineArt.Drawings;
using EngineArt.Mathematic;

namespace EngineArt.TileMap
{
    public class HexTile : Sprite
    {
        // They are defining size of hexagon
        internal float squareWidth, squareHight, triangleWidth;

        // How big is triangle in texture in width
        internal int txtTriangleSize;

        // Size of hexagon
        internal float hexWidth, hexHight;

        // Can be used to store info
        public int tileType;
        // Position Q-column R-row
        public int Q, R;
        internal Vector2Int QRPosition => new Vector2Int(Q, R);

        /// <summary>
        /// Creates preset for hex tilemap
        /// </summary>
        /// <param name="txtTriangleSize">Width of single triangle of single sprite in atlas</param>
        /// <param name="squareWidth">Hexagon inner square width</param>
        /// <param name="squareHight">Hexagon inner square hight</param>
        /// <param name="triangleWidth">Hexagon inner triangle width</param>
        public HexTile(int txtTriangleSize, float squareWidth, float squareHight, float triangleWidth) : base(texture: NO_TEXTURE)
        {
            this.squareWidth = squareWidth;
            this.squareHight = squareHight;
            this.triangleWidth = triangleWidth;
            this.txtTriangleSize = txtTriangleSize;

            hexWidth = squareWidth + triangleWidth * 2;
            hexHight = squareHight;
        }
        internal HexTile(Texture2D texture, Vector2 position, int txtTriangleSize, float squareWidth, float squareHight, float triangleWidth, int q, int r) : base(texture)
        {
            this.squareWidth = squareWidth;
            this.squareHight = squareHight;
            this.triangleWidth = triangleWidth;
            this.txtTriangleSize = txtTriangleSize;
            this.Position = position;

            hexWidth = squareWidth + triangleWidth * 2;
            hexHight = squareHight;

            Q = q;
            R = r;
        }
        internal void UpdateSize(float squareWidth, float squareHight, float triangleWidth)
        {
            this.squareWidth = squareWidth;
            this.squareHight = squareHight;
            this.triangleWidth = triangleWidth;
        }
        Vector2 Rotate(Vector2 v, float degrees)
        {
            return RotateRadians(v, MathHelper.ToRadians(degrees));
        }

        Vector2 RotateRadians(Vector2 v, float radians)
        {
            float ca = (float)Math.Cos(radians);
            float sa = (float)Math.Sin(radians);
            return new Vector2(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }
}
