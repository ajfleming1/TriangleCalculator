using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TriangleGrid.Models;

namespace TriangleGrid.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private readonly TriangleContext _context;

    /// <summary>
    /// Instances a new instance of <see cref="ValuesController"/>.
    /// </summary>
    public ValuesController()
    {
      if (_context == null || !_context.Triangles.Any())
      {
        _context = SeedData.SetUpTriangles();
      }
    }

    /// <summary>
    /// Gets all the triangles in the context.
    /// </summary>
    /// <returns>IEnumerable of triangles.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Triangle>> AllTriangles()
    {
      return _context.Triangles;
    }

    /// <summary>
    /// Gets a triangle based on the provided label.
    /// </summary>
    /// <param name="label">Label to use to generate triangle.</param>
    /// <returns>String representation of a triangle.</returns>
    [HttpGet]
    public ActionResult<string> GetByLabelInference(string label)
    {
      // Label must start with a letter followed by a number.
      if (!Regex.IsMatch(label[0].ToString(), @"^[a-zA-Z]+$"))
      {
        throw new InvalidOperationException($"Triangle '{label}' not found.");
      }

      var rowNumber = char.ToUpper(label[0]) - 65;
      var columnRegex = new Regex(@"\d+");
      var match = columnRegex.Match(label);
      if (!match.Success)
      {
        throw new InvalidOperationException($"Triangle '{label}' not found.");
      }

      var cellNumber = Convert.ToInt32(match.Value);
      var columnNumber = Convert.ToInt32(Math.Ceiling(cellNumber / 2d) - 1);
      var triangle = new TriangleByRowColumn()
      {
        Row = rowNumber,
        Column = columnNumber,
        IsUpper = cellNumber % 2 == 0
      };

      return triangle.ToString();
    }

    /// <summary>
    /// Displays triangle details based on provided points.
    /// </summary>
    /// <param name="aX">The X value for point A.</param>
    /// <param name="aY">The Y value for point B.</param>
    /// <param name="bX">The X value for point B.</param>
    /// <param name="bY">The Y value for point B.</param>
    /// <param name="cX">The X value for point C.</param>
    /// <param name="cY">The Y value for point C.</param>
    /// <returns>A string representing a triangle for the given parameters.</returns>
    [HttpGet]
    public ActionResult<string> GetByInferenceCoordinates(int aX, int aY, int bX, int bY, int cX, int cY)
    {
      var isUpper = bY == aY && bX == cX;
      var isLower = bY == cY && bX == aX;
      if (aX % 10 != 0 || aY % 10 != 0 || bX % 10 != 0 || bY % 10 != 0 || cX % 10 != 0 || cY % 10 != 0)
      {
        throw new InvalidOperationException("Coordinates must be multiples of 10.");
      }

      if (!isLower && !isUpper || isUpper && isLower)
      {
        throw new InvalidOperationException("Parameters provided do not produce a triangle in the grid.");
      }

      if (Math.Max(cY, bY) - Math.Min(aY, bY) != 10)
      {
        throw new InvalidOperationException("Triangle height must be of length 10.");
      }

      if (Math.Max(cX, bX) - Math.Min(aX, bX) != 10)
      {
        throw new InvalidOperationException("Triangle width must be of length 10.");
      }

      return new TriangleByRowColumn
      {
        Row = aY / 10,
        Column = aX / 10,
        IsUpper = isUpper
      }.ToString();
    }

    /// <summary>
    /// Gets a triangle using the provided label parameter.
    /// </summary>
    /// <param name="label">The name of the triangle to find.</param>
    /// <returns>The triangle.</returns>
    [HttpGet]
    public ActionResult<Triangle> GetByLabel(string label)
    {
      var triangle = _context.Triangles.FirstOrDefault(t => t.Label == label);
      if (triangle == null)
      {
        throw new InvalidOperationException($"Triangle '{label}' not found.");
      }

      return triangle;
    }

    /// <summary>
    /// Gets a triangle from the context using the provided parameters.
    /// </summary>
    /// <param name="aX">The X value for point A.</param>
    /// <param name="aY">The Y value for point B.</param>
    /// <param name="bX">The X value for point B.</param>
    /// <param name="bY">The Y value for point B.</param>
    /// <param name="cX">The X value for point C.</param>
    /// <param name="cY">The Y value for point C.</param>
    /// <returns>String representing the triangle found.</returns>
    [HttpGet]
    public ActionResult<string> GetByCoordinates(int aX, int aY, int bX, int bY, int cX, int cY)
    {
      var triangle = _context.Triangles.FirstOrDefault(t => t.CartesianAx == aX && t.CartesianAy == aY &&
                                                            t.CartesianBx == bX && t.CartesianBy == bY &&
                                                            t.CartesianCx == cX && t.CartesianCy == cY);
      if (triangle == null)
      {
        throw new InvalidOperationException($"Triangle with points '({aX},{aY})', '({bX},{bY})', '({cX},{cY})' not found.");
      }

      return triangle.Label;
    }
  }
}