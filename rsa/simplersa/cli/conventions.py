from typing import IO
from sys import stdin, stdout


def get_input(path: str) -> IO[bytes]:
    if path == "-":
        return stdin.buffer
    else:
        return open(path, "rb")


def get_output(path: str) -> IO[bytes]:
    if path == "-":
        return stdout.buffer
    else:
        return open(path, "wb")


def get_text_input(path: str) -> IO[str]:
    if path == "-":
        return stdin
    else:
        return open(path, "r", encoding="utf8")


def get_text_output(path: str) -> IO[str]:
    if path == "-":
        return stdout
    else:
        return open(path, "w", encoding="utf8")
