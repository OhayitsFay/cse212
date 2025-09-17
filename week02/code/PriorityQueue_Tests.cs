using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add one item and dequeue it
    // Expected Result: The item "A" is returned
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Multiple enqueues and dequeues in order
    // Expected Result: Items removed in correct priority/FIFO sequence
    // Defect(s) Found:Off-by-one error in original for-loop
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 5);

        // Highest priority first: B (5), then D (5 FIFO), then A (2), then C (1)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue A(1), B(2), C(3). Dequeue until empty.
    // Expected Result: C, B, A
    // Defect(s) Found: Dequeue loop ignored last element. Items weren’t removed.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);

        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A(2), B(2), C(1). Two same priorities.
    // Expected Result: A, B, C (FIFO for equal priority).
    // Defect(s) Found: Code incorrectly chose the last equal-priority item instead of first.
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 1);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to Dequeue from empty queue.
    // Expected Result: Exception "The queue is empty."
    // Defect(s) Found: None (exception worked correctly).
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}