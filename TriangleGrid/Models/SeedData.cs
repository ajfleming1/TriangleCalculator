using System.Collections.Generic;

namespace TriangleGrid.Models
{
  public static class SeedData
  {
    public static TriangleContext SetUpTriangles()
    {
      var context = new TriangleContext();
      var triangles = new List<Triangle>();
      var columns = 6;
      var rows = 6;
      var columnIndex = 0;
      while (columnIndex < columns)
      {
        var rowIndex = 0;
        while (rowIndex < rows)
        {
          var rowLabel = GetRowName(rowIndex);
          var bottomLabel = rowLabel + (columnIndex * 2 + 1);
          var topLabel = rowLabel + (columnIndex * 2 + 2);
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

    public static string GetRowName(int index)
    {
      const string letters = "ABCDEF";

      return letters[index % letters.Length].ToString();
    }
  }
}
