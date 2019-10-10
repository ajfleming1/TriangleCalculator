using System.Collections.Generic;

namespace TriangleGrid.Models
{
  public static class SeedData
  {
    /// <summary>
    /// Sets up a 6x6 grid of two triangles in each space.
    /// </summary>
    /// <returns>List of triangles.</returns>
    public static TriangleContext SetUpTriangles()
    {
      var context = new TriangleContext();
      var triangles = new List<Triangle>();
      const int columns = 6;
      const int rows = 6;
      var columnIndex = 0;
      while (columnIndex < columns)
      {
        var rowIndex = 0;
        while (rowIndex < rows)
        {
          // The only difference between a top triangle and a bottom triangle
          // in the grid space is is the value of the Bx and By coordinates.
          var rowLabel = GetRowName(rowIndex);
          var bottomLabel = rowLabel + (columnIndex * 2 + 1);
          var topLabel = rowLabel + (columnIndex * 2 + 2);
          
          // Add the 'bottom' triangle to the grid space.
          triangles.Add(
            new Triangle()
            {
              Label = bottomLabel,
              CartesianAx = columnIndex * 10,
              CartesianAy = rowIndex * 10,
              CartesianBx = columnIndex * 10,
              CartesianBy = (rowIndex + 1) * 10,
              CartesianCx = (columnIndex + 1) * 10,
              CartesianCy = (rowIndex + 1) * 10
            });

          // Add the 'top' triangle to the grid space.
          triangles.Add(new Triangle()
          {
            Label = topLabel,
            CartesianAx = columnIndex * 10,
            CartesianAy = rowIndex * 10,
            CartesianBx = (columnIndex + 1) * 10,
            CartesianBy = rowIndex * 10,
            CartesianCx = (columnIndex + 1) * 10,
            CartesianCy = (rowIndex + 1) * 10
          });

          rowIndex++;
        }

        columnIndex++;
      }

      context.Triangles = triangles;
      return context;
    }

    /// <summary>
    /// Gets a row name for the provided row.
    /// </summary>
    /// <param name="row">The row that needs a name.</param>
    /// <returns>String (char) representing the name of the row.</returns>
    public static string GetRowName(int row)
    {
      const string letters = "ABCDEF";
      return letters[row % letters.Length].ToString();
    }
  }
}
