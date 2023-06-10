from typing import IO
from sys import stdin, stdout


def get_input(path: str) -> IO[bytes]:
    """Opens a binary input stream

    Args:
        path (str): path

    Returns:
        IO[bytes]: a binary input stream
    """
    if path == "-":
        return stdin.buffer
    else:
        return open(path, "rb")


def get_output(path: str) -> IO[bytes]:
    """Opens a binary output stream

    Args:
        path (str): path

    Returns:
        IO[bytes]: a binary output stream
    """
    if path == "-":
        return stdout.buffer
    else:
        return open(path, "wb")


def get_text_input(path: str) -> IO[str]:
    """Opens a text input stream

    Args:
        path (str): path

    Returns:
        IO[bytes]: a text input stream
    """
    if path == "-":
        return stdin
    else:
        return open(path, "r", encoding="utf8")


def get_text_output(path: str) -> IO[str]:
    """Opens a text output stream

    Args:
        path (str): path

    Returns:
        IO[bytes]: a text output stream
    """
    if path == "-":
        return stdout
    else:
        return open(path, "w", encoding="utf8")
