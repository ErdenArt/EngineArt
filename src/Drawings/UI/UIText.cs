using System;
using System.Diagnostics;

namespace EngineArt.Drawings.UI
{
    public class UIText : UIElement
    {
        public SpriteFont Font = GLOBALS.Font;
        public string Text = "";
        public Color TextColor = Color.White;
        public Alignments TextAlignment;

        float rotation;
        public float Rotation { get => MathHelper.ToRadians(rotation); set => rotation = MathHelper.ToDegrees(value); }

        public float TextScale = 1f;
        public override void Draw()
        {
            float lineSpace = Font.LineSpacing * TextScale;
            String[] lines = Text.Split('\n');
            float angle = Rotation;
            Vector2 dir = new Vector2(-MathF.Sin(angle), MathF.Cos(angle));
            //Vector2 dir = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
            for (int i = 0; i < lines.Length; i++)
            {
                var fontSize = Font.MeasureString(lines[i]);
                Vector2 endPosition = SetAligmentPosition(Alignment, Bounds)
                                    + Position
                                    + i * Font.LineSpacing * TextScale * dir;
                Vector2 RotationPosition = SetAligmentForText(Text, lines[i], Font, TextAlignment);
                GLOBALS.SpriteBatch.DrawString(Font, lines[i], endPosition, TextColor, Rotation, RotationPosition, TextScale, SpriteEffects.None, 0f);
            }
            //Debug.WriteLine(Parent);

            foreach (var child in Children)
            {
                child.Draw();
            }
        }
        public static void Draw(SpriteFont spriteFont, String text, Color color, Alignments screenAlignment, Alignments textAlignment, Vector2 position, float textSize)
        {
            // This thing is not updated

            Vector2 endPosition = new Vector2();
            //Debug.WriteLine(SetAligmentForText(text, spriteFont, textAlignment));
            endPosition += SetAligmentPosition(screenAlignment, new Rectangle(0,0, GLOBALS.WindowSize.X, GLOBALS.WindowSize.Y))
                         + SetAligmentForText(text, text, spriteFont, textAlignment)
                         + position;

            GLOBALS.SpriteBatch.DrawString(spriteFont, text, endPosition, color, 0f, Vector2.Zero, textSize, SpriteEffects.None, 0);
        }

        static Vector2 SetAligmentForText(String wholeText, String lineOfText, SpriteFont font, Alignments alignment)
        {
            Vector2 setAligment = new Vector2(0, 0);
            float textHeigth = font.MeasureString(wholeText).Y;
            Vector2 textSize = font.MeasureString(lineOfText);
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
                    setAligment = new Vector2(0, textHeigth / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(textSize.X / 2, textHeigth / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(textSize.X, textHeigth / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(0, textHeigth);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(textSize.X / 2, textHeigth);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(textSize.X, textHeigth);
                    break;
            }
            return setAligment;
        }
    }
}
