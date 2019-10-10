namespace TriangleGrid.Models
{
  public class TriangleByRowColumn
  {
    public int Row { get; set; }

    public int Column { get; set; }

    public bool IsUpper { get; set; }

    public int CartesianAx => Column * 10;

    public int CartesianAy => Row * 10;

    public int CartesianBx => IsUpper ? (Column + 1) * 10 : Column * 10;

    public int CartesianBy => IsUpper ? Row * 10 : (Row + 1) * 10;

    public int CartesianCx => (Column + 1) * 10;

    public int CartesianCy => (Row + 1) * 10;

    public string Label
    {
      get
      {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var rowLabel = letters[Row % letters.Length].ToString();
        if (IsUpper)
        {
          return  rowLabel + (Column * 2 + 2);
        }

        return rowLabel + (Column * 2 + 1);
      }
    }

    public override string ToString()
    {
      return $"{Label}: '({CartesianAx}, {CartesianAy})', '({CartesianBx}, {CartesianBy})', '({CartesianCx}, {CartesianCy})'";
    }
  }
}