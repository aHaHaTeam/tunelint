using tunelint.model;
using tunelint.model.exceptions;

namespace test.model {
  internal class NoteValueTests {
    private static readonly object[] _toStringCases = [
      new object[] { NoteValue.TwoHundredFiftySixth,                     "256"   },
      new object[] { NoteValue.HundredTwentyEighth,                      "128"   },
      new object[] { NoteValue.SixtyFourth,                              "64"    },
      new object[] { NoteValue.ThirtySecond,                             "32"    },
      new object[] { NoteValue.Sixteenth,                                "S"     },
      new object[] { NoteValue.Eighth,                                   "E"     },
      new object[] { NoteValue.Quater,                                   "Q"     },
      new object[] { NoteValue.Half,                                     "H"     },
      new object[] { NoteValue.Whole,                                    "W"     },
      new object[] { NoteValue.DoubleWhole,                              "D"     },
      new object[] { NoteValue.QuadrupleWhole,                           "DD"    },
      new object[] { NoteValue.OctupleWhole,                             "DDD"   },
      new object[] { NoteValue.HundredTwentyEighth.WithAugmentations(1), "128+1" },
      new object[] { NoteValue.DoubleWhole.WithAugmentations(2),         "D+2"   },
      new object[] { NoteValue.Eighth.WithAugmentations(3),              "E+3"   },
      new object[] { NoteValue.OctupleWhole.WithAugmentations(7),        "DDD+7" }
    ];
    private static readonly object[] _constructorTooMuchAugmentationsCases = [
      new object[] { NoteValue.TwoHundredFiftySixth, 1,  true  },
      new object[] { NoteValue.ThirtySecond,         3,  false },
      new object[] { NoteValue.ThirtySecond,         4,  true  },
      new object[] { NoteValue.OctupleWhole,         11, false }
    ];
    private static readonly object[] _constructorNegativeAugmentationCases = [
      new object[] { NoteValue.Half,         0, false },
      new object[] { NoteValue.ThirtySecond, 1, false },
      new object[] { NoteValue.Eighth,      -1, true  }
    ];
    private static readonly object[] _compareToTests = [
      new object[] {
        NoteValue.Half,
        NoteValue.Eighth,
        1 },
      new object[] {
        NoteValue.Quater,
        NoteValue.Whole,
        -1 },
      new object[] {
        NoteValue.Sixteenth.WithAugmentations(4),
        NoteValue.Eighth,
        -1 },
      new object[] {
        NoteValue.Half.WithAugmentations(4),
        NoteValue.Half.WithAugmentations(3),
        1 },
      new object[] {
        NoteValue.Half,
        NoteValue.Half,
        0 }
    ];

    [TestCaseSource(nameof(_toStringCases))]
    public void TestToString(NoteValue input, string expected) {
      Assert.That(
        input.ToString(),
        Is.EqualTo(expected),
        $"{input} = {expected}");
    }

    [TestCaseSource(nameof(_constructorTooMuchAugmentationsCases))]
    public void TestConstructorTooMuchAugmentations(NoteValue noteValue, int augmentations,
      bool shouldThrow) {
      if (shouldThrow) {
        Assert.Throws<TooMuchAugmentationsException>(()
          => noteValue.WithAugmentations(augmentations));
      } else {
        Assert.DoesNotThrow(()
          => noteValue.WithAugmentations(augmentations));
      }
    }

    [TestCaseSource(nameof(_constructorNegativeAugmentationCases))]
    public void TestConstructorNegativeAugmentations(NoteValue noteValue, int augmentations,
      bool shouldThrow) {
      if (shouldThrow) {
        Assert.Throws<ArgumentOutOfRangeException>(()
          => noteValue.WithAugmentations(augmentations));
      } else {
        Assert.DoesNotThrow(()
          => noteValue.WithAugmentations(augmentations));
      }
    }

    [TestCaseSource(nameof(_compareToTests))]
    public void TestCompareTo(NoteValue left, NoteValue right, int expected) {
      int actual = left.CompareTo(right);
      Assert.That(Util.SameSigns(expected, actual), Is.True);
    }
  }
}
