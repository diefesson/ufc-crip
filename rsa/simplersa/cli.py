from argparse import ArgumentParser, Namespace
from typing import List


def _create_parser() -> ArgumentParser:
    parser = ArgumentParser()
    subparsers = parser.add_subparsers(dest="verb")

    keygen_parser = subparsers.add_parser("keygen")
    keygen_parser.add_argument("-s", "--size", type=int, default=32)
    keygen_parser.add_argument("-v", "--verbose", action="count", default=0)

    return parser


def parse_args(args: List[str]) -> Namespace:
    parser = _create_parser()
    return parser.parse_args(args)
