using tunelint.model;

namespace test.model {
  internal class DurationTests {
    private static object[] _compareCases = [
      new object[] { new Duration(1),  new Duration(1),  0 },
      new object[] { new Duration(-1), new Duration(-1), 0 },
      new object[] { new Duration(1),  new Duration(0),  1 },
      new object[] { new Duration(0),  new Duration(-1), 1 },
      new object[] { new Duration(0),  new Duration(1), -1 },
      new object[] { new Duration(-1), new Duration(0), -1 }
    ];

    [TestCaseSource(nameof(_compareCases))]
    public void TestCompare(Duration first, Duration second, int expected) {
      int actual = first.CompareTo(second);
      Assert.That(Util.SameSigns(actual, expected));
    }
  }
}
