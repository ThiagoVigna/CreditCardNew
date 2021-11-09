# CreditCardNew
> Code created to compose an API that sends data from an encrypted credit card.
> The code generates a public key to encrypt and also decrypts it with the private key.

# How it works?
> ### First, you have to start the ServerApi file.
> - This will cause the system to generate a unique public key to encrypt credit card data

> ### Second, start the Client file.
> - This will make the encrypted data decrypt by the private key on the other side of the application.

>  ### Finally.
> - With the card data already decrypted, it can be used to complete the credit transaction

### Note:
> - *Both at the beginning of the transaction and at the end, the system performs validations to verify if the data is correct.
Otherwise, it triggers an error message stating that the token is invalid, and does not complete the transaction.*
