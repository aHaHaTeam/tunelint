using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tunelint.model;

namespace test.model {
  internal class NaturalOctavedNoteTests {
    private static readonly object[] _pitchCases = [
      new object[] { 
        new NaturalOctavedNote(NaturalNote.C, Octave.FirstLineOctave),
        new Pitch(0)   },
      new object[] { 
        new NaturalOctavedNote(NaturalNote.F, Octave.ContraOctave),
        new Pitch(-31) },
      new object[] { 
        new NaturalOctavedNote(NaturalNote.B, Octave.SecondLineOctave),
        new Pitch(23) },
      new object[] { 
        new NaturalOctavedNote(NaturalNote.D, Octave.SmallOctave),
        new Pitch(-10) },
      new object[] { 
        new NaturalOctavedNote(NaturalNote.E, Octave.ThirdLineOctave),
        new Pitch(28) },
    ];

    public void TestPitch(NaturalOctavedNote input, Pitch expected) {
      Assert.That(
        input.Pitch,
        Is.EqualTo(expected));
    }
  }
}
