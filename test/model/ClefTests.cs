using tunelint.model;

namespace test.model {
  internal class ClefTests {
    private static readonly object[] _equalsCases = [
      new object[] { new Clef(new(0)), new Clef(new(0)),  true  },
      new object[] { new Clef(new(0)), new Clef(new(4)),  false },
      new object[] { Clef.Alto,        new Clef(new(-4)), true  },
      new object[] { Clef.Treble,      new Clef(new(12)), false }
    ];

    [TestCaseSource(nameof(_equalsCases))]
    public void TestEquals(Clef left, Clef Right, bool expected) =>
      Assert.That(left.Equals(Right), Is.EqualTo(expected));
  }
}
