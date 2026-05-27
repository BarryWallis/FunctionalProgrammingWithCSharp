using System.Linq.Expressions;

// Create the parameter expression representing the first input: x
ParameterExpression x = Expression.Parameter(typeof(int), "x");

// Create the parameter expression representing the second input: y
ParameterExpression y = Expression.Parameter(typeof(int), "y");

// Build the expression tree body for the operation x * y
BinaryExpression body = Expression.Multiply(x, y);

// Combine the parameters and body into a lambda expression: (x, y) => x * y
Expression<Func<int, int, int>> multiplyExpression = Expression.Lambda<Func<int, int, int>>(body, x, y);

// Compile the expression tree into executable code
Func<int, int, int> multiply = multiplyExpression.Compile();

// Execute the compiled delegate and print the result
Console.WriteLine(multiply(6, 7));
