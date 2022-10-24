﻿using SFML.Graphics;
using SFML2D.Core.UI;

namespace SFML2D.Core
{
    internal class Render
    {
        RenderWindow window;

        public Render(RenderWindow window)
        {
            this.window = window;
        }

        public void Draw(Scene scene)
        {
            List<GameObject> objects = scene.gameObjects;
            List<UIObject> uiObjects = scene.uiObjects;

            window.Clear();

            foreach (GameObject obj in objects)
            {
                obj.GetComponent<SpriteRenderer>().Render(window);
            }
            foreach (UIObject obj in uiObjects)
            {
                obj.Draw(window);
            }

            window.Display();
        }
    }
}
