namespace SFML2D.Core
{
    public enum KeyState
    {
        down,      // first frame when button is pressed
        pressed,   // 2nd frame when button is pressed until it is released
        up,        // first frame when button is released
        released   // button is not pressed
    }
    public class Keyboard
    {
        public KeyState A = KeyState.released;
        public KeyState B = KeyState.released;
        public KeyState C = KeyState.released;
        public KeyState D = KeyState.released;
        public KeyState E = KeyState.released;
        public KeyState F = KeyState.released;
        public KeyState G = KeyState.released;
        public KeyState H = KeyState.released;
        public KeyState I = KeyState.released;
        public KeyState J = KeyState.released;
        public KeyState K = KeyState.released;
        public KeyState L = KeyState.released;
        public KeyState M = KeyState.released;
        public KeyState N = KeyState.released;
        public KeyState O = KeyState.released;
        public KeyState P = KeyState.released;
        public KeyState Q = KeyState.released;
        public KeyState R = KeyState.released;
        public KeyState S = KeyState.released;
        public KeyState T = KeyState.released;
        public KeyState U = KeyState.released;
        public KeyState V = KeyState.released;
        public KeyState W = KeyState.released;
        public KeyState X = KeyState.released;
        public KeyState Y = KeyState.released;
        public KeyState Z = KeyState.released;
        public KeyState Num0 = KeyState.released;
        public KeyState Num1 = KeyState.released;
        public KeyState Num2 = KeyState.released;
        public KeyState Num3 = KeyState.released;
        public KeyState Num4 = KeyState.released;
        public KeyState Num5 = KeyState.released;
        public KeyState Num6 = KeyState.released;
        public KeyState Num7 = KeyState.released;
        public KeyState Num8 = KeyState.released;
        public KeyState Num9 = KeyState.released;
        public KeyState Numpad0 = KeyState.released;
        public KeyState Numpad1 = KeyState.released;
        public KeyState Numpad2 = KeyState.released;
        public KeyState Numpad3 = KeyState.released;
        public KeyState Numpad4 = KeyState.released;
        public KeyState Numpad5 = KeyState.released;
        public KeyState Numpad6 = KeyState.released;
        public KeyState Numpad7 = KeyState.released;
        public KeyState Numpad8 = KeyState.released;
        public KeyState Numpad9 = KeyState.released;
        public KeyState F1 = KeyState.released;
        public KeyState F2 = KeyState.released;
        public KeyState F3 = KeyState.released;
        public KeyState F4 = KeyState.released;
        public KeyState F5 = KeyState.released;
        public KeyState F6 = KeyState.released;
        public KeyState F7 = KeyState.released;
        public KeyState F8 = KeyState.released;
        public KeyState F9 = KeyState.released;
        public KeyState F10 = KeyState.released;
        public KeyState F11 = KeyState.released;
        public KeyState F12 = KeyState.released;
        public KeyState LControl = KeyState.released;
        public KeyState RControl = KeyState.released;
        public KeyState LShift = KeyState.released;
        public KeyState RShift = KeyState.released;
        public KeyState LAlt = KeyState.released;
        public KeyState RAlt = KeyState.released;
        public KeyState LSystem = KeyState.released;
        public KeyState RSystem = KeyState.released;
        public KeyState PageUp = KeyState.released;
        public KeyState PageDown = KeyState.released;
        public KeyState Home = KeyState.released;
        public KeyState End = KeyState.released;
        public KeyState Insert = KeyState.released;
        public KeyState Delete = KeyState.released;
        public KeyState Print = KeyState.released;
        public KeyState Menu = KeyState.released;
        public KeyState Pause = KeyState.released;
        public KeyState Backspace = KeyState.released;
        public KeyState Enter = KeyState.released;
        public KeyState Tab = KeyState.released;
        public KeyState Space = KeyState.released;
        public KeyState Escape = KeyState.released;
        public KeyState Add = KeyState.released;
        public KeyState Subtract = KeyState.released;
        public KeyState Divide = KeyState.released;
        public KeyState Multiply = KeyState.released;
        public KeyState Left = KeyState.released;
        public KeyState Right = KeyState.released;
        public KeyState Up = KeyState.released;
        public KeyState Down = KeyState.released;
        public KeyState LBracket = KeyState.released;
        public KeyState RBracket = KeyState.released;
        public KeyState Semicolon = KeyState.released;
        public KeyState Comma = KeyState.released;
        public KeyState Period = KeyState.released;
        public KeyState Slash = KeyState.released;
        public KeyState Backslash = KeyState.released;
        public KeyState Tilde = KeyState.released;
        public KeyState Equal = KeyState.released;
        public KeyState Hyphen = KeyState.released;
        public KeyState Quote = KeyState.released;
    }

    public static class Input
    {
        public static Keyboard Keyboard { get; private set; } = new Keyboard();

        public static void Update()
        {
            foreach (var key in typeof(Keyboard).GetFields())
            {
                foreach (SFML.Window.Keyboard.Key SFMLKey in Enum.GetValues(typeof(SFML.Window.Keyboard.Key)))
                {
                    if (key.Name == SFMLKey.ToString())
                    {
                        KeyState state = (KeyState)key.GetValue(Keyboard);
                        if (SFML.Window.Keyboard.IsKeyPressed(SFMLKey))
                        {
                            if (state == KeyState.down) key.SetValue(Keyboard, KeyState.pressed);
                            else if (state != KeyState.pressed) key.SetValue(Keyboard, KeyState.down);
                        }
                        else
                        {
                            if (state == KeyState.up) key.SetValue(Keyboard, KeyState.released);
                            else if (state != KeyState.released) key.SetValue(Keyboard, KeyState.up);
                        }
                    }
                }
            }
        }
    }
}
