using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SFML2D.Core
{
    internal abstract class Game
    {
        static readonly int TARGET_FPS = 60;
        static readonly float FRAME_TIME = 1f / TARGET_FPS;

        uint WINDOW_HEIGHT = 600;
        uint WINDOW_WIDTH = 800;

        RenderWindow window;
        protected Render renderer;

        public Game()
        {
            var settings = new ContextSettings();
            settings.AntialiasingLevel = 8;
            settings.StencilBits = 8;
            settings.DepthBits = 8;
            window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), " ", Styles.Titlebar | Styles.Close, settings);
            renderer = new Render(window);
            window.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }

        public void Run()
        {
            float timeTillUpdate = FRAME_TIME;
            Initialize(window);
            while(window.IsOpen)
            {
                window.DispatchEvents();
                Time.Update();
                Update();
                if (timeTillUpdate < 0)
                {
                    timeTillUpdate = FRAME_TIME;
                    
                    renderer.Draw(SceneManager.GetActiveScene());
                }
                else timeTillUpdate -= Time.deltaTime;
            }
        }

        public abstract void Initialize(RenderWindow window);

        public abstract void Update();
    }
}
