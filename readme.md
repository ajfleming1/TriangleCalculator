# Triangle Grid Calculator
This project solves the problems posed in this pdf. 
https://drive.google.com/open?id=1PX4U_6829m6dR_fBjSpygfGNISqMi2ZI

I solved the problems in two ways.
First way was to create triangle objects in a list with their coordinates and labels then use linq to query the list. This method throws exceptions if the parameters are out of range or invalid.
Second way uses math and regular expressions to figure out the row, column, and position (upper / lower) of the triangle based on the provided parameters. This way can calculate for infinite columns and 26 (alphabet restricted) rows.

# 1. Sample Requests 
First way using Linq entities.
Using linq - Get all Triangles 

https://localhost:44384/api/values/AllTriangles

Using linq - Get a triangle by label (task 1A) 

https://localhost:44384/api/values/GetByLabel?label=C6

Using linq - Get a triangle by coordinates (task 1B) 

https://localhost:44384/api/values/GetByCoordinates?aX=30&aY=50&bX=30&bY=60&cX=40&cY=60

# 2. Sample Requests
Second way using math and a regular expression.
Caclulate coordinates by label (task 1A) 

https://localhost:44384/api/values/GetByLabelInference?label=A2

Calculate label by coordinates (task 1B) 

https://localhost:44384/api/values/GetByInferenceCoordinates?aX=40&aY=30&bX=40&bY=40&cX=50&cY=40

The following are beyond the grid provided.

https://localhost:44384/api/values/GetByInferenceCoordinates?aX=2050&aY=60&bX=2050&bY=70&cX=2060&cY=70

https://localhost:44384/api/values/getbylabelinference?label=G411