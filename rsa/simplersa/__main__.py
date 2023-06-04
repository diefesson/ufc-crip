import sys
from typing import List

from argparse import Namespace

from simplersa.cli import parse_args
from simplersa.rsa import encode_key, keygen


def main(args: List[str]):
    options = parse_args(args[1:])
    match options.verb:
        case "keygen":
            _execute_keygen(options)
        case _:
            print("unknow verb")


def _execute_keygen(options: Namespace):
    keysize: int = options.size
    pub_key, priv_key = keygen(keysize)
    if options.verbose:
        print(f"raw pub key  = {pub_key}")
        print(f"raw priv key = {priv_key}")
    encoded_pub_key = encode_key(pub_key)
    encoded_priv_key = encode_key(priv_key)
    print(f"pub key  = {encoded_pub_key}")
    print(f"priv key = {encoded_priv_key}")


if __name__ == "__main__":
    main(sys.argv)
