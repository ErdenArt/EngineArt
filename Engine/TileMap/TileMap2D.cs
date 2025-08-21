using System.Diagnostics;

namespace Engine.TileMap
{
    public class TileMap2D
    {
        Dictionary<Rectangle, int> tiles;
        Vector2 tileMapPosition;
        Vector2Int tileSize;
        Texture2D texture;
        int widthOfTile;
        int maxWidth;

        public bool visible;
        public Color colorOfTiles = Color.White;
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
            this.tiles = new Dictionary<Rectangle, int>();
            this.tileSize = tileSize;
            this.tileMapPosition = tileMapPosition;
            this.texture = textureTiles;
            this.widthOfTile = widthOfTile;
            this.maxWidth = textureTiles.Width / widthOfTile;
            this.visible = visible;

            StreamReader reader = new StreamReader(fileCSV);
            if (reader == null) throw new Exception("This CSV file does not exist");
            string line;
            int y = 0; // How far down are we

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                for (int i = 0; i < items.Length; i++)
                {
                    if (int.TryParse(items[i], out int value))
                    {
                        if (value != -1)
                        {
                            tiles.Add(new Rectangle(i * tileSize.Width + tileMapPosition.ToPoint().X, y * tileSize.Height + tileMapPosition.ToPoint().Y, tileSize.Width, tileSize.Height), value);
                        }
                    }
                }
                y++;
            }
        }
        public TileMap2D(Vector2 tileMapPosition, Texture2D textureTiles, Vector2Int tileSize, int widthOfTile, Vector2Int tilemapSize, bool visible = true)
        {
            this.tiles = new Dictionary<Rectangle, int>();
            this.tileSize = tileSize;
            this.tileMapPosition = tileMapPosition;
            this.texture = textureTiles;
            this.widthOfTile = widthOfTile;
            this.maxWidth = textureTiles.Width / widthOfTile;
            this.visible = visible;

            for (int i = 0; i < tilemapSize.Width; i++)
            {
                for (int j = 0; j < tilemapSize.Height; j++)
                {
                    tiles.Add(new Rectangle(i * tileSize.Width + tileMapPosition.ToPoint().X, j * tileSize.Height + tileMapPosition.ToPoint().Y, tileSize.Width, tileSize.Height), 0);
                }
            }
        }
        public void Update(Camera camera)
        {
            Vector2Int tilePicked = (Vector2Int)((Input.GetMousePositionToWorld(camera) - tileMapPosition) / tileSize);
        }
        public void Draw()
        {
            if (visible == false) return;

            foreach (var tile in tiles)
            {
                GLOBALS.SpriteBatch.Draw(texture, tile.Key, new Rectangle(tile.Value % maxWidth * widthOfTile, tile.Value / maxWidth * widthOfTile, widthOfTile, widthOfTile), colorOfTiles, 0f, Vector2.Zero, SpriteEffects.None, 0);
                //Debug.WriteLine(new Vector2(tile.Value % maxWidth * widthOfTile, tile.Value / maxWidth * widthOfTile));
            }
        }
        public Rectangle[] GetCollision()
        {
            Rectangle[] result = new Rectangle[tiles.Count];
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
        public bool TryGetCloseTile(Vector2 pos, out (Rectangle, int) tile)
        {
            pos -= tileMapPosition;
            Rectangle result = new Rectangle((int)Math.Floor(pos.X / tileSize.Width) * tileSize.Height, (int)Math.Floor(pos.Y / tileSize.Height) * tileSize.Width, widthOfTile, widthOfTile);
            Debug.WriteLine(result);
            
            if (tiles.TryGetValue(result, out var value))
            {
                tile = (result, tiles[result]);
                return true;
            }
            tile = (Rectangle.Empty, 0);
            return false;

        }
        public void RemoveTile(Rectangle tileToDelete)
        {
            tiles.Remove(tileToDelete);
        } 
    }
}
