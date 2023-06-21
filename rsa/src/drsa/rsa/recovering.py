from drsa.math import euler_phi, factor, modular_inverse

from .key import Key


def recover(key: Key) -> Key:
    e, n = key
    p, q = factor(n)
    np = euler_phi(p, q)
    d = modular_inverse(e, np)
    return d, n
