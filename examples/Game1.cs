using EngineArt;
using EngineArt.Mathematic;

// This is how Game1 should be set up.
// Whole project should have access to each thing at any time so you make Graphics, Content, SpriteBatch etc... GLOBAL

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    // GameManager gameManager;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = GLOBALS.WindowSize.X;
        _graphics.PreferredBackBufferHeight = GLOBALS.WindowSize.Y;
        _graphics.ApplyChanges();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        GLOBALS.Game = this;
        GLOBALS.Graphics = _graphics;
        GLOBALS.Content = Content;
        GLOBALS.GraphicsDevice = GraphicsDevice;
        GLOBALS.SpriteBatch = _spriteBatch;
        GLOBALS.Pixel = GLOBALS.CreateWhitePixel(GraphicsDevice);
        GLOBALS.Font = Content.Load<SpriteFont>("Font");
        //gameManager = new GameManager();

        // TODO: use this.Content to load your game content here
    }
    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        GLOBALS.Time = gameTime;
        Input.Update();
        //gameManager.Update(gameTime);

        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        //gameManager.Draw(_spriteBatch, gameTime);

        base.Draw(gameTime);
    }
}

