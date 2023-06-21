from functools import reduce
from itertools import repeat
from math import isqrt

from drsa.math.euclides import modular_inverse


class Point:
    """Elliptic curve point"""

    def __init__(self, x: int, y: int) -> None:
        self.x = x
        self.y = y

    def __repr__(self) -> str:
        return f"Point({self.x}, {self.y})"

    def __eq__(self, other: object) -> bool:
        return self.x == other.x and self.y == other.y


class Curve:
    """Elliptic curve"""

    def __init__(self, a: int, b: int, m: int) -> None:
        self.a = a
        self.b = b
        self.m = m

    def from_x(self, x: int) -> Point:
        """Finds a point in this curve for the given x

        Args:
            x (int): The x coordinate

        Returns:
            Point: The point
        """
        y = isqrt(x**3 + self.a * x + self.b)
        return Point(x, y)

    def neq(self, point: Point) -> Point:
        """Negates the points

        Args:
            point (Point): The point to be negated

        Returns:
            Point: The negated point
        """
        return Point(point.x, -point.y % self.m)

    def add(self, left: Point, right: Point) -> Point:
        lambda_ = _calculate_lambda(self, left, right)
        x = (lambda_**2 - left.x - right.x) % self.m
        y = (lambda_ * (left.x - x) % self.m - left.y) % self.m
        return Point(x, y)

    def mul(self, scalar: int, point: Point) -> Point:
        """Multiplies scalar-point multiplication

        Args:
            scalar (int): The scalar
            point (Point): The point

        Returns:
            Point: The resulting point
        """
        return reduce(self.add, repeat(point, scalar))

    def __repr__(self) -> str:
        return f"Curve({self.a}, {self.b}, {self.m})"


def _calculate_lambda(curve: Curve, left: Point, right: Point) -> int:
    if left == right:
        return (
            (3 * left.x**2 + curve.a) * modular_inverse(2 * left.y, curve.m)
        ) % curve.m
    else:
        return (
            (right.y - left.y) * modular_inverse((right.x - left.x) % curve.m, curve.m)
        ) % curve.m
