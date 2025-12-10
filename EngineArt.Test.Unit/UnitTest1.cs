namespace EngineArt.Test.Unit;

[TestClass]
public class CollisionTest
{
    [TestMethod]
    public void VerticalCollisionTest()
    {
        Collider collider = new Collider();
        Collider collider2 = new Collider();

        collider.Width = 30;
        collider.Height = 30;
        collider2.Width = 30;
        collider2.Height = 30;
        collider.X = 20;
        collider.Y = 0;
        collider2.X = 20;
        collider2.Y = 20;
        
        Assert.IsTrue(collider.Intersects(collider2));

    }
    [TestMethod]
    public void CollisionWall()
    {
        Collider collider = new Collider();
        
        collider.Width = 30;
        collider.Height = 30;
        collider.X = 20;
        collider.Y = 20;
        
        Assert.AreEqual(5, collider.Left);
        Assert.AreEqual(35, collider.Right);
        Assert.AreEqual(5, collider.Top);
        Assert.AreEqual(35, collider.Bottom);

    }
    [TestMethod]
    public void HorizontalCollisionTest()
    {
        Collider collider = new Collider();
        Collider collider2 = new Collider();

        collider.Width = 30;
        collider.Height = 30;
        collider2.Width = 30;
        collider2.Height = 30;
        collider.X = 20;
        collider.Y = 0;
        collider2.X = 40;
        collider2.Y = 0;
        
        Assert.IsTrue(collider.Intersects(collider2));

    }

    [TestMethod]
    public void EdgeCollisionTest()
    {
        Collider collider = new Collider();
        Collider collider2 = new Collider();

        collider.Width = 30;
        collider.Height = 30;
        collider2.Width = 30;
        collider2.Height = 30;
        collider.X = 0;
        collider.Y = 0;
        collider2.X = 30;
        collider2.Y = 0;
        
        //They are one next to another, but they do not touch
        Assert.IsFalse(collider.Intersects(collider2));
    }

    [TestMethod]
    public void GameObjectParentPosition()
    {
        GameObject gameObject = new GameObject();
        GameObject gameObject2 = new GameObject();
        
        gameObject.AddChild(gameObject2);

        gameObject.MovePosition(10,0);
        
        Assert.AreEqual(gameObject.Position, gameObject2.Position);
        Assert.AreNotEqual(gameObject.Position, gameObject2.BasePosition);
    }
}