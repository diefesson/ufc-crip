from argparse import ArgumentParser
from enum import Enum


class Verb(str, Enum):
    Keygen = "keygen"
    Encrypt = "encrypt"
    Decrypt = "decrypt"


def create_parser() -> ArgumentParser:
    parser = ArgumentParser()
    subparsers = parser.add_subparsers(dest="verb")

    keygen_parser = subparsers.add_parser(Verb.Keygen)
    keygen_parser.add_argument("-s", "--size", type=int, default=32)
    keygen_parser.add_argument("-v", "--verbose", action="count", default=0)

    encrypt_parser = subparsers.add_parser(Verb.Encrypt)
    encrypt_parser.add_argument("-k", "--key", type=str)
    encrypt_parser.add_argument("-i", "--input", type=str, default="-")
    encrypt_parser.add_argument("-o", "--output", type=str, default="-")

    decrypt_parser = subparsers.add_parser(Verb.Decrypt)
    decrypt_parser.add_argument("-k", "--key", type=str)
    decrypt_parser.add_argument("-i", "--input", type=str, default="-")
    decrypt_parser.add_argument("-o", "--output", type=str, default="-")

    return parser
