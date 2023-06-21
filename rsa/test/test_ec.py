from drsa.math.ec import Curve, Point
from pytest import fixture


@fixture
def curve() -> Curve:
    return Curve(2, 1, 53)


@fixture
def p() -> Point:
    return Point(7, 27)


@fixture
def q() -> Point:
    return Point(8, 23)


def test_eq(p: Point, q: Point):
    assert p == p
    assert q == q
    assert not p == q
    assert not q == p


def test_add(curve: Curve, p: Point, q: Point):
    assert curve.add(p, p) == Point(33, 21)
    assert curve.add(q, q) == Point(9, 35)
    assert curve.add(p, q) == Point(1, 2)
    assert curve.add(q, p) == Point(1, 2)


def test_mul(curve: Curve, p: Point):
    assert curve.mul(1, p) == p
    assert curve.mul(2, p) == Point(33, 21)
    assert curve.mul(3, p) == Point(51, 28)
    assert curve.mul(4, p) == Point(31, 11)
    assert curve.mul(5, p) == Point(39, 12)
    assert curve.mul(50, p) == Point(12, 2)
