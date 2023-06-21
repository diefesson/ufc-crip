from math import ceil

from drsa.rsa.key import Key


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
