namespace EngineArt.Drawings
{
    public class TextObject
    {
        public SpriteFont font = GLOBALS.Font;
        public String text;
        public Color color = Color.White;
        public Rectangle rect;
        public Vector2 position;

        public enum Alignments
        {
            TopLeft,
            Top,
            TopRight,
            Left,
            Center,
            Right,
            BottomLeft,
            Bottom,
            BottomRight
        }
        public Alignments alignment = Alignments.Left;
        public enum DrawDirection
        {
            LeftToRight,
            RightToLeft,
            TopToBottom,
            BottomToDown,
        }
        // If the text is bigger than rect size do:
        // true: text continues to draw outside of rect
        // false: cuts off
        public bool textOverFlow = true;


        // Effects
        public bool isBold = false;
        public bool isItalic = false;
        public bool isUnderline = false;
        public bool isStrikethrough = false;
        public bool isStrikeout = false;

        //public TextObject(String text, Color? color, Rectangle? rect)
        //{
        //    this.text = text;
        //    this.color = color ?? Color.White;
        //    this.rect = rect ?? Rectangle.Empty;
        //    this.position = SetAligmentPosition();
        //}
        public TextObject(String text, Color? color, Rectangle? rect, Alignments? alignment)
        {
            this.text = text;
            this.color = color ?? Color.White;
            this.rect = rect ?? Rectangle.Empty;
            this.alignment = alignment ?? Alignments.TopLeft;
            this.position = SetAligmentPosition(text);
        }
        List<string> AddTextChunks(string text)
        {

            // ADD FUNCTION TO SPLIT IT
            return new List<string>();

        }
        public void Draw()
        {
            #region RichText - Nie działa (Jak chcesz to napraw)
            //string patternColor = @"\{color:[^}]+\}";
            //string clearText = Regex.Replace(text, patternColor, String.Empty);
            //List<string> textChunks =AddTextChunks(clearText);


            //Color currentColor = Color.White;
            //Vector2 currentPosition = aligment switch 
            //{ 
            //    Aligment.Left => position, 
            //    Aligment.Right => position + new Vector2(0, font.MeasureString(clearText).X), 
            //    Aligment.Center => position + new Vector2(0, font.MeasureString(clearText).X) / 2, 
            //    _  => position
            //};

            //foreach (string chunk in textChunks)
            //{
            //    if (chunk.StartsWith("{color:"))
            //    {
            //        var colorTag = chunk.Substring(7, chunk.Length - 8);
            //        currentColor = GetColorFromTag(colorTag);
            //    }
            //    else
            //    {
            //        spriteBatch.DrawString(font, chunk, currentPosition, currentColor);
            //        currentPosition.X += font.MeasureString(chunk).X;
            //    }
            //}
            #endregion
            GLOBALS.SpriteBatch.DrawString(font, text, position, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public void Draw(String newText)
        {
            position = SetAligmentPosition(newText);
            GLOBALS.SpriteBatch.DrawString(font, newText, position, color);
        }
        public static Color GetColorFromTag(string colorName)
        {
            switch (colorName.ToLower())
            {
                case "red": return Color.Red;
                case "green": return Color.Green;
                case "blue": return Color.Blue;
                case "yellow": return Color.Yellow;
                case "white": return Color.White;
                // Add more colors as needed
                default: return Color.White;  // Default to white if color is unknown
            }
        }
        protected Vector2 SetAligmentPosition(String text)
        {
            Vector2 setAligment = new Vector2(0, 0);
            Vector2 textSize = font.MeasureString(text);
            switch (alignment)
            {
                case Alignments.TopLeft:
                    setAligment = new Vector2(rect.X, 
                                                 rect.Y);
                    break;
                case Alignments.Top:
                    setAligment = new Vector2(rect.X - textSize.X / 2 + rect.Width / 2, 
                                                 rect.Y);
                    break;
                case Alignments.TopRight:
                    setAligment = new Vector2(rect.X - textSize.X + rect.Width, 
                                                 rect.Y);
                    break;
                case Alignments.Left:
                    setAligment = new Vector2(rect.X, 
                                                 rect.Y - textSize.Y / 2 + rect.Height / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(rect.X - textSize.X / 2 + rect.Width / 2, 
                                                 rect.Y - textSize.Y / 2 + rect.Height / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(rect.X - textSize.X + rect.Width,
                                                 rect.Y - textSize.Y / 2 + rect.Height / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(rect.X,
                                                 rect.Y - textSize.Y + rect.Height);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(rect.X - textSize.X / 2 + rect.Width / 2,
                                                 rect.Y - textSize.Y + rect.Height);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(rect.X - textSize.X + rect.Width,
                                                 rect.Y - textSize.Y + rect.Height);
                    break;
            }
            return setAligment;
        }
        static public Vector2 SetAligmentForText(String text, SpriteFont font, Alignments alignment)
        {
            Vector2 setAligment = new Vector2(0, 0);
            Vector2 textSize = font.MeasureString(text);
            switch (alignment)
            {
                case Alignments.TopLeft:
                    setAligment = new Vector2();
                    break;
                case Alignments.Top:
                    setAligment = new Vector2(textSize.X / 2, 0);
                    break;
                case Alignments.TopRight:
                    setAligment = new Vector2(textSize.X, 0);
                    break;
                case Alignments.Left:
                    setAligment = new Vector2(0, textSize.Y / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(textSize.X / 2, textSize.Y / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(textSize.X, textSize.Y / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(0, textSize.Y);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(textSize.X / 2, textSize.Y);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(textSize.X, textSize.Y);
                    break;
            }
            return setAligment;
        }
    }
}
