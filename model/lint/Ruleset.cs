namespace tunelint.model.lint {
  internal interface IRuleset {
    IList<LintError> Check(Melody melody);
  }
}
