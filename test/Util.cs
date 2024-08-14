namespace test {
  internal class Util {
    public static bool SameSigns(int first, int second) =>
      (first > 0 == second > 0) || (first == 0 && second == 0);
  }
}
