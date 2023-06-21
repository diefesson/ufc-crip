from drsa.math import factor, eea, euler_phi

from .key import Key


def recover(key: Key) -> Key:
    e, n = key
    p, q = factor(n)
    np = euler_phi(p, q)
    d = eea(e, np)[1] % np
    return d, n
