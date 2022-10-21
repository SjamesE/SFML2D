using SFML.Graphics;
using SFML2D.Generics;

namespace SFML2D.Core.UI
{
    internal class Button : UIComponent
    {
        private Text text;
        private Font font;
        private Color _fontColor;
        private string _displayedString;
        private uint _fontSize;
        public Color fontColor 
        {
            get => _fontColor;
            set
            {
                _fontColor = value;
                update = true;
            }
        }
        public string displayedString 
        {
            get => _displayedString;
            set
            {
                _displayedString = value;
                update = true;
            }
        }
        public uint fontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                update = true;
            }
        }

        private bool update = false;


        //private string path = "C:/Users/sjame/Source/Repos/SjamesE/SFML2D/SFML2D/Assets/Dongle-Regular.ttf";
        private string path = "C:/Users/jsovea/source/repos/SFML2D/SFML2D/Assets/Dongle-Regular.ttf";

        public Button(UIObject parent) : this(parent, "This is a Button", 32, Color.Black) { }

        public Button(UIObject parent, string displayedString) : this(parent, displayedString, 32, Color.Black) { }
        public Button(UIObject parent, string displayedString, uint fontSize) : this(parent, displayedString, fontSize, Color.Black) { }

        public Button(UIObject parent, string displayedString, uint fontSize, Color fontColor) : base(parent)
        {
            parent.AddComponent(this);

            font = new Font(path);
            text = new Text(displayedString, font);

            this.fontColor = fontColor;
            this.displayedString = displayedString;
            this.fontSize = fontSize;
        }

        private void Update()
        {
            text.FillColor = fontColor;
            text.CharacterSize = fontSize;
            text.DisplayedString = displayedString;
            Vector2i textSize = new Vector2i((int)text.GetGlobalBounds().Width, (int)text.GetGlobalBounds().Height);
            Vector2i newTextPos = transform.center - (textSize / 2) - new Vector2i(0, (int)fontSize / 2 + (int)fontSize / 20);
            text.Position = newTextPos.ToSFMLVector2f;
            update = false;
        }

        public void Draw(RenderWindow window)
        {
            if (update) Update();

            window.Draw(text);
        }
    }
}
