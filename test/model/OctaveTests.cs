using tunelint.model;

namespace test.model {
  internal class OctaveTests {
    private static readonly object[] _offsetCases = [
      new object[] { Octave.GreatOctave,     new Interval(-24) },
      new object[] { Octave.ThirdLineOctave, new Interval(24) },
      new object[] { Octave.FirstLineOctave, new Interval(0) }
    ];

    [TestCaseSource(nameof(_offsetCases))]
    public void testOffset(Octave input, Interval expected) {
      Assert.That(input.Offset, Is.EqualTo(expected));
    }
  }
}
