from argparse import ArgumentParser


def create_parser() -> ArgumentParser:
    parser = ArgumentParser()
    subparsers = parser.add_subparsers(dest="verb")

    keygen_parser = subparsers.add_parser("keygen", help="Generate a RSA key pair")
    keygen_parser.add_argument(
        "-s", "--size", type=int, default=32, help="Size of primes used"
    )
    keygen_parser.add_argument(
        "--pub", type=str, default="-", help="Public key output path"
    )
    keygen_parser.add_argument(
        "--pri", type=str, default="-", help="private key output path"
    )

    encrypt_parser = subparsers.add_parser("encrypt", help="RSA encrypts")
    encrypt_parser.add_argument("-k", "--key", type=str, help="Encryption key")
    encrypt_parser.add_argument(
        "-i", "--input", type=str, default="-", help="Plaintext input file"
    )
    encrypt_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Ciphertext output file"
    )

    decrypt_parser = subparsers.add_parser("decrypt", help="RSA decrypts")
    decrypt_parser.add_argument("-k", "--key", type=str, help="Decryption key")
    decrypt_parser.add_argument(
        "-i", "--input", type=str, default="-", help="Ciphertext input file"
    )
    decrypt_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Plaintext output file"
    )

    recover_parser = subparsers.add_parser("recover", help="Recovers a RSA key")
    recover_parser.add_argument(
        "-k", "--key", type=str, help="Key which pair should be recovered"
    )
    recover_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Output file"
    )

    return parser
