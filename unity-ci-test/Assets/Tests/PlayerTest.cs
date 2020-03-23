using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Player player;
    private Vector3 initialPosition;
    private readonly float speed = 3;

    [SetUp]
    public void SetUp()
    {
        player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).GetComponent<Player>();
        initialPosition = player.transform.position;
        player.speed = speed;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator TestMoveDoesNotMoveIfVectorIsZero()
    {
        Vector3 direction = Vector3.zero;
        player.Move(direction);

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(initialPosition, player.transform.position);
    }

    [UnityTest]
    public IEnumerator TestMovesAccordingToDeltaTimeAndSpeed()
    {
        Vector3 direction = new Vector3(1, 0, 0);
        player.Move(direction);

        yield return new WaitForEndOfFrame();

        Vector3 expectedPosition = new Vector3(initialPosition.x + (Time.deltaTime * speed), 0, 0);

        Assert.AreEqual(expectedPosition, player.transform.position);
    }

    [UnityTest]
    public IEnumerator TestMoveNormalizesMovementVector()
    {
        Vector3 direction = new Vector3(2, 0, 0);
        player.Move(direction);

        yield return new WaitForEndOfFrame();

        Vector3 expectedPosition = new Vector3(initialPosition.x + (Time.deltaTime * speed), 0, 0);

        Assert.AreEqual(expectedPosition, player.transform.position);
    }

    [UnityTest]
    public IEnumerator TestMoveCanMoveInAllDirections()
    {
        Vector3 direction = new Vector3(1, 1, 1);
        player.Move(direction);

        yield return new WaitForEndOfFrame();

        Assert.AreNotEqual(initialPosition.x, player.transform.position.x);
        Assert.AreNotEqual(initialPosition.y, player.transform.position.y);
        Assert.AreNotEqual(initialPosition.z, player.transform.position.z);
    }
}