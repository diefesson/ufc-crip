from math import gcd
from random import randrange
from typing import Tuple

from drsa.math.euclides import modular_inverse
from drsa.math.eulerphi import euler_phi
from drsa.math.primegen import high_level_candidate
from drsa.rsa.key import Key


def _find_e(np: int):
    while True:
        e = randrange(2, np)
        if gcd(np, e) == 1:
            return e


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
    np = euler_phi(p, q)
    e = _find_e(np)
    d = modular_inverse(e, np)
    return (e, n), (d, n)
