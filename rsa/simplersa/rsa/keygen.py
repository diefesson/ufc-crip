from typing import Tuple
from math import gcd
from random import randrange

from simplersa.math import eea, high_level_candidate

from .key import Key


def _find_e(np: int):
    while True:
        e = randrange(2, np)
        if gcd(np, e) == 1:
            return e


def _euler_phi(p: int, q: int) -> int:
    return (p - 1) * (q - 1)


def keygen(nbits: int) -> Tuple[Key, Key]:
    """Generates a RSA key pair

    Args:
        nbits (int): Number of bits

    Returns:
        Tuple[Key, Key]: Tuple containing the public and private
        key, respectively
    """
    p = high_level_candidate(nbits)
    q = high_level_candidate(nbits)
    n = p * q
    np = _euler_phi(p, q)
    e = _find_e(np)
    d = eea(e, np)[1] % np
    return (e, n), (d, n)
