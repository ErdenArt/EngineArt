using System.Diagnostics;
using EngineArt.Mathematic;

namespace EngineArt.TileMap
{
    public class TileMap2D
    {
        Dictionary<Collider, int> tiles;
        Vector2 tileMapPosition;
        Vector2Int tileSize;
        Texture2D texture;
        int widthOfTile;
        int maxWidth;

        public bool visible;
        public Color[] colorOfTiles;
        // tileMapPosition = top left corner that start drawing
        // textureTiles = File that textures will inherit to drawing
        // tileSize = How big is one tile
        // sizeOfTileTexture = Size of one tile in texture
        // fileCSV = File holding data of each pixel position

        /// <summary>
        /// Creates square tilemap.
        /// </summary>
        ///   <param name="tileMapPosition">Top left corner that start drawing.</param>
        ///      <param name="textureTiles">File that textures will inherit to drawing.</param>
        ///          <param name="tileSize">How big is one tile on screen</param>
        ///       <param name="widthOfTile">Width of tile in texture</param>
        ///           <param name="fileCSV">File holding data of each pixel position</param>
        public TileMap2D(Vector2 tileMapPosition, Texture2D textureTiles, Vector2Int tileSize, int widthOfTile, string fileCSV, bool visible = true)
        {
            this.tiles = new Dictionary<Collider, int>();
            this.tileSize = tileSize;
            this.tileMapPosition = tileMapPosition;
            this.texture = textureTiles;
            this.widthOfTile = widthOfTile;
            this.maxWidth = textureTiles.Width / widthOfTile;
            this.visible = visible;

            StreamReader reader = ReadData.Read_Embedded_CSV(fileCSV);
            string line;
            int y = 0; // How far down are we

            while ((line = reader.ReadLine()!) != null)
            {
                string[] items = line.Split(',');
                for (int i = 0; i < items.Length; i++)
                {
                    if (int.TryParse(items[i], out int value))
                    {
                        if (value != -1)
                        {
                            tiles.Add(new Collider(i * tileSize.Width + tileMapPosition.ToPoint().X, y * tileSize.Height + tileMapPosition.ToPoint().Y, tileSize.Width, tileSize.Height), value);

                            Debug.WriteLine($"{(i * tileSize.Width + tileMapPosition.ToPoint().X, y * tileSize.Height + tileMapPosition.ToPoint().Y, tileSize.Width, tileSize.Height)}");
                        }
                    }
                }
                y++;
            }
            colorOfTiles =  new Color[1] {Color.White};
        }
        public TileMap2D(Vector2 tileMapPosition, Texture2D textureTiles, Vector2Int tileSize, int widthOfTile, Vector2Int tilemapSize, bool visible = true, Color[] colors = null)
        {
            this.tiles = new Dictionary<Collider, int>();
            this.tileSize = tileSize;
            this.tileMapPosition = tileMapPosition;
            this.texture = textureTiles;
            this.widthOfTile = widthOfTile;
            this.maxWidth = textureTiles.Width / widthOfTile;
            if (maxWidth == 0) maxWidth = 1;
            this.visible = visible;

            for (int i = 0; i < tilemapSize.Width; i++)
            {
                for (int j = 0; j < tilemapSize.Height; j++)
                {
                    tiles.Add(new Collider(i * tileSize.Width + tileMapPosition.ToPoint().X, j * tileSize.Height + tileMapPosition.ToPoint().Y, tileSize.Width, tileSize.Height), 0);
                }
            }

            if (colors == null)
                colorOfTiles = new Color[1] { Color.White };
            else
                colorOfTiles = colors;
        }
        public void Update(Camera camera)
        {
            Vector2Int tilePicked = (Vector2Int)((Input.GetMousePositionToWorld(camera) - tileMapPosition) / tileSize);
        }
        public void Draw()
        {
            if (visible == false) return;

            int tileCount = 0;
            foreach (var tile in tiles)
            {
                GLOBALS.SpriteBatch.Draw(texture, tile.Key.ToRectangle(), new Rectangle(tile.Value % maxWidth * widthOfTile, tile.Value / maxWidth * widthOfTile, widthOfTile, widthOfTile), colorOfTiles[tileCount % colorOfTiles.Length], 0f, Vector2.Zero, SpriteEffects.None, 0);
                tileCount++;
                //Debug.WriteLine(new Vector2(tile.Value % maxWidth * widthOfTile, tile.Value / maxWidth * widthOfTile));
            }
        }
        public Collider[] GetCollision()
        {
            Collider[] result = new Collider[tiles.Count];
            int i = 0;
            foreach (var tile in tiles)
            {
                result[i] = tile.Key;
                i++;
            }
            return result;
        }
/// <summary>
/// Gets tile that is closest based on coordinates. In other words it rounds coordinates to tile position
/// </summary>
/// <returns>Rectangle of tile</returns>
        public bool TryGetCloseTile(Vector2 pos, out (Collider, int) tile)
        {
            pos -= tileMapPosition;
            Collider result = new Collider((int)Math.Floor(pos.X / tileSize.Width) * tileSize.Height, (int)Math.Floor(pos.Y / tileSize.Height) * tileSize.Width, widthOfTile, widthOfTile);
            Debug.WriteLine(result);
            
            if (tiles.TryGetValue(result, out var value))
            {
                tile = (result, tiles[result]);
                return true;
            }
            tile = (Collider.Empty, 0);
            return false;

        }
        public void RemoveTile(Collider tileToDelete)
        {
            tiles.Remove(tileToDelete);
        } 
    }
}
