from typing import Tuple
from math import ceil, gcd
from random import randrange

from simplersa.eea import eea
from simplersa.primes.prime_generation import high_level_candidate

Key = Tuple[int, int]


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


def encrypt(key: Key, data: int) -> int:
    """RSA encryption

    Args:
        key (Key): The key
        data (int): The data to be encrypted

    Returns:
        int: The encrypted data
    """
    return pow(data, key[0], key[1])


def decrypt(key: Key, data: int) -> int:
    """RSA decryption

    Args:
        key (Key): The key
        data (int): The data to be decrypted

    Returns:
        int: The decrypted data
    """
    return pow(data, key[0], key[1])


def _int2hex(value: int) -> str:
    byte_len = ceil(value.bit_length() / 8)
    return value.to_bytes(byte_len).hex().upper()


def encode_key(key: Key) -> str:
    """Encodes a RSA key to a hexadecimal string

    Args:
        key (Key): The key to be encoded

    Returns:
        str: The encoded key
    """
    return f"{_int2hex(key[0])}:{_int2hex(key[1])}"


def decode_key(key: str) -> Key:
    """Decodes a RSA key from a hexadecimal string

    Args:
        key (str): The key to be decoded

    Returns:
        Key: The decoded key
    """
    splits = key.split(":")
    return int(splits[0], 16), int(splits[1], 16)
