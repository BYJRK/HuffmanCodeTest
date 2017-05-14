# HuffmanCodeTest
A very simple program to calculate (extended) Huffman code of given alphabet. The efficiency is terrible, although the code might seem quite clear.

## Example:

```
Input the symbol and its probability (e.g. A 0.5), use "." to stop:
> A 0.5
> B 0.25
> C 0.15
> D 0.1
> .
Extend time:
1
  AA, p=0.25000, Code=10
  AB, p=0.12500, Code=011
  AC, p=0.07500, Code=0010
  AD, p=0.05000, Code=1111
  BA, p=0.12500, Code=010
  BB, p=0.06250, Code=1100
  BC, p=0.03750, Code=00110
  BD, p=0.02500, Code=11011
  CA, p=0.07500, Code=0001
  CB, p=0.03750, Code=00001
  CC, p=0.02250, Code=000000
  CD, p=0.01500, Code=001110
  DA, p=0.05000, Code=1110
  DB, p=0.02500, Code=11010
  DC, p=0.01500, Code=000001
  DD, p=0.01000, Code=001111
--------------------------------------
Average Codeword Length = 3.5
Entropy = 3.485475
Efficiency = 0.9958501
Press any key to continue.
```
