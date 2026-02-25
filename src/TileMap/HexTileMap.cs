using System;
using System.Collections.Generic;
using EngineArt.Mathematic;

namespace EngineArt.TileMap
{
    //This class is only for flat top
    //Flat top is superrior
    //public class HexTileMap
    //{        
    //    private Dictionary<(int q, int r), HexTile> tiles;
    //    private Vector2 center; // Center of map that is being created
    //    HexTile tileSelctor;

    //    public HexTileMap(HexTile hexagon, int sizeOfTileMap, Vector2 center = default)
    //    {
    //        tiles = new Dictionary<(int q, int r), HexTile>();
    //        Texture2D txt_Tile = GLOBALS.Content.Load<Texture2D>("Tile");
    //        tileSelctor = new HexTile(GLOBALS.Content.Load<Texture2D>("TileSelector"), Vector2.Zero, Color.White);
    //        guessTileSelecotor = new HexTile(GLOBALS.Content.Load<Texture2D>("TileSelector"), Vector2.Zero, Color.Orange);

            
    //        this.center = center;

    //        for (int q = -mapRadius; q <= mapRadius; q++)
    //        {
    //            for (int r = Math.Max(-mapRadius, -q - mapRadius); r <= Math.Min(mapRadius, -q + mapRadius); r++)
    //            {
    //                tiles[(q, r)] = new HexTile(txt_Tile, center, q, r);
    //                tiles[(q, r)].Position = center + GetPixelPositionAtHex(q, r);
    //            }
    //        }


    //    }
    //    // This is for calculating position of tile based on cordinates of q=column and r=row
    //    private Vector2Int GetPixelPositionAtHex(int q, int r)
    //    {
    //        int x = (int)(hexWidth * 0.75f * q);
    //        int y = (int)(hexHeight * (r + q / 2.0f));
    //        return new Vector2Int(x, y);
    //    }

    //    private Vector2Int GetHexAtPixelPosition(int px, int py)
    //    {
    //        // Krok 1: Zamiana na float axial
    //        float qf = px / (hexWidth * 0.75f);
    //        float rf = (py / (float)hexHeight) - (qf / 2f);

    //        // Krok 2: Zamiana na cube coords
    //        float x = qf;
    //        float z = rf;
    //        float y = -x - z;

    //        // Krok 3: Zaokrąglenie cube
    //        int rx = (int)Math.Round(x);
    //        int ry = (int)Math.Round(y);
    //        int rz = (int)Math.Round(z);

    //        float dx = Math.Abs(rx - x);
    //        float dy = Math.Abs(ry - y);
    //        float dz = Math.Abs(rz - z);

    //        if (dx > dy && dx > dz)
    //            rx = -ry - rz;
    //        else if (dy > dz)
    //            ry = -rx - rz;
    //        else
    //            rz = -rx - ry;

    //        // Krok 4: Powrót do axial
    //        int q = rx;
    //        int r = rz;

    //        return new Vector2Int(q,r);
    //    }

    //    public void Update()
    //    {
    //        closest = null;
    //        //listOfCursorTile.Clear();
    //        //foreach (var tile in tiles)
    //        //{
    //        //    tile.Value.Update();
    //        //    if (tile.Value.TestPointHexagon(camera))
    //        //        listOfCursorTile.Add(tile.Value);
    //        //}

    //        Vector2Int mousePos = (Vector2Int)(Input.GetMousePositionToWorld(camera) - center);
    //        Vector2Int qrPos = GetHexAtPixelPosition(mousePos.X, mousePos.Y);

    //        guessTileSelecotor.isVisible = false;
    //        if (tiles.ContainsKey((qrPos.X, qrPos.Y)))
    //            guessTileSelecotor.isVisible = true;


    //        guessTileSelecotor.position = GetPixelPositionAtHex(qrPos.X, qrPos.Y);

    //        // Choosing closest tile you are picking when you are between two tiles
    //        //if (listOfCursorTile.Count > 0)
    //        //    closest = listOfCursorTile[0];
            
    //    }
    //    public void Draw()
    //    {
    //        foreach (var tile in tiles)
    //        {
    //            tile.Value.Draw();
    //        }
    //        // Cursor for tile
    //        if (closest != null)
    //        {
    //            tileSelctor.position = closest.position;
    //            tileSelctor.Draw();
    //        }
    //        guessTileSelecotor.Draw();
    //    }
    //}

}
