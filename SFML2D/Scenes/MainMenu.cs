using SFML.Graphics;
using SFML2D.Core;
using SFML2D.Core.UI;
using SFML2D.Generics;

namespace SFML2D.Scenes.Menu
{
    internal class MainMenu
    {
        public readonly int sceneIndex = 0;

        private Scene mainMenu;

        public UIObject buttonObj;
        public UIObject buttonObj1;
        public UIObject buttonObj2;
        public UIObject buttonObj3;

        public Panel panel;
        public Button button;
        public Panel panel1;
        public Button button1;
        public Panel panel2;
        public Button button2;
        public Panel panel3;
        public Button button3;

        public MainMenu(RenderWindow window)
        {
            mainMenu = SceneManager.CreateScene("MainMenu");
            buttonObj = new UIObject(window, "Panel", new Vector2i(500, 100));
            panel = new Panel(buttonObj, rounding: 25, borderSize: 20);
            button = new Button(buttonObj, "Smooooooooth", fontSize: 80);

            buttonObj1 = new UIObject(window, "Panel1", new Vector2i(250, 370), new Vector2i(300, 80));
            panel1 = new Panel(buttonObj1, rounding: 0, borderSize: 5);
            button1 = new Button(buttonObj1, "This is a button.", fontSize: 50);

            buttonObj2 = new UIObject(window, "Panel2", new Vector2i(300, 475), new Vector2i(200, 70));
            panel2 = new Panel(buttonObj2, rounding: 45, borderSize: 0);
            button2 = new Button(buttonObj2, "Dis smol button");

            buttonObj3 = new UIObject(window, "Panel3", new Vector2i(300, 100), new Vector2i(200, 70));
            panel3 = new Panel(buttonObj3, Color.Black);
            button3 = new Button(buttonObj3, "this is some text", 140, Color.White);


            mainMenu.AddUIObject(buttonObj);
            mainMenu.AddUIObject(buttonObj1);
            mainMenu.AddUIObject(buttonObj2);
            mainMenu.AddUIObject(buttonObj3);
        }
    }
}
