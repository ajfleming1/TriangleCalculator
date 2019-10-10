using System.Collections.Generic;

namespace TriangleGrid.Models
{
  public class TriangleContext
  {
    public TriangleContext() { }


    /// <summary>
    /// Gets or sets the Organization entity.
    /// </summary>
    /// <value>
    /// The Organization.
    /// </value>
    public List<Triangle> Triangles { get; set; }
  }
}