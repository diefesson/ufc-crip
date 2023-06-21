from itertools import takewhile
from random import randrange
from typing import Tuple

from .prime_sieve import prime_sieve


"""Small primes, less than 350
"""
_small_primes = prime_sieve(350)


def nbit_random(nbits: int) -> int:
    """Generates a random number with the specified number of bits

    Args:
        nbits (int): the number of bits

    Returns:
        int: random number with the specified number of bits
    """
    min = 2 ** (nbits - 1)
    max = 2**nbits
    return randrange(min, max)


def low_level_test(candidate: int) -> bool:
    """Tests if a candidate is coprime for some of small know primes

    Args:
        candidate (int):the number to be tested

    Returns:
        bool: True if its coprime for some of the firs know primes
    """
    divisors = takewhile(lambda p: p**2 < candidate, _small_primes)
    return not any(map(lambda n: candidate % n == 0, divisors))


def low_level_candidate(nbits: int) -> int:
    """Generates a coprime to the some of the small know primes

    Args:
        nbits (int): number of bits of the candidate

    Returns:
        int: The candidate
    """
    while True:
        candidate = nbit_random(nbits)
        if low_level_test(candidate):
            return candidate


def _find_s_d(candidate: int) -> Tuple[int, int]:
    d = candidate - 1
    s = 0
    while d % 2 == 0:
        d //= 2
        s += 1
    assert candidate - 1 == 2**s * d
    return s, d


def _composite_test(candidate: int, s: int, d: int) -> bool:
    a = randrange(2, candidate - 1)
    x = pow(a, d, candidate)
    for _ in range(s):
        y = x**2 % candidate
        if y == 1 and x != 1 and x != candidate - 1:
            return True
        x = y
    if y != 1:
        return True
    return False


def high_level_test(candidate: int, try_count: int) -> bool:
    """Implementation of Miller-Rabin primality test

    Args:
        candidate (int): The number to be tested
        try_count (int): The number of  passes

    Returns:
        bool: True if candidate is probable prime
    """
    s, d = _find_s_d(candidate)
    for _ in range(try_count):
        if _composite_test(candidate, s, d):
            return False
    return True


def high_level_candidate(nbits: int, try_count: int = 20) -> int:
    """Generates a arbitrarily large prime number using Miller-Rabin primality test

    Args:
        nbits (int): Number of bits of the generated candidate
        try_count (int, optional): Number of passes. Defaults to 20.

    Returns:
        int: The candidate
    """
    while True:
        candidate = low_level_candidate(nbits)
        if high_level_test(candidate, try_count):
            return candidate
