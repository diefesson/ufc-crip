from argparse import Namespace
from typing import List

from drsa.cli import (
    Verb,
    create_parser,
    get_input,
    get_output,
    get_text_input,
    get_text_output,
)
from drsa.rsa import keygen, encode_key, decode_key, encrypt, decrypt


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


def _execute_encrypt(options: Namespace):
    key = decode_key(options.key)
    input = get_input(options.input)
    output = get_text_output(options.output)
    plaintext = input.read()
    ciphertext = [encrypt(key, p) for p in plaintext]
    print(*ciphertext, sep=",", file=output)


def _execute_decrypt(options: Namespace):
    key = decode_key(options.key)
    input = get_text_input(options.input)
    output = get_output(options.output)
    ciphertext = map(int, input.read().split(","))
    plaintext = bytes([decrypt(key, c) for c in ciphertext])
    output.write(plaintext)


def main(args: List[str]):
    parser = create_parser()
    options = parser.parse_args(args)
    match options.verb:
        case Verb.Keygen:
            _execute_keygen(options)
        case Verb.Encrypt:
            _execute_encrypt(options)
        case Verb.Decrypt:
            _execute_decrypt(options)
        case _:
            print("unknow verb")
