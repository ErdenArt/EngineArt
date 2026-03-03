using System;
using System.Collections.Generic;
using System.Diagnostics;
using EngineArt.Drawings;
using EngineArt.Mathematic;

namespace EngineArt.TileMap
{
    /// <summary>
    /// This class is only for flat top. <br></br>
    /// Flat top is superrior
    /// </summary>
    public class HexTileMap
    {
        private Dictionary<(int q, int r), HexTile> tiles;
        private Vector2 center; // Center of map that is being created
        public HexTile tileSelctor;
        public Vector2 wishPosition;
        public Atlas atlas;
        /// <summary>
        /// Create hexagon map
        /// </summary>
        /// <param name="hexagon">Sizing of hexagon</param>
        /// <param name="sprites">Atlas of every possible tile</param>
        /// <param name="tileSelectorTextureFromAtlas">Cursor or tile selector that you need to specify from atlas</param>
        /// <param name="mapRadius">How big is the map</param>
        /// <param name="center">Position of center of tilemap</param>
        public HexTileMap(HexTile hexagon, Atlas sprites, string tileSelectorTextureFromAtlas, int mapRadius, Vector2 center = default)
        {
            Texture2D txt_Tile = sprites.FirstTexture();
            this.center = center;
            this.atlas = sprites;
            this.tiles = new Dictionary<(int q, int r), HexTile>();
            this.tileSelctor = new HexTile(sprites.GetTexture(tileSelectorTextureFromAtlas), 
                                      Vector2.Zero, 
                                      hexagon.txtTriangleSize, 
                                      hexagon.squareWidth, 
                                      hexagon.squareHight, 
                                      hexagon.triangleWidth, 
                                      0,0); //QR for selector is not important

            for (int q = -mapRadius; q <= mapRadius; q++)
            {
                for (int r = Math.Max(-mapRadius, -q - mapRadius); r <= Math.Min(mapRadius, -q + mapRadius); r++)
                {
                    Vector2 tilePos = center + GetPixelPositionAtHex(q, r);
                    tiles[(q, r)] = new HexTile(txt_Tile, 
                                                tilePos, 
                                                hexagon.txtTriangleSize, 
                                                hexagon.squareWidth, 
                                                hexagon.squareHight, 
                                                hexagon.triangleWidth, 
                                                q, r);
                }
            }


        }
        // This is for calculating position of tile based on cordinates of q=column and r=row
        public Vector2Int GetPixelPositionAtHex(int q, int r)
        {
            int x = (int)(tileSelctor.hexWidth * 0.75f * q);
            int y = (int)(tileSelctor.hexHight * (r + q / 2.0f));
            return new Vector2Int(x, y);
        }

        public Vector2Int GetHexAtPixelPosition(int px, int py)
        {
            // Krok 1: Zamiana na float axial
            float qf = px / (tileSelctor.hexWidth * 0.75f);
            float rf = (py / tileSelctor.hexHight) - (qf / 2f);

            // Krok 2: Zamiana na cube coords
            float x = qf;
            float z = rf;
            float y = -x - z;

            // Krok 3: Zaokrąglenie cube
            int rx = (int)Math.Round(x);
            int ry = (int)Math.Round(y);
            int rz = (int)Math.Round(z);

            float dx = Math.Abs(rx - x);
            float dy = Math.Abs(ry - y);
            float dz = Math.Abs(rz - z);

            if (dx > dy && dx > dz)
                rx = -ry - rz;
            else if (dy > dz)
                ry = -rx - rz;
            else
                rz = -rx - ry;

            // Krok 4: Powrót do axial
            int q = rx;
            int r = rz;

            return new Vector2Int(q, r);
        }

        public void UpdateCursor(Vector2 cursorPos)
        {
            Vector2Int mousePos = (Vector2Int)(cursorPos - center);
            Vector2Int qrPos = GetHexAtPixelPosition(mousePos.X, mousePos.Y);

            wishPosition = GetPixelPositionAtHex(qrPos.X, qrPos.Y);
            tileSelctor.Q = qrPos.X;
            tileSelctor.R = qrPos.Y;
            tileSelctor.Position = Vector2.Lerp(tileSelctor.Position, wishPosition, 0.8f);

            // Choosing closest tile you are picking when you are between two tiles
            //if (listOfCursorTile.Count > 0)
            //    closest = listOfCursorTile[0];

        }
        public void ChangeTile(int value)
        {
            Vector2Int mousePos = (Vector2Int)(wishPosition - center);
            Vector2Int qrPos = GetHexAtPixelPosition(mousePos.X, mousePos.Y);

            if (tiles.ContainsKey((qrPos.X, qrPos.Y)))
            {
                tiles[(qrPos.X, qrPos.Y)].tileType = value;
                tiles[(qrPos.X, qrPos.Y)].Texture = atlas.GetTexture(value);
            }
        }
        public Dictionary<(int q, int r), HexTile> GetHexTiles()
        {
            return tiles;
        }
        public void Draw(float depthLayer = 0)
        {
            foreach (var tile in tiles)
            {
                tile.Value.Draw(depthLayer);
            }
            // Cursor for tile
            tileSelctor.Draw(depthLayer + 1);
        }
    }

}
