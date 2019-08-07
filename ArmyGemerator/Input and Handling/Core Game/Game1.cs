using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.IO;
namespace ArmyGenerator
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D markButton;
        Texture2D soldierRegulateButton;
        SpriteFont font;
        Texture2D book;
        Texture2D decorations;
        Texture2D armyButtons;
        Texture2D upDown;
        Texture2D background;
        Texture2D mark;
        Texture2D sortButtons;
        Texture2D mouse;
        Texture2D spells;
        Texture2D switchArmy;
        Texture2D show;
        Texture2D spelllDecoration;
        Texture2D linesprite;
        Texture2D magicSymbol;
        SoundEffect bookSound;
        SoundEffect horseSound;
        SoundEffect crystalSound;
        SoundEffect clickSound;
        SoundEffect swordSound;
        SoundEffect arrowSound;
        SoundEffect delete;
        GameSetting gameSetting;
        MouseClass mouseclass;
        SoundEffect hireRegiment;
        SoundEffect doot;
        Texture2D dootTexture;

        ScreenResolutionLoader screenResLoad;

        int screenwidth;
        int screenheight;
        int halfwayPointScreen;
        int armyXStartPos;
        int armyYStartPos;
        float scaledHeigth;
        float scaledWidth;
        int SwitchArmyButtonsPositionX;
        int SwitchArmyButtonsPositionY;
        int SwitchArmyButtonsPositionX2;
        int regimentCancel; 
        private int cutOffSize;
        int yStartPosMagic;
        int yCuttOff;
        int yStartRegimentLoad;
        int markButtonStartPos;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //graphics.IsFullScreen = true;
            base.Initialize();
            //this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 40 - 30;
            //this.graphics.IsFullScreen = true;
            this.Window.Position = new Point(0, 0);
            graphics.ApplyChanges();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            markButton = Content.Load<Texture2D>("pimpleHammer Markers");
            book = Content.Load<Texture2D>("BookBackground");
            armyButtons = Content.Load<Texture2D>("pressableButtons");
            soldierRegulateButton = Content.Load<Texture2D>("Buttons");
            font = Content.Load<SpriteFont>("Font");
            decorations = Content.Load<Texture2D>("book decorations");
            upDown = Content.Load<Texture2D>("UpDownButons");
            background = Content.Load<Texture2D>("Bakgrund");
            mark = Content.Load<Texture2D>("Pos");
            sortButtons = Content.Load<Texture2D>("sort");
            mouse = Content.Load<Texture2D>("MousePointer");
            spells = Content.Load<Texture2D>("magic");
            switchArmy = Content.Load<Texture2D>("turnArmy");
            show = Content.Load<Texture2D>("show");
            spelllDecoration = Content.Load<Texture2D>("SpellDecoration");
            bookSound = Content.Load<SoundEffect>("PageSound");
            horseSound = Content.Load<SoundEffect>("horse");
            crystalSound = Content.Load<SoundEffect>("Crystal");
            clickSound = Content.Load<SoundEffect>("Click");
            swordSound = Content.Load<SoundEffect>("Sword");
            arrowSound = Content.Load<SoundEffect>("Arrow");
            linesprite = Content.Load<Texture2D>("BlinkingLine");
            delete = Content.Load<SoundEffect>("Delete");
            hireRegiment = Content.Load<SoundEffect>("take_loan");
            magicSymbol = Content.Load<Texture2D>("SpellSymbols");
            dootTexture = Content.Load<Texture2D>("dootTexture");
            doot = Content.Load<SoundEffect>("doot");
            screenwidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            screenheight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 40 - 30;
            scaledHeigth = (float)background.Height / (float)screenheight;
            scaledWidth = (float)background.Width / (float)screenwidth;
            halfwayPointScreen = screenwidth / 2;
            armyYStartPos = 130;
            armyXStartPos = 80;
            SwitchArmyButtonsPositionX = 66;
            SwitchArmyButtonsPositionY = 21;
            SwitchArmyButtonsPositionX2 = 1439;
            cutOffSize = 90;
            regimentCancel = 40;
            yStartPosMagic = 30;
            yCuttOff = 20;
            yStartRegimentLoad = 40;
            markButtonStartPos = 20;
            mouseclass = new MouseClass(mouse, 1, 1);
            gameSetting = new GameSetting(markButton, armyButtons, soldierRegulateButton, book, font, decorations, upDown, background, mark, sortButtons, spells, switchArmy, 
                show, spelllDecoration, bookSound, crystalSound, horseSound, clickSound, swordSound, arrowSound, delete, linesprite, hireRegiment, screenwidth, screenheight,
                armyXStartPos, armyYStartPos, scaledHeigth, scaledWidth,SwitchArmyButtonsPositionX, SwitchArmyButtonsPositionY, SwitchArmyButtonsPositionX2, 
                screenwidth - cutOffSize, regimentCancel, yStartPosMagic, screenheight- yCuttOff, magicSymbol, yStartRegimentLoad, doot, dootTexture, markButtonStartPos);
            ResizeWindow(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width.ToString() + " x " + GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height.ToString());
            //ResizeWindow("1920 x 1080");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            if (this.IsActive)
            {
                mouseclass.Update();
                gameSetting.Update();
                if (gameSetting.GetScreenSize() != null)
                {
                    ResizeWindow(gameSetting.GetScreenSize());
                }
            }
        }
        protected void ResizeWindow(string input)
        {
            screenResLoad = new ScreenResolutionLoader(input, book);
            graphics.PreferredBackBufferWidth = screenResLoad.GetNumber(0);
            graphics.PreferredBackBufferHeight = screenResLoad.GetNumber(1);
            gameSetting.ReSize(screenResLoad.GetNumber(0), screenResLoad.GetNumber(1), screenResLoad.GetNumber(2), screenResLoad.GetNumber(3), screenResLoad.GetFloat(0),
                screenResLoad.GetFloat(1), screenResLoad.GetNumber(9), screenResLoad.GetNumber(10), screenResLoad.GetNumber(11), screenResLoad.GetNumber(5),
                screenResLoad.GetNumber(4), screenResLoad.GetNumber(0) - screenResLoad.GetNumber(6), screenResLoad.GetNumber(12), screenResLoad.GetNumber(2), 
                screenResLoad.GetNumber(8), screenResLoad.GetNumber(13), screenResLoad.GetNumber(7));
            //mouseclass.
            graphics.ApplyChanges();
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
            spriteBatch.Begin();
            gameSetting.Draw(spriteBatch);
            mouseclass.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
