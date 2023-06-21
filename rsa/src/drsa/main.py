from argparse import Namespace
from sys import argv

from drsa.cli.io import get_input, get_output, get_text_input, get_text_output
from drsa.cli.parsing import create_parser
from drsa.math.primegen import high_level_candidate
from drsa.rsa.encoding import decode_key, encode_key
from drsa.rsa.encryption import decrypt, encrypt
from drsa.rsa.keygen import keygen
from drsa.rsa.recovering import recover


def _execute_primegen(options: Namespace):
    prime_size = options.size
    output = get_text_output(options.output)
    prime = high_level_candidate(prime_size)
    print(prime, file=output)


def _execute_keygen(options: Namespace):
    prime_size: int = options.size
    pub_key, pri_key = keygen(prime_size)
    pub_output = get_text_output(options.pub)
    pri_output = get_text_output(options.pri)
    encoded_pub_key = encode_key(pub_key)
    encoded_pri_key = encode_key(pri_key)
    if options.pub == "-":
        print("pub key:", encoded_pub_key, file=pub_output)
    else:
        print(encoded_pub_key, file=pub_output)
    if options.pri == "-":
        print("pri key:", encoded_pri_key, file=pri_output)
    else:
        print(encoded_pri_key, file=pri_output)


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


def _execute_recover(options: Namespace):
    key = decode_key(options.key)
    output = get_text_output(options.output)
    recovered_key = recover(key)
    encoded_key = encode_key(recovered_key)
    print(encoded_key, file=output)


def main():
    parser = create_parser()
    options = parser.parse_args(argv[1:])
    match options.verb:
        case "primegen":
            _execute_primegen(options)
        case "keygen":
            _execute_keygen(options)
        case "encrypt":
            _execute_encrypt(options)
        case "decrypt":
            _execute_decrypt(options)
        case "recover":
            _execute_recover(options)
        case _:
            parser.print_help()
