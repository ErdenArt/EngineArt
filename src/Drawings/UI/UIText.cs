using System;

namespace EngineArt.Drawings.UI
{
    public class UIText : UIElement
    {
        public SpriteFont Font = GLOBALS.Font;
        public string Text = "";
        public Color TextColor = Color.White;
        public Alignments TextAligment;

        float rotation;
        public float Rotation { get => MathHelper.ToRadians(rotation); set => rotation = MathHelper.ToDegrees(value); }
        public Vector2 RotationPosition;
        public float TextScale = 1f;
        public override void Draw()
        {
            Vector2 endPosition = new Vector2();
            endPosition += SetAligmentPosition(Alignment)
                         + SetAligmentForText(Text, Font, TextAligment)
                         + Position;


            GLOBALS.SpriteBatch.DrawString(Font, Text, endPosition, TextColor, Rotation, RotationPosition, TextScale, SpriteEffects.None, 0f);
            //Debug.WriteLine(Parent);

            foreach (var child in Children)
            {
                child.Draw();
            }
        }
        public static void Draw(SpriteFont spriteFont, String text, Color color, Alignments screenAlignment, Alignments textAlignment, Vector2 position, float textSize)
        {
            Vector2 endPosition = new Vector2();
            //Debug.WriteLine(SetAligmentForText(text, spriteFont, textAlignment));
            endPosition += SetAligmentPosition(screenAlignment)
                         + SetAligmentForText(text, spriteFont, textAlignment)
                         + position;

            GLOBALS.SpriteBatch.DrawString(spriteFont, text, endPosition, color, 0f, Vector2.Zero, textSize, SpriteEffects.None, 0);
        }

        static Vector2 SetAligmentForText(String text, SpriteFont font, Alignments alignment)
        {
            Vector2 setAligment = new Vector2(0, 0);
            Vector2 textSize = font.MeasureString(text);
            switch (alignment)
            {
                case Alignments.TopLeft:
                    setAligment = new Vector2();
                    break;
                case Alignments.Top:
                    setAligment = new Vector2(-textSize.X / 2, 0);
                    break;
                case Alignments.TopRight:
                    setAligment = new Vector2(-textSize.X, 0);
                    break;
                case Alignments.Left:
                    setAligment = new Vector2(0, -textSize.Y / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(-textSize.X / 2, -textSize.Y / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(-textSize.X, -textSize.Y / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(0, -textSize.Y);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(-textSize.X / 2, -textSize.Y);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(-textSize.X, -textSize.Y);
                    break;
            }
            return setAligment;
        }
        static Vector2 SetAligmentPosition(Alignments alignmets)
        {
            Vector2 setAligment = new Vector2(0, 0);
            switch (alignmets)
            {
                case Alignments.TopLeft:
                    setAligment = new Vector2();
                    break;
                case Alignments.Top:
                    setAligment = new Vector2(GLOBALS.WindowSize.X / 2, 0);
                    break;
                case Alignments.TopRight:
                    setAligment = new Vector2(GLOBALS.WindowSize.X, 0);
                    break;
                case Alignments.Left:
                    setAligment = new Vector2(0, GLOBALS.WindowSize.Y / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(GLOBALS.WindowSize.X / 2, GLOBALS.WindowSize.Y / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(0, GLOBALS.WindowSize.Y);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(GLOBALS.WindowSize.X / 2, GLOBALS.WindowSize.Y);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y);
                    break;
            }
            return setAligment;
        }
    }
}
