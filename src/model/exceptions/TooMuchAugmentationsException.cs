using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tunelint.model.exceptions {
  public class TooMuchAugmentationsException : Exception {
    public TooMuchAugmentationsException() : base() { }
    public TooMuchAugmentationsException(string message) : base(message) { }

    public TooMuchAugmentationsException(int power, int augmentations) :
      this($"augmentations amount of {augmentations} should be no greater that power {power}") { }
  }
}
