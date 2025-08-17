using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Engine.TileMap
{
    //This class is only for flat top
    //Flat top is superrior
    internal class HexTileMap
    {
        private static int hexWidth;
        private static int hexHeight;
        Vector2Int tileSize;
        int mapRadius;
        private Dictionary<(int q, int r), HexTile> tiles;
        private Vector2Int center; // Center of map that is being created
        List<HexTile> listOfCursorTile = new();
        HexTile tileSelctor;
        public HexTile guessTileSelecotor = null;

        HexTile closest = null;

        Camera camera;


        // Hay all. Erden here
        // Center is fucked up. And I don't know why fix it when you are bored
        // Basicly guessTileSelector is messed up by it when center is not (0,0)
        // also  guessTileSelector doesn't seem to be 100% accurate more like 95%? It's still a lot but the 5%
        public HexTileMap(int mapRadius, Vector2Int tileSize, Camera camera, Vector2Int center = default)
        {
            this.mapRadius = mapRadius;
            tiles = new Dictionary<(int q, int r), HexTile>();
            hexWidth = tileSize.X;
            hexHeight = tileSize.Y;
            this.tileSize = tileSize;
            Texture2D txt_Tile = GLOBALS.Content.Load<Texture2D>("Tile");
            this.camera = camera;
            tileSelctor = new HexTile(GLOBALS.Content.Load<Texture2D>("TileSelector"), Vector2.Zero, Color.White);
            guessTileSelecotor = new HexTile(GLOBALS.Content.Load<Texture2D>("TileSelector"), Vector2.Zero, Color.Orange);

            this.center = center;

            for (int q = -mapRadius; q <= mapRadius; q++)
            {
                for (int r = Math.Max(-mapRadius, -q - mapRadius); r <= Math.Min(mapRadius, -q + mapRadius); r++)
                {
                    tiles[(q, r)] = new HexTile(txt_Tile, center, q, r);
                    tiles[(q, r)].position = center + GetPixelPositionAtHex(q, r);
                }
            }


        }
        // This is for calculating position of tile based on cordinates of q=column and r=row
        private Vector2Int GetPixelPositionAtHex(int q, int r)
        {
            int x = (int)(hexWidth * 0.75f * q);
            int y = (int)(hexHeight * (r + q / 2.0f));
            return new Vector2Int(x, y);
        }

        private Vector2Int GetHexAtPixelPosition(int px, int py)
        {
            // Krok 1: Zamiana na float axial
            float qf = px / (hexWidth * 0.75f);
            float rf = (py / (float)hexHeight) - (qf / 2f);

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

            return new Vector2Int(q,r);
        }

        public void Update()
        {
            closest = null;
            //listOfCursorTile.Clear();
            //foreach (var tile in tiles)
            //{
            //    tile.Value.Update();
            //    if (tile.Value.TestPointHexagon(camera))
            //        listOfCursorTile.Add(tile.Value);
            //}

            Vector2Int mousePos = (Vector2Int)(Input.GetMousePositionToWorld(camera) - center);
            Vector2Int qrPos = GetHexAtPixelPosition(mousePos.X, mousePos.Y);

            guessTileSelecotor.isVisible = false;
            if (tiles.ContainsKey((qrPos.X, qrPos.Y)))
                guessTileSelecotor.isVisible = true;


            guessTileSelecotor.position = GetPixelPositionAtHex(qrPos.X, qrPos.Y);

            // Choosing closest tile you are picking when you are between two tiles
            //if (listOfCursorTile.Count > 0)
            //    closest = listOfCursorTile[0];
            
        }
        public void Draw()
        {
            foreach (var tile in tiles)
            {
                tile.Value.Draw();
            }
            // Cursor for tile
            if (closest != null)
            {
                tileSelctor.position = closest.position;
                tileSelctor.Draw();
            }
            guessTileSelecotor.Draw();
        }
    }

}
