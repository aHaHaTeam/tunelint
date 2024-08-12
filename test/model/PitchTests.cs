using NUnit.Framework;
using tunelint.model;

namespace test.model {
  public class PitchTests {
    private static object[] _compareCases = [
      new object[] { new Pitch(1),  new Pitch(1),  0 },
      new object[] { new Pitch(-1), new Pitch(-1), 0 },
      new object[] { new Pitch(1),  new Pitch(0),  1 },
      new object[] { new Pitch(0),  new Pitch(-1), 1 },
      new object[] { new Pitch(0),  new Pitch(1), -1 },
      new object[] { new Pitch(-1), new Pitch(0), -1 }
    ];

    [TestCaseSource(nameof(_compareCases))]
    public void TestCompare(Pitch first, Pitch second, int expected) {
      int actual = first.CompareTo(second);
      Assert.That(Util.SameSigns(actual, expected));
    }
  }
}