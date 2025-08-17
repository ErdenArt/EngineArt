using System.Collections.Generic;

namespace Engine.Mathematic
{
    public enum Button
    {
        LeftClick,
        RightClick,
        MiddleClick
    }
    public static class Input
    {
        public static bool isControllerActive = false;

        private static KeyboardState _currentKeyState;
        private static KeyboardState _previousKeyState;

        private static MouseState _currentMouseState;
        private static MouseState _previousMouseState;
        private static int _previousScrollSpeed;

        private static GamePadState _currentGamePadState;
        private static GamePadState _previousGamePadState;

        private static Dictionary<Keys, Buttons> keyboardToPad = new()
        {
            {Keys.W, Buttons.DPadUp},
            {Keys.A, Buttons.DPadLeft},
            {Keys.S, Buttons.DPadDown},
            {Keys.D, Buttons.DPadRight},
            {Keys.Enter, Buttons.Start},
            {Keys.Escape, Buttons.Back},
            {Keys.O, Buttons.None },
            {Keys.P, Buttons.None },
        };
        // Translate normal buttons to fucked up buttons
        private static Dictionary<Keys, Keys> bindedKeysTranslate = new()
        {
            {Keys.W, Keys.A },
            {Keys.S, Keys.D},
        };
        public static Vector2 LeftStickDirection
        {
            get
            {
                if (isControllerActive)
                    return GamePad.GetState(0).ThumbSticks.Left * new Vector2(1, -1);
                return new Vector2(
                    GetAxis(Keys.D, Keys.A),
                    GetAxis(Keys.S, Keys.W));
            }
        }
        public static Vector2 RightStickDirection
        {
            get
            {
                if (isControllerActive)
                    return GamePad.GetState(0).ThumbSticks.Right * new Vector2(1,-1);
                return new Vector2(
                    GetAxis(Keys.Right, Keys.Left),
                    GetAxis(Keys.Down, Keys.Up));
            }
        }

        static float GetAxis(Keys positive, Keys negative)
        {
            return (_currentKeyState.IsKeyDown(positive) ? 1f : 0f) - (_currentKeyState.IsKeyDown(negative) ? 1f : 0f);
        }

        public static void Update()
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();

            _previousMouseState = _currentMouseState;
            _previousScrollSpeed = _currentMouseState.ScrollWheelValue;
            _currentMouseState = Mouse.GetState();

            _previousGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(0);

        }
        public static bool GetKeyDown(Keys key)
        {
            if (isControllerActive)
                return _currentGamePadState.IsButtonDown(keyboardToPad[key]) && _previousGamePadState.IsButtonUp(keyboardToPad[key]);
            return _currentKeyState.IsKeyDown(key) && _previousKeyState.IsKeyUp(key);
        }
        public static bool GetKey(Keys key)
        {
            if (isControllerActive)
                return _currentGamePadState.IsButtonDown(keyboardToPad[key]);
            return _currentKeyState.IsKeyDown(key);
        }
        public static bool GetKeyUp(Keys key)
        {
            if (isControllerActive)
                return _currentGamePadState.IsButtonUp(keyboardToPad[key]) && _previousGamePadState.IsButtonDown(keyboardToPad[key]);
            return _currentKeyState.IsKeyUp(key) && _previousKeyState.IsKeyDown(key);
        }
        public static bool GetMouse(Button button)
        {
            return button switch
            {
                Button.LeftClick => _currentMouseState.LeftButton == ButtonState.Pressed,
                Button.RightClick => _currentMouseState.RightButton == ButtonState.Pressed,
                Button.MiddleClick => _currentMouseState.MiddleButton == ButtonState.Pressed,
                _ => false
            };
        }
        public static bool GetMouseDown(Button button)
        {
            return button switch
            {
                Button.LeftClick => GetMouseDown(_currentMouseState.LeftButton, _previousMouseState.LeftButton),
                Button.RightClick => GetMouseDown(_currentMouseState.RightButton, _previousMouseState.RightButton),
                Button.MiddleClick => GetMouseDown(_currentMouseState.MiddleButton, _previousMouseState.MiddleButton),
                _ => false
            };
        }
        static bool GetMouseDown(ButtonState buttonState, ButtonState prevButtonState)
        {
            return buttonState == ButtonState.Pressed && prevButtonState == ButtonState.Released;
        }
        public static bool GetMouseUp(Button button)
        {
            // Same thing like with GetMouseDown(Button button)
            return button switch
            {
                Button.LeftClick => GetMouseUp(_currentMouseState.LeftButton, _previousMouseState.LeftButton),
                Button.RightClick => GetMouseUp(_currentMouseState.RightButton, _previousMouseState.RightButton),
                Button.MiddleClick => GetMouseUp(_currentMouseState.MiddleButton, _previousMouseState.MiddleButton),
                _ => false
            };
        }
        static bool GetMouseUp(ButtonState buttonState, ButtonState prevButtonState)
        {
            return buttonState == ButtonState.Released && prevButtonState == ButtonState.Pressed;
        }
        public static int MouseScrollSpeed()
        {
            return _currentMouseState.ScrollWheelValue;
        }
        public static bool MouseScrollIsGointUp()
        {
            return _previousScrollSpeed < _currentMouseState.ScrollWheelValue;
        }
        public static bool MouseScrollIsGointDown()
        {
            return _previousScrollSpeed > _currentMouseState.ScrollWheelValue;
        }
        public static Point GetMousePosition()
        {
            return Mouse.GetState().Position;
        }
        public static Vector2Int GetMousePositionToWorld(Camera camera)
        {
            return (Vector2Int)((Mouse.GetState().Position.ToVector2() + camera.GetPosition()) / camera.Zoom);
        }

    }
}
