from argparse import ArgumentParser


def create_parser() -> ArgumentParser:
    parser = ArgumentParser()
    subparsers = parser.add_subparsers(dest="verb")

    primegen_parser = subparsers.add_parser("primegen", help="Generates a random prime")
    primegen_parser.add_argument(
        "-s", "--size", type=int, default=32, help="Prime size in bits"
    )
    primegen_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Output path"
    )

    keygen_parser = subparsers.add_parser("keygen", help="Generate a RSA key pair")
    keygen_parser.add_argument(
        "-s", "--size", type=int, default=32, help="Size in bits of primes used"
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
        "-i", "--input", type=str, default="-", help="Plaintext input path"
    )
    encrypt_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Ciphertext output path"
    )

    decrypt_parser = subparsers.add_parser("decrypt", help="RSA decrypts")
    decrypt_parser.add_argument("-k", "--key", type=str, help="Decryption key")
    decrypt_parser.add_argument(
        "-i", "--input", type=str, default="-", help="Ciphertext input path"
    )
    decrypt_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Plaintext output path"
    )

    recover_parser = subparsers.add_parser("recover", help="Recovers a RSA key")
    recover_parser.add_argument(
        "-k", "--key", type=str, help="Key which pair should be recovered"
    )
    recover_parser.add_argument(
        "-o", "--output", type=str, default="-", help="Output path"
    )

    return parser
