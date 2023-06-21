from drsa.rsa.key import Key


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
