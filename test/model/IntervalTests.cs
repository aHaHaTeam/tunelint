using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tunelint.model;

namespace test.model {
  internal class IntervalTests {
    private static readonly object[] _compareCases = [
      new object[] { new Interval(1),  new Interval(1),  0 },
      new object[] { new Interval(-1), new Interval(-1), 0 },
      new object[] { new Interval(1),  new Interval(0),  1 },
      new object[] { new Interval(0),  new Interval(-1), 1 },
      new object[] { new Interval(0),  new Interval(1), -1 },
      new object[] { new Interval(-1), new Interval(0), -1 }
    ];

    private static readonly object[] _pitchDifferenceCases = [
      new object[] { new Pitch(1),  new Pitch(1),  new Interval(0)  },
      new object[] { new Pitch(5),  new Pitch(-1), new Interval(6)  },
      new object[] { new Pitch(-2), new Pitch(7),  new Interval(-9) }
    ];

    private static readonly object[] _pitchAndIntervalSumCases = [
      new object[] { new Pitch(1),  new Interval(0),  new Pitch(1)  },
      new object[] { new Pitch(-1), new Interval(6),  new Pitch(5)  },
      new object[] { new Pitch(7),  new Interval(-9), new Pitch(-2) }
    ];

    private static readonly object[] _timesCases = [
      new object[] { new Interval(1),   5,  new Interval(5)  },
      new object[] { new Interval(-1),  6,  new Interval(-6) },
      new object[] { new Interval(0),   7,  new Interval(0)  },
      new object[] { new Interval(1),  -3,  new Interval(-3) },
      new object[] { new Interval(-1), -5,  new Interval(5)  },
      new object[] { new Interval(0),  -11, new Interval(0)  },
      new object[] { new Interval(1),   0,  new Interval(0)  },
      new object[] { new Interval(-1),  0,  new Interval(0)  },
      new object[] { new Interval(0),   0,  new Interval(0)  }
    ];

    private static readonly object[] _absoluteCases = [
      new object[] { new Interval(5),  new Interval(5) },
      new object[] { new Interval(-7), new Interval(7) },
      new object[] { new Interval(0),  new Interval(0) }
    ];

    private static readonly object[] _toStringCases = [
      new object[] { new Interval(0),    "P1"      },
      new object[] { new Interval(1),    "m2"      },
      new object[] { new Interval(2),    "M2"      },
      new object[] { new Interval(3),    "m3"      },
      new object[] { new Interval(4),    "M3"      },
      new object[] { new Interval(5),    "P4"      },
      new object[] { new Interval(6),    "TT"      },
      new object[] { new Interval(7),    "P5"      },
      new object[] { new Interval(8),    "m6"      },
      new object[] { new Interval(9),    "M6"      },
      new object[] { new Interval(10),   "m7"      },
      new object[] { new Interval(11),   "M7"      },
      new object[] { new Interval(45),   "3O+M6"   },
      new object[] { new Interval(18),   "1O+TT"   },
      new object[] { new Interval(-38),  "-3O+M2"  },
      new object[] { new Interval(-7),   "-P5"     },
      new object[] { new Interval(-122), "-10O+M2" },
    ];

    [TestCaseSource(nameof(_compareCases))]
    public void TestCompare(Interval first, Interval second, int expected) {
      int actual = first.CompareTo(second);
      Assert.That(Util.SameSigns(actual, expected));
    }

    [TestCaseSource(nameof(_pitchDifferenceCases))]
    public void TestPitchDifference(Pitch first, Pitch second, Interval expected) {
      Assert.That(
        first - second,
        Is.EqualTo(expected),
        $"{first} - {second} = {expected}");
    }

    [TestCaseSource(nameof(_pitchAndIntervalSumCases))]
    public void TestPitchAndIntervalSum(Pitch first, Interval second, Pitch expected) {
      Assert.That(
        first + second,
        Is.EqualTo(expected),
        $"{first} + {second} = {expected}");
    }

    [TestCaseSource(nameof(_timesCases))]
    public void TestTimes(Interval first, int second, Interval expected) {
      Assert.That(
        first * second,
        Is.EqualTo(expected),
        $"{first} * {second} = {expected}");
    }

    [TestCaseSource(nameof(_absoluteCases))]
    public void TestAbsolute(Interval input, Interval expected) {
      Assert.That(
        input.Absolute(),
        Is.EqualTo(expected),
        $"|{input}| = {expected}");
    }

    [Test]
    public void OctaveTest() {
      Assert.That(Interval.Octave, Is.EqualTo(new Interval(12)));
    }

    [TestCaseSource(nameof(_toStringCases))]
    public void TestToString(Interval input, string expected) {
      Assert.That(
        input.ToString(),
        Is.EqualTo(expected),
        $"{input} = {expected}");
    }
  }
}
