from typing import Tuple


def eea(a: int, b: int) -> Tuple[int, int, int]:
    """Extended euclidean algorithm

    Args:
        a (int): first number
        b (int): second number

    Returns:
        Tuple[int, int, int]: a tuple containing, respectively, the the gdc and the two
        integers factors
    """
    pr, r = (a, b) if a >= b else (b, a)
    px, x = (1, 0) if a >= b else (0, 1)
    py, y = (0, 1) if a >= b else (1, 0)
    while r != 0:
        q = pr // r
        pr, r = r, pr - q * r
        px, x = x, px - q * x
        py, y = y, py - q * y
    return pr, px, py


def modular_inverse(n: int, m: int) -> int:
    """Calculate modular inverse

    Args:
        n (int): number to be inverted
        mod (int): modulus

    Returns:
        int: the inverted number
    """
    return eea(m, n)[2] % m
