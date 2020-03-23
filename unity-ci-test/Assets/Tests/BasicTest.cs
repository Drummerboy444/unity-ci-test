using NUnit.Framework;

public class BasicTest
{
    [Test]
    public void BasicTestSimplePasses()
    {
        Assert.AreEqual(1f, 2f);
    }
}
