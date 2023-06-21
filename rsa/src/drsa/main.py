from argparse import Namespace
from sys import argv

from drsa.cli import (
    create_parser,
    get_input,
    get_output,
    get_text_input,
    get_text_output,
)
from drsa.rsa import keygen, encode_key, decode_key, encrypt, decrypt
from drsa.rsa.recovering import recover


def _execute_keygen(options: Namespace):
    key_size: int = options.size
    pub_key, pri_key = keygen(key_size)
    pub_out = get_text_output(options.pub)
    pri_out = get_text_output(options.pri)
    encoded_pub_key = encode_key(pub_key)
    encoded_pri_key = encode_key(pri_key)
    if options.pub == "-":
        print("pub key:", encoded_pub_key, file=pub_out)
    else:
        print(encoded_pub_key, file=pub_out)
    if options.pri == "-":
        print("pri key:", encoded_pri_key, file=pri_out)
    else:
        print(encoded_pri_key, file=pri_out)


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
        case "keygen":
            _execute_keygen(options)
        case "encrypt":
            _execute_encrypt(options)
        case "decrypt":
            _execute_decrypt(options)
        case "recover":
            _execute_recover(options)
        case _:
            print("unknown verb")
