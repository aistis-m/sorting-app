using System.Threading.Tasks;
using NUnit.Framework;
using SortAPI;

namespace Tests;

public class Tests
{
    public int[] input = { 5, 4, 3, 2, 1 };
    public int[] good = { 1, 2, 3, 4, 5 };

    Sorter? sorter;

    [SetUp]
    public void Setup()
    {
        sorter = new Sorter(input);
    }

    [Test]
    public void BubbleTest()
    {
        var bubble = new BubbleSort();
        var result = bubble.Sort(input);
        Assert.AreEqual(good, result);
    }
    [Test]
    public void InsertionTest()
    {
        var insertion = new InsertionSort();
        var result = insertion.Sort(input);
        Assert.AreEqual(good, result);
    }
    [Test]
    public async Task AlgoRunnerTest()
    {
        var task = await sorter.RunAlgorithm(new BubbleSort());
        var outputStr = string.Join(" ", good);
        Assert.AreEqual(outputStr, task.sorted);
    }
}
