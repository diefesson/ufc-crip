from itertools import count
from math import sqrt
from typing import Tuple


def _nat2int(nat: int):
    if nat % 2 == 0:
        return nat // 2
    else:
        return -(nat + 1) // 2


def factor(n: int) -> Tuple[int, int]:
    """Factorizes the product of two primes

    Args:
        n (int): The number to be factored

    Returns:
        Tuple[int, int]: The two prime factors
    """
    middle = round(sqrt(n))
    if middle % 2 == 0:
        middle += 1
    for i in count():
        candidate = middle + 2 * _nat2int(i)
        if n % candidate == 0:
            return (candidate, n // candidate)
