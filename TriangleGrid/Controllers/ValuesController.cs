using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TriangleGrid.Models;

namespace TriangleGrid.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    private TriangleContext _context;

    public ValuesController()
    {
      if (_context == null || !_context.Triangles.Any())
      {
        _context = SeedData.SetUpTriangles();
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Triangle>> AllTriangles()
    {
      return _context.Triangles;
    }


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