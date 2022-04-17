# BitFinder
A """simple""", cross-platform (maybe?) console application to recover cryptocurrency wallets from device backups.

## Usage
```
bitfinder ./path/to/my/file
```

(see "ser how do i recover dogecoin wallet from my drive bls" for a slightly more comprehensive guide)

## ser how do i recover dogecoin wallet from my drive bls

### 1. make a raw backup of your drive
Seriously. The last thing you want to do is continue to wear down your drive running this silly little tool.

### 2. run bitfinder
See the usage section for more information

### 3. import WIF private keys in to your *core wallet of choice
WIF is a standard format for importing and exporting private keys. BitFinder will output any found private keys in WIF format, all you need to do is import them in to your wallet and voila!

### 4. ???

### 5. profit (hopefully)

## FAQ

### Will this work on encrypted wallet files?
No. If your wallet files are encrypted, your best bet is to mount your backup as a drive, manually decrypt the file, and then just load that in your *core wallet.

### Is this guaranteed to find my keys?
For a number of reasons, no.
Your data may be lost for a number of reasons:
- your file is corrupt/incomplete;
- your file is encrypted;
- your wallet was in an unsupported format (eg: Electrum)

### Why does BitFinder return so many keys?
When searching through raw bytes, there is no way to guarantee that a found private key is *actually* a private key. BitFinder looks for a specific byte prefix, and then extracts the subsequent 32 bytes. It's possible to see false positives - especially if doing this on an entire drive image.
