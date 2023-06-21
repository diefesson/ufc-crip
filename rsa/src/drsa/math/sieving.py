from itertools import takewhile
from typing import List


def sieve(limit: int) -> List[int]:
    """Implementation of Eratosthenes sieve

    Args:
        limit (int): Exclusive limit for prime search

    Returns:
        List[int]: A list of all primes numbers lesser than limit
    """
    primes = [2]
    for i in range(3, limit, 2):
        divisors = takewhile(lambda p: p**2 <= i, primes)
        if not any((i % d == 0 for d in divisors)):
            primes.append(i)
    return primes
