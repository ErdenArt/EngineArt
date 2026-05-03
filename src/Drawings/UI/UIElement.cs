using EngineArt.Mathematic;
using System.Collections.Generic;
using System.Diagnostics;

namespace EngineArt.Drawings.UI
{
    // Main script that is used mainly for UI
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
    public abstract class UIElement
    {
        public Rectangle Bounds { get; set; }
        public Vector2Int Position { get => (Vector2Int)FinalBounds.Location; set => Bounds = new Rectangle(value.X, value.Y, Bounds.Width, Bounds.Height); }
        public Rectangle FinalBounds
        {
            get
            {
                if (parent != null)
                {
                    Point point = SetAligmentPositionForParent(Alignment, Bounds)
                                + parent.FinalBounds.Location
                                + Bounds.Location;

                    return new Rectangle(point.X, point.Y, Bounds.Width, Bounds.Height);
                }
                return Bounds;
            }
        }

        public bool canClick = false;
        public Action actionOnClick;
        Point SetAligmentPositionForParent(Alignments alignmet, Rectangle rect)
        {
            Point setAligment = new Point(0, 0);

            Point parentBoundsSize = Point.Zero;
            if (Parent != null)
            {
                parentBoundsSize = Parent.FinalBounds.Size;
            }

            switch (alignmet)
            {
                case Alignments.TopLeft:
                    setAligment = new Point(0, 0);
                    break;
                case Alignments.Top:
                    setAligment = new Point(0 + parentBoundsSize.X / 2 - rect.Width / 2, 0);
                    break;
                case Alignments.TopRight:
                    setAligment = new Point(0 + parentBoundsSize.X - rect.Width, 0);
                    break;
                case Alignments.Left:
                    setAligment = new Point(0, 0 + parentBoundsSize.Y / 2 - rect.Height / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Point(0 + parentBoundsSize.X / 2 - rect.Width / 2, 0 + parentBoundsSize.Y / 2 - rect.Height / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Point(0 + parentBoundsSize.X - rect.Width, 0 + parentBoundsSize.Y / 2 - rect.Height / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Point(0, 0 + parentBoundsSize.Y - rect.Height);
                    break;
                case Alignments.Bottom:
                    setAligment = new Point(0 + parentBoundsSize.X / 2 - rect.Width / 2, 0 + parentBoundsSize.Y - rect.Height);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Point(0 + parentBoundsSize.X - rect.Width, 0 + parentBoundsSize.Y - rect.Height);
                    break;
            }
            return setAligment;
        }

        public Alignments Alignment;
        UIElement? parent;
        public List<UIElement> Children = new List<UIElement>();

        public UIElement? Parent
        {
            get => parent;
            set => parent = value;
        }

        public void AddChild(UIElement child)
        {
            child.Parent = this;
            Children.Add(child);
        }
        public void AddChildren(params UIElement[] uIElement)
        {
            foreach (var item in uIElement)
            {
                item.Parent = this;
                Children.Add(item);
            }
        }
        public void RemoveChild(UIElement child)
        {
            Children.Remove(child);
        }
        public abstract void Draw();
        public virtual void Update()
        {
            if (canClick == false || Input.GetMouseDown(Button.LeftClick) == false)
                return;

            Point pos = Input.GetMousePosition();
            if (pos.X > FinalBounds.X && pos.X < FinalBounds.X + FinalBounds.Width &&
                pos.Y > FinalBounds.Y && pos.Y < FinalBounds.Y + FinalBounds.Height)
            {
                actionOnClick.Invoke();
            }
        }
        protected static Vector2 SetAligmentPosition(Alignments alignmets, Rectangle bounds)
        {
            Vector2 setAligment = new Vector2(0, 0);
            switch (alignmets)
            {
                case Alignments.TopLeft:
                    setAligment = new Vector2();
                    break;
                case Alignments.Top:
                    setAligment = new Vector2(bounds.X + bounds.Width / 2, 0);
                    break;
                case Alignments.TopRight:
                    setAligment = new Vector2(bounds.X + bounds.Width, 0);
                    break;
                case Alignments.Left:
                    setAligment = new Vector2(0, bounds.Y + bounds.Height / 2);
                    break;
                case Alignments.Center:
                    setAligment = new Vector2(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height / 2);
                    break;
                case Alignments.Right:
                    setAligment = new Vector2(bounds.X + bounds.Width, bounds.Y + bounds.Height / 2);
                    break;
                case Alignments.BottomLeft:
                    setAligment = new Vector2(0, bounds.Y + bounds.Height);
                    break;
                case Alignments.Bottom:
                    setAligment = new Vector2(bounds.X + bounds.Width / 2, bounds.Y + bounds.Height);
                    break;
                case Alignments.BottomRight:
                    setAligment = new Vector2(bounds.X + bounds.Width, bounds.Y + bounds.Height);
                    break;
            }
            return setAligment;
        }
    }
}
