from typing import Tuple
from math import gcd
from random import randrange

from simplersa.eea import eea
from simplersa.primes.prime_generation import high_level_candidate


def _find_e(np: int):
    while True:
        e = randrange(2, np)
        if gcd(np, e) == 1:
            return e


def _euler_phi(p: int, q: int) -> int:
    return (p - 1) * (q - 1)


def key_gen(nbits: int) -> Tuple[Tuple[int, int], Tuple[int, int]]:
    """Generates a RSA key pair

    Args:
        nbits (int): Number of bits

    Returns:
        Tuple[Tuple[int, int], Tuple[int, int]]: Tuple containing the public and private
        key, respectively
    """
    p = high_level_candidate(nbits)
    q = high_level_candidate(nbits)
    n = p * q
    np = _euler_phi(p, q)
    e = _find_e(np)
    d = eea(e, np)[1] % np
    return (e, n), (d, n)


def encrypt(key: Tuple[int, int], data: int) -> int:
    """RSA encryption

    Args:
        key (Tuple[int, int]): The key
        data (int): The data to be encrypted

    Returns:
        int: The encrypted data
    """
    return pow(data, key[0], key[1])


def decrypt(key: Tuple[int, int], data: int) -> int:
    """RSA decryption

    Args:
        key (Tuple[int, int]): The key
        data (int): The data to be decrypted

    Returns:
        int: The decrypted data
    """
    return pow(data, key[0], key[1])
