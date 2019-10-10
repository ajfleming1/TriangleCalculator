namespace TriangleGrid.Models
{
  /// <summary>
  /// This class represents a triangle using row, column, and
  /// a bool indicating whether or not its on the top of a grid space.
  /// </summary>
  public class TriangleByRowColumn
  {
    /// <summary>
    /// Gets or sets the row.
    /// </summary>
    /// <value>
    /// The row.
    /// </value>
    public int Row { get; set; }

    /// <summary>
    /// Gets or sets the column.
    /// </summary>
    /// <value>
    /// The column.
    /// </value>
    public int Column { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether or not
    /// this triangle is on the top of a grid space.
    /// </summary>
    /// <value>
    /// True if the triangle is on the top of a grid space.
    /// </value>
    public bool IsUpper { get; set; }

    /// <summary>
    /// Gets the X value for point A of this triangle.
    /// </summary>
    /// <value>
    /// The X value for point A.
    /// </value>
    public int CartesianAx => Column * 10;

    /// <summary>
    /// Gets the Y value for point A of this triangle.
    /// </summary>
    /// <value>
    /// The Y value for point A.
    /// </value>
    public int CartesianAy => Row * 10;

    /// <summary>
    /// Gets the X value for point B of this triangle.
    /// </summary>
    /// <value>
    /// The X value for point B.
    /// </value>
    public int CartesianBx => IsUpper ? (Column + 1) * 10 : Column * 10;

    /// <summary>
    /// Gets the Y value for point B of this triangle.
    /// </summary>
    /// <value>
    /// The Y value for point B.
    /// </value>
    public int CartesianBy => IsUpper ? Row * 10 : (Row + 1) * 10;

    /// <summary>
    /// Gets the X value for point C of this triangle.
    /// </summary>
    /// <value>
    /// The X value for point C.
    /// </value>
    public int CartesianCx => (Column + 1) * 10;

    /// <summary>
    /// Gets the Y value for point C of this triangle.
    /// </summary>
    /// <value>
    /// The Y value for point C.
    /// </value>
    public int CartesianCy => (Row + 1) * 10;

    /// <summary>
    /// Gets a descriptive label for this triangle.
    /// </summary>
    /// <value>
    /// The label.
    /// </value>
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

    /// <summary>
    /// Returns a value representing this triangle.
    /// </summary>
    /// <returns>String representing this triangle.</returns>
    public override string ToString()
    {
      return $"{Label}: '({CartesianAx}, {CartesianAy})', '({CartesianBx}, {CartesianBy})', '({CartesianCx}, {CartesianCy})'";
    }
  }
}