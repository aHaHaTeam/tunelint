using System.Collections.Generic;
using tunelint.model;
using tunelint.model.exceptions;

namespace test.model {
  internal class MeasureTests {
    private static readonly object[] _enumeratorOutputNotesCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.E), NoteValue.Half) },
        new Measure(new MusicalTime(2, 1)),
        new List<Note> {
          new(new(NaturalNote.E), NoteValue.Half),
          new(null,               NoteValue.Half) }
      },

      new object[] {
        new List<Note> {
          new(null,               NoteValue.Half),
          new(new(NaturalNote.F), NoteValue.Quater) },
      new Measure(new MusicalTime(3, 1)),
        new List<Note> {
          new(null,               NoteValue.Half),
          new(new(NaturalNote.F), NoteValue.Quater),
          new(null,               NoteValue.Quater),
          new(null,               NoteValue.Half) }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half) },
        new Measure(new MusicalTime(9, 3)),
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(null,               NoteValue.Eighth),
          new(null,               NoteValue.Half) }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.E), NoteValue.Eighth),
          new(new(NaturalNote.G), NoteValue.Half) },
        new Measure(new MusicalTime(9, 3)),
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.E), NoteValue.Eighth),
          new(new(NaturalNote.G), NoteValue.Half) }
        }
    ];
    private static readonly object[] _addFailCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(2, 1)),
        new Note(new(NaturalNote.C), NoteValue.Eighth)
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(9, 3)),
        new Note(new(NaturalNote.C), NoteValue.Quater)
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.E), NoteValue.Sixteenth)
        },
        new Measure(new MusicalTime(5, 2)),
        new Note(new(NaturalNote.C), NoteValue.Quater)
      }
    ];
    private static readonly object[] _addCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(9, 3)),
        new Note(new(NaturalNote.C), NoteValue.Eighth)
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.D), NoteValue.Whole)
        },
        new Measure(new MusicalTime(13, 3)),
        new Note(new(NaturalNote.C), NoteValue.Sixteenth)
      }
    ];
    private static readonly object[] _addRangeFailCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(5, 2)),
        new List<Note> { 
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth),
        }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Eighth)
        },
        new Measure(new MusicalTime(2, 1)),
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Quater),
          new(new(NaturalNote.C), NoteValue.Quater),
        }
      }
    ];
    private static readonly object[] _addRangeCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(11, 3)),
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth)
        },
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Eighth)
        }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(5, 2)),
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Eighth),
        },
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(null,               NoteValue.Eighth),
        }
      }
    ];
    private static readonly object[] _insertFailIndexCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        new Note(new(NaturalNote.C), NoteValue.Eighth),
        4
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        new Note(new(NaturalNote.C), NoteValue.Eighth),
        -1
      }
    ];
    private static readonly object[] _insertFailOverfullCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(2, 1)),
        new Note(new(NaturalNote.C), NoteValue.Eighth),
        0
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(9, 3)),
        new Note(new(NaturalNote.C), NoteValue.Quater),
        1
      }
    ];
    private static readonly object[] _insertCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        new Note(new(NaturalNote.C), NoteValue.Eighth),
        1,
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(new(NaturalNote.C), NoteValue.Half),
          new(null, NoteValue.Eighth),
          new(null, NoteValue.Quater),
        }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(7, 2)),
        new Note(new(NaturalNote.C), NoteValue.Eighth),
        3,
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half),
          new(null,               NoteValue.Quater),
          new(new(NaturalNote.C), NoteValue.Eighth),
          new(null,               NoteValue.Eighth),
          new(null,               NoteValue.Quater),
        }
      },
    ];
    private static readonly object[] _removeAtFailCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        2
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.C), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        -1
      }
    ];
    private static readonly object[] _removeAtCases = [
      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.D), NoteValue.Half)
        },
        new Measure(new MusicalTime(3, 1)),
        1,
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(null,               NoteValue.Whole),
        }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.D), NoteValue.Half)
        },
        new Measure(new MusicalTime(2, 1)),
        0,
        new List<Note> {
          new(new(NaturalNote.D), NoteValue.Half),
          new(null,               NoteValue.Half),
        }
      },

      new object[] {
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.D), NoteValue.Half),
          new(new(NaturalNote.E), NoteValue.Half)
        },
        new Measure(new MusicalTime(7, 2)),
        1,
        new List<Note> {
          new(new(NaturalNote.C), NoteValue.Half),
          new(new(NaturalNote.E), NoteValue.Half),
          new(null,               NoteValue.Quater),
          new(null,               NoteValue.Half),
        }
      }
    ];

    [TestCaseSource(nameof(_enumeratorOutputNotesCases))]
    public void TestEnumeratorOutputNotes(
      List<Note> input,
      Measure measure,
      List<Note> expected) {
      List<Note> actual = [];

      foreach (Note note in input)
        measure.Add(note);

      foreach (Note note in measure)
        actual.Add(note);

      Assert.That(actual, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(_addFailCases))]
    public void TestAddFail(List<Note> initial, Measure measure, Note toAdd) {
      measure.AddRange(initial);

      Measure copy = measure;

      Assert.Throws<MeasureOverfullException>(() =>
        measure.Add(toAdd));

      Assert.That(measure, Is.EqualTo(copy));
    }

    [TestCaseSource(nameof(_addCases))]
    public void TestAdd(List<Note> initial, Measure measure, Note toAdd) {
      foreach (var note in initial)
        measure.Add(note);

      Assert.DoesNotThrow(() =>
        measure.Add(toAdd));
    }

    [TestCaseSource(nameof(_addRangeFailCases))]
    public void TestAddRangeFail(List<Note> initial, Measure measure, List<Note> toAdd) {
      measure.AddRange(initial);

      Measure copy = new(measure);

      Assert.Throws<MeasureOverfullException>( () => 
        measure.AddRange(toAdd));

      Assert.That(measure, Is.EqualTo(copy));
    }

    [TestCaseSource(nameof(_addRangeCases))]
    public void TestAddRange(
      List<Note> initial,
      Measure measure,
      List<Note> toAdd,
      List<Note> expected) {
      measure.AddRange(initial);

      measure.AddRange(toAdd);

      Assert.That(measure, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(_insertFailIndexCases))]
    public void TestInsertFailIndex(
      List<Note> initial,
      Measure measure,
      Note toInsert,
      int index) {
      foreach (var note in initial)
        measure.Add(note);

      Assert.Throws<ArgumentOutOfRangeException>(() =>
        measure.Insert(index, toInsert));
    }

    [TestCaseSource(nameof(_insertFailOverfullCases))]
    public void TestInsertFailOverfull(
      List<Note> initial,
      Measure measure,
      Note toInsert,
      int index) {
      foreach (var note in initial)
        measure.Add(note);

      Assert.Throws<MeasureOverfullException>(() =>
        measure.Insert(index, toInsert));
    }

    [TestCaseSource(nameof(_insertCases))]
    public void TestInsert(
      List<Note> initial,
      Measure measure,
      Note toInsert,
      int index,
      List<Note> expected) {
      measure.AddRange(initial);
      measure.Insert(index, toInsert);

      Assert.That(measure, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(_removeAtFailCases))]
    public void TestRemoveAtFail(
      List<Note> initial,
      Measure measure,
      int index) {
      measure.AddRange(initial);
      Measure copy = new(measure);

      Assert.Throws<ArgumentOutOfRangeException>(() =>
        measure.RemoveAt(index));
      Assert.That(measure, Is.EqualTo(copy));
    }

    [TestCaseSource(nameof(_removeAtCases))]
    public void TestRemoveAt(
      List<Note> initial,
      Measure measure,
      int index,
      List<Note> expected) {
      measure.AddRange(initial);
      measure.RemoveAt(index);

      Assert.That(measure, Is.EquivalentTo(expected));
    }
  }
}
