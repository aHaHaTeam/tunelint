namespace tunelint.model.lint {
  public enum Severity {
    Info,
    Warning,
    Error
  }

  internal class LintError {
    private readonly Severity _severity;
    private readonly string _text;
    private readonly IEnumerable<int> _errorIndices;

    public Severity Severity => _severity;
    public string Text => _text;
    public IEnumerable<int> ErrorIndices => _errorIndices;

    public LintError(Severity severity, string text, IEnumerable<int> errorIndices) {
      _severity = severity;
      _text = text;
      _errorIndices = errorIndices;
    }
  }
}
