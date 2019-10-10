namespace TriangleGrid.Models
{
  public class Triangle
  {
    /// <summary>
    /// Gets or sets the name of the triangle.
    /// </summary>
    /// <value>The name of the triangle.</value>
    public string Label { get; set; }

    /// <summary>
    /// Gets or sets the value for the X coordinate of
    /// this triangle's point A.
    /// </summary>
    /// <value>The value of the X coordinate for point A.</value>
    public int CartesianAx { get; set; }

    /// <summary>
    /// Gets or sets the value for the Y coordinate of
    /// this triangle's point A.
    /// </summary>
    /// <value>The value of the Y coordinate for point A.</value>
    public int CartesianAy { get; set; }

    /// <summary>
    /// Gets or sets the value for the X coordinate of
    /// this triangle's point B.
    /// </summary>
    /// <value>The value of the X coordinate for point B.</value>
    public int CartesianBx { get; set; }

    /// <summary>
    /// Gets or sets the value for the Y coordinate of
    /// this triangle's point B.
    /// </summary>
    /// <value>The value of the Y coordinate for point B.</value>
    public int CartesianBy { get; set; }

    /// <summary>
    /// Gets or sets the value for the X coordinate of
    /// this triangle's point C.
    /// </summary>
    /// <value>The value of the X coordinate for point C.</value>
    public int CartesianCx { get; set; }

    /// <summary>
    /// Gets or sets the value for the Y coordinate of
    /// this triangle's point C.
    /// </summary>
    /// <value>The value of the Y coordinate for point C.</value>
    public int CartesianCy { get; set; }
  }
}
