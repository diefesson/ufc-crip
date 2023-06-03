from primes.prime_generation import high_level_candidate

if __name__ == "__main__":
    nbits = 16
    candidate = high_level_candidate(64, 20)
    print(candidate)
