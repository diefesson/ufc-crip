from typing import List, Tuple

from drsa.math.factoring import factor
from pytest import fixture


@fixture
def cases() -> List[Tuple[int, int]]:
    return [
        (33359, 39373),
        (61673, 58511),
        (42281, 46061),
        (47951, 61153),
    ]


def test_factor(cases: List[Tuple[int, int]]):
    for p1, p2 in cases:
        n = p1 * p2
        factors = factor(n)
        assert len(factors) == 2
        assert p1 in factors
        assert p2 in factors
