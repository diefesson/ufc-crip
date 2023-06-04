from rsa import decrypt, encrypt, key_gen

if __name__ == "__main__":
    nbits = 16
    pub_key, priv_key = key_gen(16)
    plain = 11
    encrypted = encrypt(pub_key, plain)
    decrypted = decrypt(priv_key, encrypted)
    print(f"pub key = {pub_key}")
    print(f"priv key = {priv_key}")
    print(f"plain = {plain}, encrypted = {encrypted}, decrypted = {decrypted}")
