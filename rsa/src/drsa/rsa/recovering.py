from drsa.math.euclides import modular_inverse
from drsa.math.eulerphi import euler_phi
from drsa.math.factoring import factor
from drsa.rsa.key import Key


def recover(key: Key) -> Key:
    e, n = key
    p, q = factor(n)
    np = euler_phi(p, q)
    d = modular_inverse(e, np)
    return d, n
